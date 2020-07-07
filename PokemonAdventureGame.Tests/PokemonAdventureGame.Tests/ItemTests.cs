using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Items;
using System.Linq;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class ItemTests
    {
        [Fact]
        public void ShouldReturnAnItem() => Assert.NotNull(ItemFactory.CreateItem<Potion>());

        [Theory]
        [InlineData(10000)]
        [InlineData(1)]
        [InlineData(100)]
        public void ShouldReturnAListWithNonNullItems(int numberOfItemsToCreate)
        {
            var items = ItemFactory.CreateItems<Potion>(numberOfItemsToCreate);
            Assert.Equal(numberOfItemsToCreate, items.Count());
        }
    }
}
