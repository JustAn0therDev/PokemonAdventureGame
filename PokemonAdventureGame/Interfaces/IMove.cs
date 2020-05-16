using System;

namespace PokemonAdventureGame
{
    public interface IMove
    {
        Type Type { get; }
        int Damage { get; }
        int PowerPoints { get; }
        //int Ailment { get; set; }
    }
}