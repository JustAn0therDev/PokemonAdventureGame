using Xunit;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.Interfaces;
using System.Linq;

namespace PokemonAdventureGame.Tests
{
    public class TrainerFactoryTests
    {
        [Fact]
        public void TrainerPlayerCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Player>());

        [Fact]
        public void TrainerGaryCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Gary>());

        [Fact]
        public void TrainerShouldNotHaveAnyPokemonLeftToBattle()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Player>();
            trainer.PokemonTeam.ForEach(pkmn => pkmn.SetAsFainted());
            Assert.False(trainer.HasAvailablePokemon());
        }

        [Fact]
        public void ShouldSetChosenPokemonAsCurrent()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Gary>();
            trainer.PokemonTeam.First().SetAsCurrent();
            Assert.True(trainer.PokemonTeam.First().Current);
        }
    }
}
