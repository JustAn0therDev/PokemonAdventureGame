using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Water
{
    public class Surf : IMove
    {
        public Type Type { get => Type.WATER; }
        public int Damage { get => 30; }
        public int PowerPoints { get => 30; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Surf()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
