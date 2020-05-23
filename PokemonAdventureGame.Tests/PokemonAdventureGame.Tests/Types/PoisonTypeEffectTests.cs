using PokemonAdventureGame.Types;
using PokemonAdventureGame.Enums;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class PoisonTypeEffectTests 
    {
        private readonly Type poisonType = Type.POISON;

        [Fact]
        public void PoisonAgainstGrassShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.GRASS);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstPoisonShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.POISON);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstGroundShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.GROUND);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstRockShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.ROCK);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstGhostShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.GHOST);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstSteelShouldBeImmune()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.STEEL);
            Assert.Equal(TypeEffect.IMMUNE, typeEffect);
        }

        [Fact]
        public void PoisonAgainstFairyShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(poisonType, Type.FAIRY);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }
    }
}