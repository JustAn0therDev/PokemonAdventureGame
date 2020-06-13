using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class EnemyAction
    {
        public void EnemyTrainerSendsPokemon(ITrainer trainer, IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<EnemyAction>($"{trainer.GetType().Name} sent out {pokemon.GetType().Name}!");
            ConsoleUtils.SkipLine();
            ConsoleUtils.ResetConsoleColors();
        }

        public void EnemyTrainerChangesPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<EnemyAction>($"{pokemon.GetType().Name}, come back!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }
    }
}