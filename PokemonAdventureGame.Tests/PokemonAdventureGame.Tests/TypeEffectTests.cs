using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class TypeEffectTests 
    {
        [Fact]
        public void WaterAgainstFireShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(Enums.Type.WATER, Enums.Type.FIRE);
            Assert.Equal(typeEffect, TypeEffect.SUPER_EFFECTIVE);
        }

        [Fact]
        public void WaterAgainstGrassShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(Enums.Type.WATER, Enums.Type.GRASS);
            Assert.Equal(typeEffect, TypeEffect.NOT_VERY_EFFECTIVE);
        }

        [Fact]
        public void WaterAgainstGroundShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(Enums.Type.WATER, Enums.Type.GROUND);
            Assert.Equal(typeEffect, TypeEffect.SUPER_EFFECTIVE);
        }

        [Fact]
        public void WaterAgainstRockShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(Enums.Type.WATER, Enums.Type.ROCK);
            Assert.Equal(typeEffect, TypeEffect.SUPER_EFFECTIVE);
        }
        
    }
}