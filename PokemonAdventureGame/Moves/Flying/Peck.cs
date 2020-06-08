using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Flying
{
    public class Peck : IMove
    {
        public Type Type { get => Type.FLYING; }
        public int Damage { get => 20; }
        public int PowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Peck()
        {
            PowerPoints = 30;
        }
    }
}
