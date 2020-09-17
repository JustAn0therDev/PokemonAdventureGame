using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Factories
{
    public class TrainerFactory
    {
        public static ITrainer CreateTrainer<T>() where T : ITrainer, new()
        {
            T trainer = new T();
            trainer.InitializeTrainer();
            return trainer;
        }
    }
}
