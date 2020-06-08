using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Flying
{
    public class WingAttack : IMove
    {
        public Type Type { get => Type.FLYING; }
        public int Damage { get => 30; }
        public int PowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public WingAttack()
        {
            PowerPoints = 30;
        }
    }
}
