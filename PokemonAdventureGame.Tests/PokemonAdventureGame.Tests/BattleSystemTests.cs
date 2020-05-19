using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Factories;
using System;
using Xunit;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.BattleSystem;

namespace PokemonAdventureGame.Tests
{
    public class BattleTests
    {
        private static readonly ITrainer _trainer = TrainerFactory.CreateTrainer<Player>();
        private static readonly ITrainer _enemyTrainer = TrainerFactory.CreateTrainer<Gary>();

        [Fact]
        public void BattleObjectShouldNotBeNull()
        {
            Battle battle = new Battle(_trainer, _enemyTrainer);
            Assert.NotNull(battle);
        }
    }
}
