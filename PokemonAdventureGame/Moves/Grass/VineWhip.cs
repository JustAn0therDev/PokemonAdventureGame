using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Grass
{
    public class VineWhip : IMove
    {
        public Type Type { get => Type.GRASS; }
        public int Damage { get => 30; }
        public int PowerPoints { get => 30; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public VineWhip()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
