using System;
using System.Linq;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfo
    {
        public static readonly ConsoleColor AttackColor = ConsoleColor.White;
        public static readonly ConsoleColor SpecialAttackColor = ConsoleColor.Yellow;
        public static readonly ConsoleColor UnavailableMove = ConsoleColor.DarkGray;

        public static void ShowAvailableCommandsOnConsole()
        {
            Console.WriteLine($"{(int)Command.ATTACK}: {Command.ATTACK}");
            Console.WriteLine($"{(int)Command.SWITCH_POKEMON}: {Command.SWITCH_POKEMON.ToString().Replace("_", " ")}");
            Console.WriteLine($"{(int)Command.ITEMS}: {Command.ITEMS}");
        }

        public static void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose your attack!");

            ConsoleColor previousColor = Console.ForegroundColor;

            int maxMoveNameLength = pokemon.Moves.Max(m => m.GetType().Name.Length);
            int maxTypeNameLength = pokemon.Moves.Max(m => m.Type.ToString().Length) + 2;
            for (int i = 0; i < pokemon.Moves.Count; i++)
            {
                var move = pokemon.Moves.ElementAtOrDefault(i);
                string typeName = $"[{move.Type}]".PadRight(maxTypeNameLength);
                string moveName = move.GetType().Name.PadRight(maxMoveNameLength);

                Console.ForegroundColor = move.Special ? SpecialAttackColor : AttackColor;
                if (move.CurrentPowerPoints <= 0)
                {
                    Console.ForegroundColor = UnavailableMove;
            }

                Console.WriteLine($"{i}: {typeName} {moveName}   {move.CurrentPowerPoints}/{move.PowerPoints}");
        }

            Console.ForegroundColor = previousColor;
        }

        public static void WriteAllAvailableItemsOnConsole(ITrainer player)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose an item!");

            for (int i = 0; i < player.Items.Count; i++)
            {
                Console.WriteLine($"{i}: {player.Items.ElementAtOrDefault(i).Key} - Remaining: {player.Items.ElementAtOrDefault(i).Value.Count()}");
            }
        }
    }
}
