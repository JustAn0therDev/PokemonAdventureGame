using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem
{
    //TODO: be able to switch first and second pokemon by passing a pokemon list in the constructor.
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
            IPokemon currentBattlingPlayerPokemon = _player.GetCurrentPokemon();
            IPokemon currentBattlingEnemyPokemon = _enemyTrainer.GetCurrentPokemon();

            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                if (currentBattlingPlayerPokemon.CurrentHealthPoints == 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    _player.SetPokemonAsFainted(currentBattlingPlayerPokemon);

                    ConsoleBattleInfo.TrainerDrawsbackPokemon(_player.GetCurrentPokemon());

                    if (_player.GetNextAvailablePokemon() == null)
                    {
                        FinishBattle(_enemyTrainer, _player);
                        return;
                    }
                    else
                    {
                        currentBattlingPlayerPokemon = _player.GetNextAvailablePokemon();

                        _player.SetPokemonAsCurrent(currentBattlingPlayerPokemon);
                        ConsoleBattleInfo.PlayerSendsPokemon(currentBattlingPlayerPokemon);
                    }
                }
                else
                    PlayerMove();

                if (currentBattlingEnemyPokemon.CurrentHealthPoints == 0 && _player.HasAvailablePokemon())
                {
                    _enemyTrainer.SetPokemonAsFainted(currentBattlingEnemyPokemon);

                    ConsoleBattleInfo.TrainerDrawsbackPokemon(_enemyTrainer.GetCurrentPokemon());

                    if (_enemyTrainer.GetNextAvailablePokemon() == null)
                    {
                        FinishBattle(_player, _enemyTrainer);
                        return;
                    }
                    else
                    {
                        currentBattlingEnemyPokemon = _enemyTrainer.GetNextAvailablePokemon();

                        _enemyTrainer.SetPokemonAsCurrent(currentBattlingEnemyPokemon);
                        ConsoleBattleInfo.EnemyTrainerSendsPokemon(_enemyTrainer, currentBattlingEnemyPokemon);
                    }
                }
                else
                    EnemyMove();

                ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
            }
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

            //Should this while loop be a responsability of the battle class or the BattleConsoleInfo class?
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

            targetPokemon.ReceiveDamage(move.Damage);

            ConsoleBattleInfo.ShowPokemonReceivedDamage(targetPokemon, move.Damage);
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