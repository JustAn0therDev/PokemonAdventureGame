using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Leer : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => new List<StatusMove> { StatusMove.ATTACK_DOWN }; }
        public StatusMoveTarget? MoveTarget { get => StatusMoveTarget.TARGET; }

        public Leer()
        {
            PowerPoints = 35;
        }
    }
}
