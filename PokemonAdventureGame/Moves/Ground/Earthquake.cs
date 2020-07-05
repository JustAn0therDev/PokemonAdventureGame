using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Ground
{
    public class Earthquake : IMove
    {
        public Type Type { get => Type.GROUND; }
        public int Damage { get => 40; }
        public int PowerPoints { get => 20; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Earthquake()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
