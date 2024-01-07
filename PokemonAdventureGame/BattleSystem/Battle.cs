using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Types;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle
    {
        #region Private Properties

        private delegate bool PokemonAttackDelegate();
        private delegate bool SwitchPokemonDelegate();
        private delegate bool UseItemDelegate();
        private const int LimitOfMovesPerPokemon = 4;
        private ITrainer Player { get; set; }
        private ITrainer EnemyTrainer { get; set; }
        private BattleAux BattleAux { get; set; }
        private Dictionary<Command, Delegate> Commands { get; set; }

        #endregion

        public Battle(ITrainer player, ITrainer enemyTrainer)
        {
            Player = player;
            EnemyTrainer = enemyTrainer;
            BattleAux = new BattleAux(player, enemyTrainer);
            InitializeCommandDictionary();
        }

        private void InitializeCommandDictionary()
        {
            PokemonAttackDelegate firstMethodForAttackDelegate = PromptTrainerForPokemonMove;
            SwitchPokemonDelegate switchPokemonDelegate = PromptPlayerToSelectPokemon;
            UseItemDelegate chooseItemDelegate = PromptPlayerToChooseItem;
            UseItemDelegate pokemonStatusDelegate = PromptPokemonStatus;

            Commands = new Dictionary<Command, Delegate>
            {
                { Command.ATTACK, firstMethodForAttackDelegate },
                { Command.SWITCH_POKEMON, switchPokemonDelegate },
                { Command.ITEMS, chooseItemDelegate },
                { Command.POKEMON_STATUS, pokemonStatusDelegate }
            };
        }

        public bool StartBattle()
        {
            BothTrainersSendPokemon();
            return KeepBattleGoingWhileBothPlayersHavePokemonLeft();
        }

        private void BothTrainersSendPokemon()
        {
            Player.SetPokemonAsCurrent(Player.GetNextAvailablePokemon());
            EnemyTrainer.SetPokemonAsCurrent(EnemyTrainer.GetNextAvailablePokemon());

            EnemyAction.EnemyTrainerSendsPokemon(EnemyTrainer);
            PlayerAction.PlayerSendsPokemon(Player.GetCurrentPokemon());
        }

        private bool KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            bool playerWon = false;
            while (Player.HasAvailablePokemon() && EnemyTrainer.HasAvailablePokemon())
            {
                bool keepBattleGoing = false;
                bool isChangingToNextAvailablePokemon = false;

                if (Player.GetCurrentPokemon().HasFainted() && EnemyTrainer.HasAvailablePokemon())
                {
                    PromptPlayerToSelectPokemonAfterOwnPokemonFainted();
                    PlayerAction.PlayerSendsPokemon(Player.GetCurrentPokemon());
                    isChangingToNextAvailablePokemon = true;
                }
                else
                {
                    PlayerMoveOutput output;

                    do
                    {
                        ConsoleBattleInfoPokemon.ShowBothPokemonStats(
                            Player.GetCurrentPokemon(),
                            EnemyTrainer.GetCurrentPokemon()
                        );

                        output = PlayerMove();
                        keepBattleGoing = output == PlayerMoveOutput.KeepBattleGoing;
                    } while (output == PlayerMoveOutput.SelectedInvalidOption);
                }

                if (!keepBattleGoing || isChangingToNextAvailablePokemon) 
                    continue;
                
                if (EnemyTrainer.GetCurrentPokemon().HasFainted() && Player.HasAvailablePokemon())
                {
                    if (BattleAux.CannotSendNextAvailablePokemon(isEnemyTrainer: true))
                    {
                        break;
                    }
                    
                    PromptPlayerToSelectPokemonAfterEnemyPokemonFainted();
                    BattleAux.ShowTrainerSentPokemonMessage(isEnemyTrainer: true);
                    PlayerAction.PlayerSendsPokemon(Player.GetCurrentPokemon());
                }
                else
                {
                    EnemyMove();
                }
            }

            if (Player.HasAvailablePokemon())
            {
                playerWon = true;
            }

            return playerWon;
        }

        private PlayerMoveOutput PlayerMove()
        {
            Console.WriteLine("What are you going to do next?");
            ConsoleBattleInfo.ShowAvailableCommandsOnConsole();

            Command chosenCommand = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");

            if (PlayerChoseAnInvalidCommand(chosenCommand))
            {
                ConsoleBattleInfoPokemon.ShowInvalidCommandMessage();
                return PlayerMoveOutput.SelectedInvalidOption;
            }

            bool keepBattleGoing = (bool)Commands[chosenCommand].DynamicInvoke()!;
            if (chosenCommand == Command.POKEMON_STATUS)
            {
                ConsoleUtils.ClearScreen();
                return PlayerMoveOutput.SelectedInvalidOption;
            }

            return keepBattleGoing ? PlayerMoveOutput.KeepBattleGoing : PlayerMoveOutput.EndBattle;
        }

        private static bool PlayerChoseAnInvalidCommand(Command chosenCommand) 
            => chosenCommand != Command.ITEMS  &&
               chosenCommand != Command.ATTACK &&
               chosenCommand != Command.SWITCH_POKEMON &&
               chosenCommand != Command.POKEMON_STATUS;

        #region Player Commands

        private bool PromptTrainerForPokemonMove()
        {
            int chosenMove = BattleAux.KeepPlayerChoosingMove(LimitOfMovesPerPokemon);
            PokemonAttack(Player.GetCurrentPokemon(), EnemyTrainer.GetCurrentPokemon(), chosenMove);

            return true;
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
            {
                ConsoleUtils.ShowMessageAndWaitOneSecond($"It didn't affect {targetPokemon.GetType().Name}!");
            }
            else
            {
                ProcessAttack(attackingPokemon, targetPokemon, move);
            }

            ConsoleUtils.ClearScreen();
        }

        private static void ProcessAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            TypeEffect moveEffectOnPokemon = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(move.Type, targetPokemon.Types.FirstOrDefault());

            int calculatedDamage = TypeDamageCalculator.CalculateDamage(attackingPokemon, targetPokemon, move, moveEffectOnPokemon);

            attackingPokemon.UseMove(move);

            if (move.StatusMoves != null)
            {
                BattleAux.ProcessStatusAttack(attackingPokemon, targetPokemon, move);
            }
            else
            {
                targetPokemon.ReceiveDamage(calculatedDamage);
                ConsoleBattleInfoPokemon.ShowPokemonReceivedDamage(targetPokemon, calculatedDamage);
                ConsoleBattleInfoTypes.ShowHowEffectiveTheMoveWas(moveEffectOnPokemon);
            }
        }

        private bool PromptPlayerToSelectPokemon()
        {
            if (Player.PokemonTeam.Count(pkmn => !pkmn.Fainted) == 1)
            {
                ConsoleBattleInfoTrainer.ShowPlayerThereAreNoPokemonLeftToSwitch();
                return false;
            }

            int chosenPokemonIndex = BattleAux.KeepPlayerChoosingPokemon();

            SwitchCurrentPokemon(chosenPokemonIndex);

            return true;
        }

        private void SwitchCurrentPokemon(int chosenPokemon, bool isChangingAfterOwnPokemonFainted = false)
        {
            TrainerPokemon pokemon = Player.PokemonTeam[chosenPokemon];

            if (pokemon == null || (pokemon.Current && isChangingAfterOwnPokemonFainted))
            {
                return;
            }
            
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

            BattleAux.ShowDrawbackMessageAndSetChosenPokemonIndexAsCurrent(chosenPokemon);
        }

        private bool PromptPlayerToChooseItem()
        {
            int chosenStackedItemsIndex = BattleAux.KeepPlayerChoosingItem(Player.Items.Count - 1);
            int chosenPokemonIndex = BattleAux.KeepPlayerChoosingPokemon();

            IPokemon chosenPokemon = Player.PokemonTeam[chosenPokemonIndex].Pokemon;
            IItem chosenItem = Player.Items.ElementAt(chosenStackedItemsIndex).Value.FirstOrDefault()!;

            return CheckIfShouldKeepBattleGoingAfterItemSelection(chosenItem, chosenStackedItemsIndex, chosenPokemon);
        }

        private bool PromptPokemonStatus()
        {
            BattleAux.ShowPlayerCurrentPokemonStatus();

            return true;
        }

        private bool CheckIfShouldKeepBattleGoingAfterItemSelection(IItem chosenItem, int chosenStackedItemsIndex, IPokemon chosenPokemon)
        {
            bool itemWasSuccessfullyUsed = false;
            if (chosenItem != null && chosenItem.TryToUseItemOnPokemon(chosenPokemon))
            {
                ConsoleBattleInfoItems.ShowItemWasUsedOnPokemon(chosenItem, chosenPokemon);
                Player.Items.ElementAtOrDefault(chosenStackedItemsIndex).Value.Remove(chosenItem);
                itemWasSuccessfullyUsed = true;
            }
            else
            {
                ConsoleBattleInfoItems.ShowItemCannotBeUsed();
            }

            return itemWasSuccessfullyUsed;
        }

        private void PromptPlayerToSelectPokemonAfterOwnPokemonFainted()
        {
            int chosenPokemonIndex;

            if (Player.PokemonTeam.Count(w => !w.Pokemon.HasFainted()) > 1)
            {
                ConsoleUtils.ShowMessageBetweenEmptyLines($"{Player.GetCurrentPokemon().GetType().Name} fainted!");
                ConsoleUtils.ShowMessageBetweenEmptyLines("Which pokemon will you choose?");
                chosenPokemonIndex = BattleAux.KeepPlayerChoosingPokemon();
            }
            else
            {
                chosenPokemonIndex = Player.PokemonTeam.IndexOf(
                    Player.PokemonTeam.FirstOrDefault(w => !w.Fainted)!
                    );
            }
            
            SwitchCurrentPokemon(chosenPokemonIndex, isChangingAfterOwnPokemonFainted: true);
        }

        private void PromptPlayerToSelectPokemonAfterEnemyPokemonFainted()
        {
            int chosenPokemonIndex;

            if (Player.PokemonTeam.Count(w => !w.Pokemon.HasFainted()) > 1)
            {
                ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{EnemyTrainer.GetType().Name} is about to send out {EnemyTrainer.GetCurrentPokemon().GetType().Name}");
                ConsoleUtils.ShowMessageBetweenEmptyLines("Which pokemon will you choose?");
                chosenPokemonIndex = BattleAux.KeepPlayerChoosingPokemon();
            }
            else
            {
                chosenPokemonIndex = Player.PokemonTeam.IndexOf(Player.PokemonTeam.FirstOrDefault(w => !w.Fainted));
            }
            
            SwitchCurrentPokemon(chosenPokemonIndex, isChangingAfterOwnPokemonFainted: true);
        }

        #endregion

        private void EnemyMove()
        {
            IPokemon enemyPokemon = EnemyTrainer.GetCurrentPokemon();
            int randomEnemyMoveIndex = new Random().Next(0, enemyPokemon.Moves.Count);

            PokemonAttack(enemyPokemon, Player.GetCurrentPokemon(), randomEnemyMoveIndex);
        }
    }
}
