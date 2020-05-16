using System;
using System.Collections.Generic;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Electric;

namespace PokemonAdventureGame.Factories
{
    public static class PokemonFactory
    {
        //Criar IPokemon interface e separar todos os pokemon em classes diferentes.
        public static Pokemon CreatePokemonStatsByIndex(int pokemonIndex)
        {
            return pokemonIndex switch
            {
                //Pikachu
                23 => new Pokemon(35, 55, 30, 50, 40, 90, new HashSet<IMove>() { new TailWhip(), new Thunderbolt(), new Tackle() }, new HashSet<Type>() { Type.ELECTRIC }),
                //Eevee
                133 => new Pokemon(55, 55, 50, 45, 65, 55, new HashSet<IMove>() { new Leer(), new Tackle() }, new HashSet<Type>() { Type.NORMAL }),
                _ => throw new NotImplementedException(),
            };
        }

        public static Pokemon GetPokemonByIndex(int pokemonIndex) 
            => CreatePokemonStatsByIndex(pokemonIndex);
    }
}
