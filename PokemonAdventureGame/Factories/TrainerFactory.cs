using PokemonAdventureGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
