using Xunit;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.Interfaces;
using System.Linq;
using System;

namespace PokemonAdventureGame.Tests
{
    public class TrainerFactoryTests
    {
        [Fact]
        public void TrainerPlayerCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Player>());

        [Fact]
        public void TrainerBrockCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Brock>());

        [Fact]
        public void TrainerBrunoCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Bruno>());

        [Fact]
        public void TrainerMaryAnnCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<MaryAnn>());

        [Fact]
        public void TrainerBlueCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Blue>());

        [Fact]
        public void TrainerLanceCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Lance>());

        [Fact]
        public void TrainerRedCreationShouldNotReturnNull()
            => Assert.NotNull(TrainerFactory.CreateTrainer<Red>());

        [Fact]
        public void TrainerShouldNotHaveAnyPokemonLeftToBattle()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Player>();
            trainer?.PokemonTeam?.ForEach(pkmn => pkmn?.SetAsFainted());
            Assert.False(trainer?.HasAvailablePokemon());
        }

        [Fact]
        public void ShouldSetChosenPokemonAsCurrent()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Blue>();
            trainer?.PokemonTeam?.FirstOrDefault()?.SetAsCurrent();
            Assert.True(trainer.PokemonTeam?.FirstOrDefault()?.Current);
        }

        [Fact]
        public void PlayerShouldNotHaveDialogues()
        {
            ITrainer player = TrainerFactory.CreateTrainer<Player>();
            Assert.Throws<NotImplementedException>(() => player?.ShowTrainerDialogue());
            Assert.Throws<NotImplementedException>(() => player?.ShowFinalDialogueForLoss());
            Assert.Throws<NotImplementedException>(() => player?.ShowFinalDialogueForVictory());
        }
    }
}
