using PokemonAdventureGame.Interfaces;
using System;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class ConsoleBattleInfoTrainer
    {
        public static void ShowAllTrainersPokemon(ITrainer trainer)
        {
            for (int i = 0; i < trainer.PokemonTeam.Count; i++)
            {
                Console.WriteLine(
                    $"{i} - {trainer.PokemonTeam[i].Pokemon.GetType().Name} - HP: {trainer.PokemonTeam[i].Pokemon.CurrentHealthPoints}/{trainer.PokemonTeam[i].Pokemon.HealthPoints}"
                    );
            }
        }

        public static void ShowPlayerThereAreNoPokemonLeftToSwitch()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("There are no other pokemon left to battle!");
            ConsoleUtils.ClearScreen();
        }

        public static void TrainerHasNoPokemonLeft(ITrainer trainer)
        {
            ConsoleUtils.ClearScreen();
            ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} has no other pokemon left to battle...");
        }

        public static void TrainerDrawsbackPokemon(IPokemon pokemon, in EnemyAction enemyAction, in PlayerAction playerAction, bool isEnemyTrainer = false)
        {
            if (isEnemyTrainer)
                enemyAction.EnemyTrainerDrawsbackPokemon(pokemon);
            else
                playerAction.PlayerDrawsbackPokemon(pokemon);
        }

        public static void EnemyTrainerWantsToBattle(ITrainer enemyTrainer)
        {
            Console.WriteLine($"{enemyTrainer.GetType().Name} wants to battle!");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        public static void ShowTrainerWins(ITrainer trainer)
           => ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} wins!");
    }
}