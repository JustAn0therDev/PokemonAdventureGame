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
            Console.WriteLine($"{(int)Command.POKEMON_STATUS}: {Command.POKEMON_STATUS.ToString().Replace("_", " ")}");
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

        public static void WritePokemonStats(IPokemon pokemon)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            ConsoleUtils.ShowMessageBetweenEmptyLines($"[{string.Join(", ", pokemon.Types.Select(t => t.ToString().Replace("_", " ")))}] {pokemon.GetType().Name} stats:");

            Console.WriteLine($"HEALTH: {pokemon.TotalHealthPoints}");

            Console.ForegroundColor = AttackColor;
            Console.WriteLine($"ATTACK: {pokemon.AttackPoints}");
            Console.WriteLine($"DEFENSE: {pokemon.DefensePoints}");

            Console.ForegroundColor = SpecialAttackColor;
            Console.WriteLine($"SPECIAL ATTACK: {pokemon.SpecialAttackPoints}");
            Console.WriteLine($"SPECIAL DEFENSE: {pokemon.SpecialDefensePoints}");

            Console.ForegroundColor = previousColor;
            Console.WriteLine($"SPEED: {pokemon.SpeedPoints}");

            Console.WriteLine();
            Console.WriteLine("MOVES:");
            for (int i = 0; i < pokemon.Moves.Count; i++)
            {
                IMove move = pokemon.Moves.ElementAtOrDefault(i);

                Console.ForegroundColor = move.Special ? SpecialAttackColor : AttackColor;
                Console.WriteLine($"{i}: [{move.Type}] {move.GetType().Name}");
                Console.WriteLine($"   PP: {move.PowerPoints,2} | POWER: {move.Damage,3} | SPECIAL: {(move.Special ? "YES" : "NO")}");

                if (move.MoveTarget != null)
                {
                    Console.WriteLine($"   MOVE TARGET: {(move.MoveTarget.ToString().Replace("_", " "))}");
                }

                if (move.StatusMoves?.Any() == true)
                {
                    var statusMoveNames = move.StatusMoves
                        .Select(sm => sm.ToString().Replace("_", " "));
                    Console.WriteLine($"   MOVE STATUS: {string.Join(", ", statusMoveNames)}");
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = previousColor;
        }
    }
}
