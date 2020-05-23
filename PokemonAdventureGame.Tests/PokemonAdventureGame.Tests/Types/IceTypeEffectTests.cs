using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class IceTypeEffectTests 
    {
        private readonly Type iceType = Type.ICE;

        [Fact]
        public void IceAgainstFireShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.FIRE);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstWaterShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.WATER);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstGrassShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.GRASS);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstIceShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.ICE);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstGroundShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.GROUND);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstFlyingShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.FLYING);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstDragonShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.DRAGON);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void IceAgainstSteelShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(iceType, Type.STEEL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }
    }
}