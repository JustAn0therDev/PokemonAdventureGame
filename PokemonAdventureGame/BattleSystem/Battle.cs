using System;
using System.Collections.Generic;
using System.Linq;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Types;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle : IDisposable
    {
        #region Private Properties

        private delegate bool PokemonAttackDelegate();
        private delegate bool SwitchPokemonDelegate();
        private delegate bool UseItemDelegate();
        private PlayerAction _playerAction = new PlayerAction();
        private EnemyAction _enemyAction = new EnemyAction();
        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
        private ITrainer _player { get; set; }
        private ITrainer _enemyTrainer { get; set; }
        private BattleAux _battleAux { get; set; }
        private Dictionary<Command, Delegate> _commands { get; set; }

        #endregion

        public Battle(ITrainer player, ITrainer enemyTrainer)
        {
            _player = player;
            _enemyTrainer = enemyTrainer;
            _battleAux = new BattleAux(player, enemyTrainer, _enemyAction, _playerAction);
            InitializeCommandDictionary();
        }

        private void InitializeCommandDictionary()
        {
            PokemonAttackDelegate firstMethodForAttackDelegate = PromptTrainerForPokemonMove;
            SwitchPokemonDelegate switchPokemonDelegate = PromptPlayerToSelectPokemon;
            UseItemDelegate chooseItemDelegate = PromptPlayerToChooseItem;

            _commands = new Dictionary<Command, Delegate>
            {
                { Command.ATTACK, firstMethodForAttackDelegate },
                { Command.SWITCH_POKEMON, switchPokemonDelegate },
                { Command.ITEMS, chooseItemDelegate }
            };
        }

        public bool StartBattle()
        {
            BothTrainersSendPokemon();
            return KeepBattleGoingWhileBothPlayersHavePokemonLeft();
        }

        private void BothTrainersSendPokemon()
        {
            _player.SetPokemonAsCurrent(_player.GetNextAvailablePokemon());
            _enemyTrainer.SetPokemonAsCurrent(_enemyTrainer.GetNextAvailablePokemon());

            _enemyAction.EnemyTrainerSendsPokemon(_enemyTrainer);
            _playerAction.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        private bool KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            bool playerWon = false;
            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                bool keepBattleGoing = false, isChangingToNextAvailablePokemon = false;

                if (_player.GetCurrentPokemon().CurrentHealthPoints <= 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    if (PromptPlayerToSelectPokemonAfterAnotherPokemonFainted())
                        break;
                    else
                    {
                        PromptPlayerToSelectPokemonAfterAnotherPokemonFainted();
                        isChangingToNextAvailablePokemon = true;
                    }
                }
                else
                {
                    ConsoleBattleInfoPokemon.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
                    keepBattleGoing = PlayerMove();
                }

                if (keepBattleGoing && !isChangingToNextAvailablePokemon)
                {
                    if (_enemyTrainer.GetCurrentPokemon().CurrentHealthPoints <= 0 && _player.HasAvailablePokemon())
                    {
                        if (_battleAux.CannotSendNextAvailablePokemon(_enemyTrainer, true))
                            break;
                        else
                            PromptPlayerToSelectPokemonAfterAnotherPokemonFainted();
                    }
                    else
                        EnemyMove();
                }
            }

            if (_player.HasAvailablePokemon())
                playerWon = true;

            return playerWon;
        }

        private bool PlayerMove()
        {
            Console.WriteLine("What are you going to do next?");
            ConsoleBattleInfo.ShowAvailableCommandsOnConsole();

            Command command = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");
            bool keepBattleGoing = (bool)_commands[command].DynamicInvoke();

            return keepBattleGoing;
        }

        #region Player Commands

        private bool PromptTrainerForPokemonMove()
        {
            bool keepBattleGoing = true;
            int chosenMove = _battleAux.KeepPlayerChoosingMove(LIMIT_OF_MOVES_PER_POKEMON);
            PokemonAttack(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon(), chosenMove);

            return keepBattleGoing;
        }

        private void PokemonAttack(IPokemon attackingPokemon, IPokemon targetPokemon, int chosenMove)
        {
            IMove move = attackingPokemon.Moves[chosenMove];

            if (ConsoleBattleInfoMove.MoveDoesNotHavePowerPointsLeft(move))
            {
                PromptTrainerForPokemonMove();
                return;
            }

            ConsoleBattleInfoPokemon.ShowPokemonUsedMove(attackingPokemon, move.GetType().Name);

            if (TypeComparer.PokemonTypeDoesNotMakeContactWithMove(targetPokemon.Types, move))
                ConsoleUtils.ShowMessageAndWaitOneSecond($"It didn't affect {targetPokemon.GetType().Name}!");
            else
                ProcessAttack(attackingPokemon, targetPokemon, move);

            ConsoleUtils.ClearScreen();
        }

        private void ProcessAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            TypeEffect moveEffectOnPokemon = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(move.Type, targetPokemon.Types.FirstOrDefault());

            int calculatedDamage = TypeDamageCalculator.CalculateDamage(attackingPokemon, targetPokemon, move, moveEffectOnPokemon);

            attackingPokemon.UseMove(move);

            if (move.StatusMoves != null)
                _battleAux.ProcessStatusAttack(attackingPokemon, targetPokemon, move);
            else
            {
                targetPokemon.ReceiveDamage(calculatedDamage);
                ConsoleBattleInfoPokemon.ShowPokemonReceivedDamage(targetPokemon, calculatedDamage);
                ConsoleBattleInfoTypes.ShowHowEffectiveTheMoveWas(moveEffectOnPokemon);
            }
        }

        private bool PromptPlayerToSelectPokemon()
        {
            bool keepBattleGoingAfterPokemonSelection = false;

            if (_player.PokemonTeam.Where(pkmn => !pkmn.Fainted).Count() == 1)
            {
                ConsoleBattleInfoTrainer.ShowPlayerThereAreNoPokemonLeftToSwitch();
                return keepBattleGoingAfterPokemonSelection;
            }

            int chosenPokemonIndex = _battleAux.KeepPlayerChoosingPokemonIndex();

            SwitchCurrentPokemon(chosenPokemonIndex);
            keepBattleGoingAfterPokemonSelection = true;

            return keepBattleGoingAfterPokemonSelection;
        }

        private void SwitchCurrentPokemon(int chosenPokemon, bool isChangingAfterAnotherPokemonFainted = false)
        {
            TrainerPokemon pokemon = _player.PokemonTeam[chosenPokemon];

            if (pokemon.Current && isChangingAfterAnotherPokemonFainted)
                return;

            if (pokemon.Fainted)
            {
                ConsoleBattleInfoPokemon.ShowChosenPokemonIsNotAvailable();
                PlayerMove();
                return;
            }

            if (pokemon.Current)
            {
                ConsoleBattleInfoPokemon.ShowChosenPokemonIsAlreadyInBattle();
                PlayerMove();
                return;
            }

            _battleAux.DrawbackThenSendPokemon(chosenPokemon);
        }

        private bool PromptPlayerToChooseItem()
        {
            int chosenStackedItemsIndex = _battleAux.KeepPlayerChoosingItem(_player, _player.Items.Count);
            int chosenPokemonIndex = _battleAux.KeepPlayerChoosingPokemonIndex();

            IPokemon chosenPokemon = _player.PokemonTeam[chosenPokemonIndex].Pokemon;
            IItem chosenItem = _player.Items.ElementAt(chosenStackedItemsIndex).Value.FirstOrDefault();

            return CheckIfShouldKeepBattleGoingAfterItemSelection(chosenItem, chosenStackedItemsIndex, chosenPokemon);
        }

        private bool CheckIfShouldKeepBattleGoingAfterItemSelection(IItem chosenItem, int chosenStackedItemsIndex, IPokemon chosenPokemon)
        {
            bool itemWasSuccessfullyUsed = false;
            if (chosenItem != null && chosenItem.TryToUseItemOnPokemon(chosenPokemon))
            {
                ConsoleBattleInfoItems.ShowItemWasUsedOnPokemon(chosenItem, chosenPokemon);
                _player.Items.ElementAt(chosenStackedItemsIndex).Value.Remove(chosenItem);
                itemWasSuccessfullyUsed = true;
            }
            else
                ConsoleBattleInfoItems.ShowItemCannotBeUsed();

            return itemWasSuccessfullyUsed;
        }

        private bool PromptPlayerToSelectPokemonAfterAnotherPokemonFainted()
        {
            bool isNotChangingTheCurrentPokemon = false;
            if (_player.PokemonTeam.Where(pkmn => !pkmn.Fainted).Count() == 1) 
            {
                isNotChangingTheCurrentPokemon = true;
                return isNotChangingTheCurrentPokemon;
            }

            ConsoleUtils.ShowMessageBetweenEmptyLines("Which pokemon will you choose?");
            int chosenPokemonIndex = _battleAux.KeepPlayerChoosingPokemonIndex();

            SwitchCurrentPokemon(chosenPokemonIndex, true);

            return isNotChangingTheCurrentPokemon;
        }

        #endregion

        private void EnemyMove()
        {
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), new Random().Next(0, enemyPokemon.Moves.Count));
        }

        #region Dispose Methods and Memory Management

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            _player = null;
            _enemyTrainer = null;
            _playerAction = null;
            _enemyAction = null;
            _battleAux = null;
            _commands = null;
        }

        #endregion
    }
}