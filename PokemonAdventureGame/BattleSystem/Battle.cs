using System;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle
    {
        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
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
            Console.ResetColor();
        }

        //Make the PokemonOneMove and PokemonTwoMove circle around each other until one of them has it's HP set to 0.



        //Can I NOT repeat code here? 
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

            CheckChosenMove(chosenMove);
        }

        public void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            for (int i = 0; i < pokemon.Moves.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {pokemon.Moves[i].GetType().Name}");
            }
        }

        public void CheckChosenMove(int chosenMove)
        {

        }

        //two pokemon.
        // "AI" for the enemy pokemon. (rnd.next(1, moves.Count)) - Choose the movement randomly.
        //a round, by a move from the first player and ending with a move from the second player.
    }
}
