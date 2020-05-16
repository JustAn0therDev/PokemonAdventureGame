using System;
using System.Collections.Generic;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Electric;

namespace PokemonAdventureGame.Factories
{
    public static class PokemonFactory
    {
        //Create an IPokemon interface and separate each pokemon in different classes.
        public static Pokemon CreatePokemonStatsByPokedexIndex(int pokemonIndex)
        {
            return pokemonIndex switch
            {
                //Pikachu
                23 => new Pokemon(35, 55, 30, 50, 40, 90, new HashSet<IMove>() { new TailWhip(), new Thunderbolt(), new Tackle() }, new HashSet<Enums.Type>() { Enums.Type.ELECTRIC }),
                //Eevee
                133 => new Pokemon(55, 55, 50, 45, 65, 55, new HashSet<IMove>() { new Leer(), new Tackle() }, new HashSet<Enums.Type>() { Enums.Type.NORMAL }),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
