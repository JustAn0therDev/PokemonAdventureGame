using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class RockTypeEffectTests 
    {
        private readonly Type rockType = Type.ROCK;

        [Fact]
        public void RockAgainstFireShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.FIRE);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstIceShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.ICE);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstFightingShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.FIGHTING);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstFlyingShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.FLYING);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstGroundShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.GROUND);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstBugShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.BUG);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void RockAgainstSteelShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(rockType, Type.STEEL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }
    }
}