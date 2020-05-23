using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Types;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class GroundTypeEffectTests 
    {
        private readonly Type groundType = Type.GROUND;

        [Fact]
        public void GroundAgainstFireShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.FIRE);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstElectricShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.ELECTRIC);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstGrassShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.GRASS);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstPoisonShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.POISON);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstFlyingShouldBeImmune()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.FLYING);
            Assert.Equal(TypeEffect.IMMUNE, typeEffect);
        }

        [Fact]
        public void GroundAgainstBugShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.BUG);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstRockShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.ROCK);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GroundAgainstSteelShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(groundType, Type.STEEL);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }
    }
}