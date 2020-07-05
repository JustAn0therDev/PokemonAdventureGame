using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;


namespace PokemonAdventureGame.Moves.Ghost
{
    public class ShadowPunch : IMove
    {
        public Type Type { get => Type.GHOST; }
        public int Damage { get => 25; }
        public int PowerPoints { get => 30; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public ShadowPunch()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
