using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Interfaces
{
    public interface IPokedex
    {
        Dictionary<int, string> PokedexDictionary { get; set; }
    }
}
