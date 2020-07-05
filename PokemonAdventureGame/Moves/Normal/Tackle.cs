using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Tackle : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 10; }
        public int PowerPoints { get => 30; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Tackle()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
