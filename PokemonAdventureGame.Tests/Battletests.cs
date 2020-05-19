using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class BattleTests
    {
        [Theory]
        [InlineData(3)]
        public void ShouldNotBeNull(object something)
        {
            Assert.NotNull(something);
        }
    }
}
