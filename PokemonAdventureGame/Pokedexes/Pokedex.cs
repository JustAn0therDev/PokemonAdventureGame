using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokedexes
{
    //Will I use this?
    public class Pokedex : IPokedex
    {
        private Dictionary<int, string> _pokedexDictionary { get; set; }

        public Dictionary<int, string> PokedexDictionary
        {
            get => _pokedexDictionary;
            set
            {
                _pokedexDictionary = value;
            }
        }

        public void InitializePokedex()
        {
            _pokedexDictionary.Add(23, "Pikachu");
            _pokedexDictionary.Add(133, "Eevee");
        }
    }
}
