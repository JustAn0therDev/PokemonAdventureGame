using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Ghost
{
    public class ShadowBall : IMove
    {
        public Enums.Type Type { get => Enums.Type.GHOST; }
        public int Damage { get => 30; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public ShadowBall()
        {
            PowerPoints = 35;
        }
    }
}
