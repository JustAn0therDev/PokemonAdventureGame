using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Electric
{
    public class Thunderbolt : IMove
    {
        public Type Type { get => Type.ELECTRIC; } 
        public int Damage { get => 15; }
        public int PowerPoints { get => 35; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Thunderbolt()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
