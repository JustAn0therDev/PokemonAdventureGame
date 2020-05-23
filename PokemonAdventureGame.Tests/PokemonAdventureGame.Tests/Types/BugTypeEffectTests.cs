using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class BugTypeEffectTests 
    {
        private readonly Type bugType = Type.BUG;

        [Fact]
        public void BugAgainstFireShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.FIRE);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstGrassShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.GRASS);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstPoisonShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.POISON);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstFlyingShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.FLYING);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstPsychicShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.PSYCHIC);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstGhostShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.GHOST);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstDarkShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.DARK);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstSteelShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.STEEL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void BugAgainstFairyShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(bugType, Type.FAIRY);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }
    }
}