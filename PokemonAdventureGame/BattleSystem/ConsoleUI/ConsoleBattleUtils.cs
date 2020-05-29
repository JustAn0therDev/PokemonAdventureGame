using System;
using System.Threading;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleUtils
    {
        public static void ResetConsoleColors()
            => Console.ResetColor();
        public static void WaitOneSecond() => Thread.Sleep(1000);
        public static void WaitTwoSeconds() => Thread.Sleep(2000);
        public static void ClearScreen() => Console.Clear();
        public static void SkipLine() => Console.WriteLine();
        public static void TrainerAction<T>(string actionMessage)
        {
            Console.ForegroundColor = typeof(T) == typeof(PlayerMovement) ? ConsoleColor.Green : ConsoleColor.DarkRed;
            Console.WriteLine(actionMessage);
            SkipLine();
            ResetConsoleColors();
        }
    }
}