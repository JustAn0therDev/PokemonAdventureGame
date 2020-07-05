using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Grass
{
    public class SolarBeam : IMove
    {
        public Type Type { get => Type.GRASS; }
        public int Damage { get => 40; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public SolarBeam()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
