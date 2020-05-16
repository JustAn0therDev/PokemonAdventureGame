using System;
using System.Collections.Generic;
using System.Text;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Tackle : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 10; }
        public int PowerPoints { get => 30;  }
    }
}
