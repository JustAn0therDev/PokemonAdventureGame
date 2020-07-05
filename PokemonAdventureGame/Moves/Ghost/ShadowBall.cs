using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Ghost
{
    public class ShadowBall : IMove
    {
        public Type Type { get => Type.GHOST; }
        public int Damage { get => 30; }
        public int PowerPoints { get => 35; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public ShadowBall()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
