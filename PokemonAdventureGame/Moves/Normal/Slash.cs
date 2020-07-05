using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Slash : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 30; }
        public int PowerPoints { get => 40; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Slash()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
