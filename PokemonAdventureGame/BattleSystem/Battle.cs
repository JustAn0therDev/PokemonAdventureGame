using System;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;
using System.Linq;
using System.Collections.Generic;

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
            _player.SetFirstAvailablePokemonAsCurrent();
            _enemyTrainer.SetFirstAvailablePokemonAsCurrent();

            ConsoleBattleInfo.EnemyTrainerSendsPokemon(_enemyTrainer, _enemyTrainer.GetCurrentPokemon());
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());

            //Maintain the battle inside the while loop (to check if there are any more pokémon available in the team)
            //Do the thing

            //Things could happen only inside this function (and other being called by it).
            MainBattle();
        }

        private void MainBattle()
        {
            while (TrainerHasPokemonLeftToBattle(_player) && TrainerHasPokemonLeftToBattle(_enemyTrainer))
            {
                ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());

                //Let the player move
                GetPlayerCommand();

                EnemyMove();

                //if ()
                //{

                //}
            }

            //Check if both pokémon still got HP left.
            //Make the player change pokémon for one available if the current one faints. The enemy should automatically do it.
            //Show the player that no other pokémon is left (that goes for the computer too)
        }

        private void GetPlayerCommand()
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

            //Create deal damage method that will receive another pokemon as a parameter? Sounds like a bad idea..
            targetPokemon.ReceiveDamage(move.Damage);

            ConsoleBattleInfo.ShowPokemonReceivedDamage(targetPokemon, move.Damage);
            ConsoleBattleInfo.ClearScreen();
        }

        private void EnemyMove() => EnemyPokemonMove();

        private void EnemyPokemonMove()
        {
            var rand = new Random();
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();

            List<int> listOfPokemonTwoMoves = enemyPokemon.Moves.Select((s, index) => index).ToList();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), rand.Next(0, enemyPokemon.Moves.Count));
        }

        private void FinishBattle(IPokemon faintedPokemon, ITrainer winningTrainer)
        {
            ConsoleBattleInfo.ShowPokemonFainted(faintedPokemon);
            ConsoleBattleInfo.ShowTrainerWins(winningTrainer);
        }

        private bool TrainerHasPokemonLeftToBattle(ITrainer trainer)
            => trainer.PokemonTeam.Where(w => !w.Fainted).Count() > 0;
    }
}