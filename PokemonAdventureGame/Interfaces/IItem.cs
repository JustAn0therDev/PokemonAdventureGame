using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Interfaces
{
    public interface IItem
    {
        bool TryToUseItemOnPokemon(IPokemon targetPokemon);
    }
}
