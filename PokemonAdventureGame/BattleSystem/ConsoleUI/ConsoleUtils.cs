using System;
using System.Threading;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleUtils
    {
        public readonly static int ONE_SECOND_IN_MILISSECONDS = 1000;
        public readonly static int TWO_SECONDS_IN_MILISSECONDS = 2000;
        public readonly static int FOUR_SECONDS_IN_MILISSECONDS = 4000;
        public readonly static int FIVE_SECONDS_IN_MILISSECONDS = 5000;

        public static void ResetConsoleColors() => Console.ResetColor();
        public static void WaitOneSecond() => Thread.Sleep(ONE_SECOND_IN_MILISSECONDS);
        public static void WaitTwoSeconds() => Thread.Sleep(TWO_SECONDS_IN_MILISSECONDS);
        public static void WaitFourSeconds() => Thread.Sleep(FOUR_SECONDS_IN_MILISSECONDS);
        public static void WaitFiveSeconds() => Thread.Sleep(FIVE_SECONDS_IN_MILISSECONDS);
        public static void ClearScreen() => Console.Clear();
        public static void SkipLine() => Console.WriteLine();
        public static void EndProgram() => Environment.Exit(0);
        public static void TrainerAction<T>(string actionMessage)
        {
            Console.ForegroundColor = typeof(T) == typeof(PlayerAction) ? ConsoleColor.Green : ConsoleColor.DarkRed;
            Console.WriteLine(actionMessage);
            SkipLine();
            ResetConsoleColors();
        }

        public static void ShowMessageBetweenEmptyLines(string message)
        {
            SkipLine();
            Console.WriteLine(message);
            SkipLine();
        }

        public static void EnemyPhraseBeforeBattle(string enemyPhrase)
        {
            ClearScreen();
            TrainerAction<EnemyAction>(enemyPhrase);
            WaitFourSeconds();
            ClearScreen();
        }

        public static void ShowMessageAndWaitOneSecond(string message)
        {
            Console.WriteLine(message);
            WaitOneSecond();
        }

        public static void ShowMessageAndWaitTwoSeconds(string message)
        {
            Console.WriteLine(message);
            WaitTwoSeconds();
        }

        public static int GetPlayerChosenIndex(string userInput)
        {
            ClearScreen();
            return int.TryParse(userInput, out int chosenIndex) ? chosenIndex : -1;
        }
    }
}