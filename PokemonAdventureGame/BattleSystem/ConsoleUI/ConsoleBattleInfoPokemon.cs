using System;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfoPokemon
    {
        public static void ShowPokemonUsedMove(IPokemon pokemon, string moveName)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemon.GetType().Name} used {moveName}!");
            ConsoleUtils.SkipLine();
        }

        public static void ShowPokemonReceivedDamage(IPokemon pokemon, int damage)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemon.GetType().Name} took {damage} damage!");
            ConsoleUtils.SkipLine();
        }

        public static void ShowBothPokemonStats(IPokemon playerPokemon, IPokemon enemyPokemon)
        {
            // TODO: Show status ailments in front of the Pokémon's HP.
            // this should be developed along with the ailment system
            ConsoleUtils.TrainerAction<EnemyAction>($"{enemyPokemon.GetType().Name} - HP: {enemyPokemon.CurrentHealthPoints}/{enemyPokemon.TotalHealthPoints}");
            ConsoleUtils.TrainerAction<PlayerAction>($"{playerPokemon.GetType().Name} - HP: {playerPokemon.CurrentHealthPoints}/{playerPokemon.TotalHealthPoints}");
        }

        public static void ShowChosenPokemonIsNotAvailable() 
            => Console.WriteLine("The chosen pokemon is not available, please select another!");

        public static void ShowChosenPokemonIsAlreadyInBattle()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("The chosen pokemon is already in battle!");
            ConsoleUtils.ClearScreen();
        }

        public static void ShowInvalidCommandMessage()
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds("Invalid command. Please select another!");
            ConsoleUtils.ClearScreen();
        }
    }
}
