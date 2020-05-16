using System;
using System.Collections.Generic;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Electric;

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
