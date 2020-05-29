using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Types;
using PokemonAdventureGame.Statuses;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle
    {
        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
        private ITrainer _player { get; set; }
        private ITrainer _enemyTrainer { get; set; }

        public Battle(ITrainer player, ITrainer enemyTrainer)
        {
            _player = player;
            _enemyTrainer = enemyTrainer;
        }

        public void StartBattle()
        {
            _player.SetPokemonAsCurrent(_player.GetNextAvailablePokemon());
            _enemyTrainer.SetPokemonAsCurrent(_enemyTrainer.GetNextAvailablePokemon());

            ConsoleBattleInfo.EnemyTrainerSendsPokemon(_enemyTrainer, _enemyTrainer.GetCurrentPokemon());
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());

            MainBattle();
        }

        private void MainBattle()
        {
            KeepBattleGoingWhileBothPlayersHavePokemonLeft();
        }

        private void KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                bool keepBattleGoing = false, isChangingToNextAvailablePokemon = false;

                if (_player.GetCurrentPokemon().CurrentHealthPoints == 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    if (CannotSendNextAvailablePokemon(_player))
                        return;
                    else
                        isChangingToNextAvailablePokemon = true;
                }
                else
                {
                    ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
                    keepBattleGoing = PlayerMove();
                }

                if (keepBattleGoing || !isChangingToNextAvailablePokemon)
                {
                    if (_enemyTrainer.GetCurrentPokemon().CurrentHealthPoints == 0 && _player.HasAvailablePokemon())
                    {
                        if (CannotSendNextAvailablePokemon(_enemyTrainer, true))
                            return;
                    }
                    else
                        EnemyMove();
                }
            }
        }

        private bool CannotSendNextAvailablePokemon(ITrainer trainer, bool isEnemyTrainer = false)
        {
            trainer.SetPokemonAsFainted(trainer.GetCurrentPokemon());

            ConsoleBattleInfo.TrainerDrawsbackPokemon(trainer.GetCurrentPokemon(), isEnemyTrainer);

            if (trainer.GetNextAvailablePokemon() == null)
            {
                if (isEnemyTrainer)
                    FinishBattle(_player, _enemyTrainer);
                else
                    FinishBattle(_enemyTrainer, _player);

                return true;
            }
            else
            {
                SetCurrentToSendNextPokemon(trainer, isEnemyTrainer);
                return false;
            }
        }

        private void FinishBattle(ITrainer winner, ITrainer loser)
        {
            ConsoleBattleInfo.TrainerHasNoPokemonLeft(loser);
            ConsoleBattleInfo.ShowTrainerWins(winner);
        }

        private void SetCurrentToSendNextPokemon(ITrainer trainer, bool isEnemyTrainer)
        {
            trainer.SetPokemonAsCurrent(trainer.GetNextAvailablePokemon());

            if (isEnemyTrainer)
                ConsoleBattleInfo.EnemyTrainerSendsPokemon(trainer, trainer.GetCurrentPokemon());
            else
                ConsoleBattleInfo.PlayerSendsPokemon(trainer.GetCurrentPokemon());
        }

        private bool PlayerMove()
        {
            bool keepBattleGoing = false;

            Console.WriteLine("What are you going to do next?");
            ConsoleBattleInfo.ShowAvailableCommandsOnConsole();

            Command command = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");

            switch (command)
            {
                case Command.ATTACK:
                    PromptTrainerForPokemonMove();
                    keepBattleGoing = true;
                    break;
                case Command.SWITCH_POKEMON:
                    keepBattleGoing = PromptPlayerToSelectPokemon();
                    break;
                case Command.ITEMS:
                case Command.RUN:
                default:
                    Environment.Exit(0);
                    break;
            }

            return keepBattleGoing;
        }

        private void PromptTrainerForPokemonMove()
        {
            int chosenMove = -1;
            IPokemon playerCurrentPokemon = _player.GetCurrentPokemon();

            while ((chosenMove <= -1 || chosenMove > LIMIT_OF_MOVES_PER_POKEMON))
            {
                ConsoleBattleInfo.WriteAllAvailableAttacksOnConsole(playerCurrentPokemon);
                chosenMove = ConsoleBattleInfo.GetPlayerChosenInput(Console.ReadLine());
            }

            PokemonAttack(playerCurrentPokemon, _enemyTrainer.GetCurrentPokemon(), chosenMove);
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
            {
                List<StatusMove> pokemonAlteredStatuses = StatusMoveManager.ProcessStatusMove(attackingPokemon, targetPokemon, move);

                if (move.MoveTarget.Value == StatusMoveTarget.SELF)
                    ConsoleBattleInfo.ShowInflictedStatuses(attackingPokemon, pokemonAlteredStatuses);
                else
                    ConsoleBattleInfo.ShowInflictedStatuses(targetPokemon, pokemonAlteredStatuses);
            }
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
            if (_player.PokemonTeam[chosenPokemon].Fainted)
            {
                ConsoleBattleInfo.PokemonUnavailable();
                PlayerMove();
                return;
            }
            else if (_player.PokemonTeam[chosenPokemon].Current)
            {
                ConsoleBattleInfo.ShowChosenPokemonIsAlreadyInBattle();
                PlayerMove();
                return;
            }

            ConsoleBattleInfo.TrainerDrawsbackPokemon(_player.GetCurrentPokemon());
            _player.SetPokemonAsCurrent(_player.PokemonTeam[chosenPokemon].Pokemon);
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        private void EnemyMove()
        {
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), new Random().Next(0, enemyPokemon.Moves.Count));
        }
    }
}