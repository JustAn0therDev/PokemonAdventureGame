using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Types;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class FairyTypeEffectTypes 
    {
        private readonly Type fairyType = Type.FAIRY;

        [Fact]
        public void FairyAgainstDragonShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.DRAGON);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FairyAgainstFireShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.FIRE);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FairyAgainstFightingShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.FIGHTING);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FairyAgainstPoisonShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.POISON);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FairyAgainstDarkShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.DARK);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void FairyAgainstSteelShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(fairyType, Type.STEEL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }
    }
}