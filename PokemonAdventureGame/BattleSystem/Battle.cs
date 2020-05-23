using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Types;

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
            ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
            KeepBattleGoingWhileBothPlayersHavePokemonLeft();
        }

        private void KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                if (_player.GetCurrentPokemon().CurrentHealthPoints == 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    if (CannotSendNextAvailablePokemon(_player))
                        return;
                }
                else
                    PlayerMove();

                if (_enemyTrainer.GetCurrentPokemon().CurrentHealthPoints == 0 && _player.HasAvailablePokemon())
                {
                    if (CannotSendNextAvailablePokemon(_enemyTrainer, true))
                        return;
                }
                else
                    EnemyMove();

                ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
            }
        }

        private bool CannotSendNextAvailablePokemon(ITrainer trainer, bool isEnemyTrainer = false)
        {
            trainer.SetPokemonAsFainted(trainer.GetCurrentPokemon());

            ConsoleBattleInfo.TrainerDrawsbackPokemon(trainer.GetCurrentPokemon());

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

        private void SetCurrentToSendNextPokemon(ITrainer trainer, bool isEnemyTrainer)
        {
            trainer.SetPokemonAsCurrent(trainer.GetNextAvailablePokemon());

            if (isEnemyTrainer)
                ConsoleBattleInfo.EnemyTrainerSendsPokemon(trainer, trainer.GetCurrentPokemon());
            else
                ConsoleBattleInfo.PlayerSendsPokemon(trainer.GetCurrentPokemon());
        }

        private void PlayerMove()
        {
            Console.WriteLine("What are you going to do next?");
            ConsoleBattleInfo.ShowAvailableCommandsOnConsole();

            Command command = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");

            switch (command)
            {
                case Command.ATTACK:
                    PromptTrainerForPokemonMove();
                    break;
                case Command.SWITCH_POKEMON:
                case Command.ITEMS:
                case Command.RUN:
                default:
                    throw new NotImplementedException();
            }
        }

        //TODO: Use the command or memento pattern to undo the action of coming to this menu. 
        //The player might send "1" by accident and want to return to give the pokemon an item...
        private void PromptTrainerForPokemonMove()
        {
            int chosenMove = -1;
            IPokemon playerCurrentPokemon = _player.GetCurrentPokemon();

            //This should be implemented for the action commands as well, e.g. switch pokemon, items and run...
            while (chosenMove <= -1 || chosenMove > LIMIT_OF_MOVES_PER_POKEMON)
            {
                ConsoleBattleInfo.WriteAllAvailableAttacksOnConsole(playerCurrentPokemon);
                chosenMove = ConsoleBattleInfo.GetPlayerChosenMove(Console.ReadLine());
            }

            PokemonAttack(playerCurrentPokemon, _enemyTrainer.GetCurrentPokemon(), chosenMove);
        }

        private void PokemonAttack(IPokemon attackingPokemon, IPokemon targetPokemon, int chosenMove)
        {
            IMove move = attackingPokemon.Moves[chosenMove];

            ConsoleBattleInfo.ShowPokemonUsedMove(attackingPokemon, move.GetType().Name);

            if (TypeComparer.PokemonTypeDoesNotMakeContactWithMove(targetPokemon.Types, move))
                ConsoleBattleInfo.MovementDidntAffectPokemon(targetPokemon);
            else
            {
                TypeEffect moveEffectOnPokemon = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(move.Type, targetPokemon.Types.First());
                int finalMoveDamage = TypeDamageCalculator.CalculateDamageBasedOnTypeEffect(move.Damage, moveEffectOnPokemon);
                attackingPokemon.UseMove(chosenMove);
                targetPokemon.ReceiveDamage(finalMoveDamage);
                ConsoleBattleInfo.ShowPokemonReceivedDamage(targetPokemon, finalMoveDamage);

                ConsoleBattleInfo.ShowHowEffectiveTheMoveWas(moveEffectOnPokemon, targetPokemon);
            }
            ConsoleBattleInfo.ClearScreen();
        }

        private void EnemyMove()
        {
            var rand = new Random();
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();

            List<int> listOfPokemonTwoMoves = enemyPokemon.Moves.Select((s, index) => index).ToList();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), rand.Next(0, enemyPokemon.Moves.Count));
        }

        private void FinishBattle(ITrainer winner, ITrainer loser)
        {
            ConsoleBattleInfo.ClearScreen();
            ConsoleBattleInfo.TrainerHasNoPokemonLeft(loser);
            ConsoleBattleInfo.ShowTrainerWins(winner);
        }
    }
}