using System;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle
    {
        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
        //Might be better to change this implementation afterwards...
        //And it might be changed by the help of a "Console manager" class
        private bool _pokemonOneHasMoved { get; set; } 
        public IPokemon PokemonOne { get; set; }
        public IPokemon PokemonTwo { get; set; }

        public Battle(IPokemon pokemonOne, IPokemon pokemonTwo)
        {
            PokemonOne = pokemonOne;
            PokemonTwo = pokemonTwo;
            StartBattle(); //Call it manually or keep it here?
        }

        public void StartBattle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("START BATTLE!!");
            Console.WriteLine(string.Empty);
            Console.ResetColor();
            ShowCurrentBattleStats();
        }

        //Since a lot of code might be repeated for each pokemon, we might want to separate it in different classes so we can manage the console 
        //in a different class for showing the "UI" to the user while we manage the whole state of the current happening pokemon battle here.
        //TODO: While loop to check if any pokemon in the battle had it's HP dropped to 0.
        public void ShowCurrentBattleStats()
        {
            Console.WriteLine($"{PokemonOne.GetType().Name} - HP: {PokemonOne.CurrentHealthPoints}/{PokemonOne.HealthPoints}");
            Console.WriteLine($"{PokemonTwo.GetType().Name} - HP: {PokemonTwo.CurrentHealthPoints}/{PokemonTwo.HealthPoints}");
            Console.WriteLine("");
        }

        //Make the PokemonOneMove and PokemonTwoMove circle around each other until one of them has it's HP set to 0.

        //Can we NOT repeat code here? 
        public void PokemonOneMove(Command command)
        {
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

        public void PokemonTwoMove(Command command)
        {
            switch (command)
            {
                case Command.ATTACK:
                    ShowPokemonAvailableAttacks(PokemonTwo);
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
        public void ShowPokemonAvailableAttacks(IPokemon pokemon)
        {
            int chosenMove = 0;

            Console.WriteLine("Choose your attack!");

            while (chosenMove == 0 || chosenMove > LIMIT_OF_MOVES_PER_POKEMON)
            {
                WriteAllAvailableAttacksOnConsole(pokemon);
                int.TryParse(Console.ReadLine(), out chosenMove);
                Console.Clear();
            }

            CheckChosenMove(pokemon, chosenMove);
        }

        public void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            for (int i = 0; i < pokemon.Moves.Count; i++)
                Console.WriteLine($"{i + 1}: {pokemon.Moves[i].GetType().Name}");
        }

        public void CheckChosenMove(IPokemon pokemon, int chosenMove)
        {
            IMove move = pokemon.Moves[chosenMove - 1];
            Console.WriteLine($"{pokemon.GetType().Name} used {move.GetType().Name}!");

            if (_pokemonOneHasMoved)
            {
                //Change the way we access the damage property?
                PokemonOne.ReceiveDamage(move.Damage);

                Console.WriteLine($"{PokemonOne.GetType().Name} received {move.Damage} damage!");
            }
            else
            {
                PokemonTwo.ReceiveDamage(move.Damage);

                Console.WriteLine($"{PokemonTwo.GetType().Name} received {move.Damage} damage!");

                _pokemonOneHasMoved = true;
            }

            Console.Clear();
            ShowCurrentBattleStats();
        }

        //two pokemon.
        // "AI" for the enemy pokemon. (rnd.next(1, moves.Count)) - Choose the movement randomly.
        //a round, by a move from the first player and ending with a move from the second player.
    }
}