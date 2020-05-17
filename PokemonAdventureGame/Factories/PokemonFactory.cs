using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Factories
{
    public static class PokemonFactory
    {
        public static IPokemon CreatePokemon<T>() where T : IPokemon, new()
        {
            T pokemon = new T();
            pokemon.InitializePokemonProperties();
            return pokemon;
        }
    }
}
