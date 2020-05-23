using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Types;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class GhostTypeEffectTests 
    {
        private readonly Type ghostType = Type.GHOST;

        [Fact]
        public void GhostAgainstGhostShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(ghostType, ghostType);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GhostAgainstNormalShouldBeNotVeryEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(ghostType, Type.NORMAL);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GhostAgainstFightingShouldBeNotVeryEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(ghostType, Type.FIGHTING);
            Assert.Equal(TypeEffect.NOT_VERY_EFFECTIVE, typeEffect);
        }

        [Fact]
        public void GhostAgainstPsychicShouldBeSuperEffective()
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(ghostType, Type.PSYCHIC);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }
    }
}