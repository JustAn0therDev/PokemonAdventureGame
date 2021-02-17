using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.Items;
using PokemonAdventureGame.Pokemon;
using System.Linq;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class ItemTests
    {
        private const int POTION_INDEX_IN_TRAINER_INVENTORY = 0;
        private static readonly ITrainer _player = TrainerFactory.CreateTrainer<Player>();

        [Fact]
        public void ShouldReturnAnItem() => Assert.NotNull(ItemFactory.CreateItem<Potion>());

        [Theory]
        [InlineData(10000)]
        [InlineData(1)]
        [InlineData(100)]
        public void ShouldReturnAListWithExpectedNumberOfItems(int numberOfItemsToCreate)
        {
            var items = ItemFactory.CreateItems<Potion>(numberOfItemsToCreate);
            Assert.Equal(numberOfItemsToCreate, items?.Count());
        }

        [Fact]
        public void EnemyTrainerShouldNotHaveAnyItems()
        {
            ITrainer brock = TrainerFactory.CreateTrainer<Brock>();
            Assert.True(brock?.Items == null);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(26)]
        public void ItemShouldHealPokemon(int damageTaken)
        {
            IPokemon onix = PokemonFactory.CreatePokemon<Onix>();
            onix.CurrentHealthPoints -= damageTaken;

            bool pokemonIsEligibleForPotionUse = (bool)_player?.Items
                .ElementAt(POTION_INDEX_IN_TRAINER_INVENTORY).Value[POTION_INDEX_IN_TRAINER_INVENTORY]
                .TryToUseItemOnPokemon(onix);
            Assert.True(pokemonIsEligibleForPotionUse);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(9)]
        public void ItemShouldNotHealPokemonMoreThanItsHealthPointsProperty(int damageTaken)
        {
            IPokemon onix = PokemonFactory.CreatePokemon<Onix>();
            onix.CurrentHealthPoints -= damageTaken;

            _player?.Items
                .ElementAt(POTION_INDEX_IN_TRAINER_INVENTORY).Value[POTION_INDEX_IN_TRAINER_INVENTORY]
                .TryToUseItemOnPokemon(onix);
            Assert.True(onix.CurrentHealthPoints == onix.TotalHealthPoints);
        }

        [Fact]
        public void ItemShouldNotHealPokemonWithFullHP()
        {
            IPokemon onix = PokemonFactory.CreatePokemon<Onix>();

            bool pokemonIsEligibleForPotionUse = (bool)_player?.Items
                .ElementAt(POTION_INDEX_IN_TRAINER_INVENTORY).Value[POTION_INDEX_IN_TRAINER_INVENTORY]
                .TryToUseItemOnPokemon(onix);
            Assert.False(pokemonIsEligibleForPotionUse);
        }
    }
}
