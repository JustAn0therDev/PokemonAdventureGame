using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Normal
{
    public class DoubleHit : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 35; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public DoubleHit()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
