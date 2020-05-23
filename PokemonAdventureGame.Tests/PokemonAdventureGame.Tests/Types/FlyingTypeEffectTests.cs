using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class FlyingTypeEffectTests 
    {
        private readonly Type flyingType = Type.FLYING;

        [Fact]
        public void FlyingAgainstElectricShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.ELECTRIC);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FlyingAgainstGrassShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.GRASS);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FlyingAgainstFightingShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.FIGHTING);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FlyingAgainstBugShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.BUG);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FlyingAgainstRockShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.ROCK);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FlyingAgainstSteelShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(flyingType, Type.STEEL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }
    }
}