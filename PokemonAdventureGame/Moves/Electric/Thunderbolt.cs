using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Moves.Electric
{
    public class Thunderbolt : IMove
    {
        public Type Type { get => Type.ELECTRIC; } 
        public int Damage { get => 15; }
        public int PowerPoints { get => 35; }
    }
}
