using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Types;
using Xunit;

namespace PokemonAdventureGame.Tests.Types 
{
    public class DragonTypeEffectTypes 
    {
        private readonly Type dragonType = Type.DRAGON;

        [Fact]
        public void DragonAgainstDragonShouldBeSuperEffective() 
        {
            TypeEffect typeEffect = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(dragonType, dragonType);
            Assert.Equal(TypeEffect.SUPER_EFFECTIVE, typeEffect);
        }
    }
}