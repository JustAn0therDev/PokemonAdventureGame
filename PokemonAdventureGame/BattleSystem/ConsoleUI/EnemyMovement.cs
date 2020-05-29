using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class EnemyMovement 
    {
        public void EnemyTrainerSendsPokemon(ITrainer trainer, IPokemon pokemon)
        {
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.TrainerAction<EnemyMovement>($"{trainer.GetType().Name} sent out {pokemon.GetType().Name}!");
            ConsoleBattleUtils.SkipLine();
            ConsoleBattleUtils.ResetConsoleColors();
        }

        public void EnemyTrainerChangesPokemon(IPokemon pokemon)
        {
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.TrainerAction<PlayerMovement>($"{pokemon.GetType().Name}, come back!");
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.ClearScreen();
        }
    }
}