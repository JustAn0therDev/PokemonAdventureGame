using PokemonAdventureGame.Factories;
using Xunit;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Types;
using PokemonAdventureGame.Moves.Ghost;

namespace PokemonAdventureGame.Tests
{
    public class TypeComparisonTests
    {
        [Fact]
        public void GhostTypePokemonShouldNotTakeDamageFromPhysicalAttack() 
        {
            IPokemon ghostTypePokemon = PokemonFactory.CreatePokemon<Gengar>();
            IMove move = new Tackle();

            Assert.True(TypeComparer.PokemonTypeDoesNotMakeContactWithMove(ghostTypePokemon.Types, move));
        }

        [Fact]
        public void GhostTypePokemonShouldTakeDamageFromSpecialAttack() 
        {
            IPokemon ghostTypePokemon = PokemonFactory.CreatePokemon<Gengar>();
            IMove move = new ShadowBall();

            Assert.False(TypeComparer.PokemonTypeDoesNotMakeContactWithMove(ghostTypePokemon.Types, move));
        }
    }
}
