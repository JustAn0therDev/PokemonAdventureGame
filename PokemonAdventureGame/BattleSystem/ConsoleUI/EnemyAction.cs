using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class EnemyAction
    {
        public static void EnemyTrainerSendsPokemon(ITrainer trainer)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<EnemyAction>($"{trainer.GetType().Name} sent out {trainer.GetCurrentPokemon()?.GetType().Name}!");
            ConsoleUtils.SkipLine();
            ConsoleUtils.ResetConsoleColors();
        }

        public static void EnemyTrainerDrawsbackPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<EnemyAction>($"{pokemon?.GetType().Name}, come back!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }
    }
}