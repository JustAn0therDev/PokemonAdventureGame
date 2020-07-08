using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class BattleTests
    {
        private static readonly ITrainer _trainer = TrainerFactory.CreateTrainer<Player>();
        private static readonly ITrainer _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();

        [Fact]
        public void BattleObjectShouldNotBeNull()
        {
            using var battle = new Battle(_trainer, _enemyTrainer);
            Assert.NotNull(battle);
        }
    }
}
