using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Ice
{
    public class Blizzard : IMove
    {
        public Type Type { get => Type.ICE; }
        public int Damage { get => 40; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Blizzard()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
