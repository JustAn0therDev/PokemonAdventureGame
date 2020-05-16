using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Moves.Normal
{
    public class TailWhip : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get => 40; }
    }
}
