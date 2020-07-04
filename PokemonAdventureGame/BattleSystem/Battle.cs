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
        private delegate bool PokemonAttackDelegate();
        private delegate bool SwitchPokemonDelegate();
        private delegate void EndProgramDelegate();

        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
        private ITrainer _player { get; set; }
        private ITrainer _enemyTrainer { get; set; }
        private BattleAux _battleAux { get; set; }
        private Dictionary<Command, Delegate> _commands { get; set; }

        public Battle(ITrainer player, ITrainer enemyTrainer)
        {
            _player = player;
            _enemyTrainer = enemyTrainer;
            _battleAux = new BattleAux(player, enemyTrainer);
            InitializeCommandDictionary();
        }

        private void InitializeCommandDictionary()
        {
            _commands = new Dictionary<Command, Delegate>();
            PokemonAttackDelegate firstMethodForAttackDelegate = PromptTrainerForPokemonMove;
            SwitchPokemonDelegate switchPokemonDelegate = PromptPlayerToSelectPokemon;
            EndProgramDelegate endProgramDelegate = EndProgram;

            _commands.Add(Command.ATTACK, firstMethodForAttackDelegate);
            _commands.Add(Command.SWITCH_POKEMON, switchPokemonDelegate);

            //While both commands don't have a method of their own, they will end the program's execution on call.
            _commands.Add(Command.ITEMS, endProgramDelegate);
            _commands.Add(Command.RUN, endProgramDelegate);
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

            ConsoleBattleInfo.EnemyTrainerSendsPokemon(_enemyTrainer, _enemyTrainer.GetCurrentPokemon());
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        private bool KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            bool playerWon = false;
            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                bool keepBattleGoing = false, isChangingToNextAvailablePokemon = false;

                if (_player.GetCurrentPokemon().CurrentHealthPoints == 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    if (_battleAux.CannotSendNextAvailablePokemon(_player))
                        break;
                    else
                        isChangingToNextAvailablePokemon = true;
                }
                else
                {
                    ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
                    keepBattleGoing = PlayerMove();
                }

                if (keepBattleGoing && !isChangingToNextAvailablePokemon)
                {
                    if (_enemyTrainer.GetCurrentPokemon().CurrentHealthPoints == 0 && _player.HasAvailablePokemon())
                    {
                        if (_battleAux.CannotSendNextAvailablePokemon(_enemyTrainer, true))
                            break;
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

            var keepBattleGoing = (bool)_commands[command].DynamicInvoke();

            return keepBattleGoing;
        }

        private bool PromptTrainerForPokemonMove()
        {
            int chosenMove = _battleAux.KeepPlayerChoosingMove(LIMIT_OF_MOVES_PER_POKEMON);
            PokemonAttack(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon(), chosenMove);

            //The battle has to keep going and pass the next movement to the enemy trainer if the command
            //was just an attack.
            //If something happens that the Enemy Trainer should send another pokemon,
            //subsequent methods will handle those.
            return true;
        }

        private void PokemonAttack(IPokemon attackingPokemon, IPokemon targetPokemon, int chosenMove)
        {
            IMove move = attackingPokemon.Moves[chosenMove];

            if (move.PowerPoints == 0)
            {
                ConsoleBattleInfo.MovementIsOutOfPowerPoints();
                PromptTrainerForPokemonMove();
                return;
            }

            ConsoleBattleInfo.ShowPokemonUsedMove(attackingPokemon, move.GetType().Name);

            if (TypeComparer.PokemonTypeDoesNotMakeContactWithMove(targetPokemon.Types, move))
                ConsoleBattleInfo.MovementDidntAffectPokemon(targetPokemon);
            else
                ProcessAttack(attackingPokemon, targetPokemon, move);

            ConsoleBattleInfo.Clear();
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
                ConsoleBattleInfo.ShowPokemonReceivedDamage(targetPokemon, calculatedDamage);
                ConsoleBattleInfo.ShowHowEffectiveTheMoveWas(moveEffectOnPokemon, targetPokemon);
            }
        }

        private bool PromptPlayerToSelectPokemon()
        {
            int chosenPokemon = -1;

            if (_player.PokemonTeam.Where(pkmn => !pkmn.Fainted).Count() == 1)
            {
                ConsoleBattleInfo.ShowPlayerThereAreNoPokemonLeft();
                return false;
            }

            while (chosenPokemon == -1 || chosenPokemon > _player.PokemonTeam.Count)
            {
                ConsoleBattleInfo.ShowAllTrainersPokemon(_player);
                chosenPokemon = ConsoleBattleInfo.GetPlayerChosenInput(Console.ReadLine());
            }

            SwitchCurrentPokemon(chosenPokemon);

            return true;
        }

        private void SwitchCurrentPokemon(int chosenPokemon)
        {
            TrainerPokemon pokemon = _player.PokemonTeam[chosenPokemon];

            if (pokemon.Fainted)
            {
                ConsoleBattleInfo.PokemonUnavailable();
                PlayerMove();
                return;
            }
            else if (pokemon.Current)
            {
                ConsoleBattleInfo.ShowChosenPokemonIsAlreadyInBattle();
                PlayerMove();
                return;
            }

            _battleAux.DrawbackThenSendPokemon(chosenPokemon);
        }

        private void EnemyMove()
        {
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), new Random().Next(0, enemyPokemon.Moves.Count));
        }

        private void EndProgram()
            => Environment.Exit(0);

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
            _battleAux = null;
            _commands = null;
        }
    }
}