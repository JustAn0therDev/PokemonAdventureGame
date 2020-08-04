using System;
using System.Linq;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfo
    {
        public static void ShowAvailableCommandsOnConsole()
        {
            Console.WriteLine($"{(int)Command.ATTACK}: {Command.ATTACK}");
            Console.WriteLine($"{(int)Command.SWITCH_POKEMON}: {Command.SWITCH_POKEMON.ToString().Replace("_", " ")}");
            Console.WriteLine($"{(int)Command.ITEMS}: {Command.ITEMS}");
        }

        public static void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose your attack!");
            for (int i = 0; i < pokemon.Moves.Count; i++)
                Console.WriteLine($"{i}: {pokemon.Moves[i].GetType().Name} | PP: {pokemon.Moves[i].CurrentPowerPoints}");
        }

        public static void WriteAllAvailableItemsOnConsole(ITrainer player)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose an item!");
            for (int i = 0; i < player.Items.Count; i++)
                Console.WriteLine($"{i}: {player.Items.ElementAt(i).Key} - Remaining: {player.Items.ElementAt(i).Value.Count}");
        }
    }
}