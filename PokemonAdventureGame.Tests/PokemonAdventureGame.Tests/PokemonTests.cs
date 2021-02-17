using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class PokemonFactoryTests
    {
        [Fact]
        public void PikachuCreationShouldNotReturnNull()
            => Assert.NotNull(PokemonFactory.CreatePokemon<Pikachu>());

        [Fact]
        public void EeveeCreationShouldNotReturnNull()
            => Assert.NotNull(PokemonFactory.CreatePokemon<Eevee>());

        [Fact]
        public void PokemonShouldFaint()
        {
            IPokemon pokemon = PokemonFactory.CreatePokemon<Pikachu>();
            pokemon?.ReceiveDamage((int)pokemon?.TotalHealthPoints);
            Assert.True(pokemon?.HasFainted());
        }

        [Fact]
        public void PokemonShouldReceiveDamage()
        {
            IPokemon pokemon = PokemonFactory.CreatePokemon<Eevee>();
            pokemon?.ReceiveDamage(10);
            Assert.True(pokemon?.CurrentHealthPoints < pokemon.TotalHealthPoints);
        }
    }
}
