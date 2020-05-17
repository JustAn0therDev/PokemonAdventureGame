using System;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Trainers;
using System.Threading;
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

        //Make both trainers send out their pokemons.
        //And then start the battle.
        //If the one of the trainers have more than one pokemon, the battle should continue by making the player with remaining pokemons send theirs.

        public void StartBattle()
        {
            _player.SetFirstAvailablePokemonAsCurrent();
            _enemyTrainer.SetFirstAvailablePokemonAsCurrent();

            ConsoleBattleInfo.SendPokemon(_player, _player.GetCurrentPokemon());
            ConsoleBattleInfo.SendPokemon(_enemyTrainer, _enemyTrainer.GetCurrentPokemon());
        }

        private void MainBattleMenu()
        {
            //Console.WriteLine("START BATTLE!!");
            //Console.WriteLine(string.Empty);

            while (PokemonOne.CurrentHealthPoints > 0 && PokemonTwo.CurrentHealthPoints > 0)
            {
                ShowBothPokemonStats();

                if (_pokemonOneHasMoved)
                    PokemonTwoMove();
                else
                    PokemonOneMove();
            }

            if (PokemonOne.CurrentHealthPoints <= 0)
                FinishBattle(PokemonOne, PokemonTwo);
            else
                FinishBattle(PokemonTwo, PokemonOne);
        }

        //Since a lot of code might be repeated for each pokemon, we might want to separate it in different classes so we can manage the console 
        //in a different class for showing the "UI" to the user while we manage the whole state of the current happening pokemon battle here.
        private void ShowBothPokemonStats()
        {
            Console.WriteLine($"{PokemonOne.GetType().Name} - HP: {PokemonOne.CurrentHealthPoints}/{PokemonOne.HealthPoints}");
            Console.WriteLine($"{PokemonTwo.GetType().Name} - HP: {PokemonTwo.CurrentHealthPoints}/{PokemonTwo.HealthPoints}");
            Console.WriteLine("");
        }

        //Can we NOT repeat code here? 
        private void PokemonOneMove()
        {
            Console.WriteLine("What are you going to do next?");
            ShowAvailableCommandsOnConsole();

            Command command = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");

            switch (command)
            {
                case Command.ATTACK:
                    ShowPokemonAvailableAttacks(PokemonOne);
                    break;
                case Command.SWITCH_POKEMON:
                case Command.ITEMS:
                case Command.RUN:
                default:
                    throw new NotImplementedException();
            }
        }

        private void PokemonTwoMove()
        {
            var rand = new Random();
            List<int> listOfPokemonTwoMoves = PokemonTwo.Moves.Select((s, index) => index).ToList();

            AttackWithChosenMove(PokemonTwo, 1);
        }

        private void ShowAvailableCommandsOnConsole()
        {
            Console.WriteLine($"{(int)Command.ATTACK}: {Command.ATTACK.ToString()}");
            //Console.WriteLine($"{(int)Command.SWITCH_POKEMON}: {Command.SWITCH_POKEMON.ToString().Replace("_", " ")}");
            //Console.WriteLine($"{(int)Command.ITEMS}: {Command.ITEMS.ToString()}");
            //Console.WriteLine($"{(int)Command.RUN}: {Command.RUN.ToString()}");
        }

        //TODO: Use the command or memento pattern to undo the action of coming to this menu. 
        //The player might send "1" by accident and want to return to give the pokemon an item...
        private void ShowPokemonAvailableAttacks(IPokemon pokemon)
        {
            int chosenMove = -1;
            Console.WriteLine("Choose your attack!");

            while (chosenMove <= -1 || chosenMove > LIMIT_OF_MOVES_PER_POKEMON)
            {
                WriteAllAvailableAttacksOnConsole(pokemon);
                int.TryParse(Console.ReadLine(), out chosenMove);
                Console.Clear();
            }

            AttackWithChosenMove(pokemon, chosenMove);
        }

        private void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            for (int i = 0; i < pokemon.Moves.Count; i++)
                Console.WriteLine($"{i}: {pokemon.Moves[i].GetType().Name}");
        }

        private void AttackWithChosenMove(IPokemon pokemon, int chosenMove)
        {
            IMove move = pokemon.Moves[chosenMove];
            Console.WriteLine($"{pokemon.GetType().Name} used {move.GetType().Name}!");

            if (_pokemonOneHasMoved)
            {
                //Change the way we access the damage property?
                PokemonOne.ReceiveDamage(move.Damage);

                Console.WriteLine($"{PokemonOne.GetType().Name} received {move.Damage} damage!");

                Thread.Sleep(1000);

                _pokemonOneHasMoved = false;
            }
            else
            {
                PokemonTwo.ReceiveDamage(move.Damage);

                Console.WriteLine($"{PokemonTwo.GetType().Name} received {move.Damage} damage!");

                Thread.Sleep(1000);

                _pokemonOneHasMoved = true;
            }
        }

        private void FinishBattle(IPokemon faintedPokemon, IPokemon standingPokemon)
        {
            Console.WriteLine($"{faintedPokemon.GetType().Name} fainted!");
            Console.WriteLine("");
            Console.WriteLine($"{standingPokemon.GetType().Name} wins!");
        }

        //two pokemon.
        // "AI" for the enemy pokemon. (rnd.next(1, moves.Count)) - Choose the movement randomly.
        //a round, by a move from the first player and ending with a move from the second player.
    }
}