using System;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class ConsoleBattleInfoPokemon
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
            //TODO: Show status ailments in front of the Pokémon's HP.
            ConsoleUtils.TrainerAction<EnemyAction>($"{enemyPokemon.GetType().Name} - HP: {enemyPokemon.CurrentHealthPoints}/{enemyPokemon.HealthPoints}");
            ConsoleUtils.TrainerAction<PlayerAction>($"{playerPokemon.GetType().Name} - HP: {playerPokemon.CurrentHealthPoints}/{playerPokemon.HealthPoints}");
        }

        public static void ShowChosenPokemonIsNotAvailable() 
            => Console.WriteLine("The chosen pokemon is not available, please select another!");

        public static void ShowChosenPokemonIsAlreadyInBattle()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("The chosen pokemon is already in battle!");
            ConsoleUtils.ClearScreen();
        }
    }
}
