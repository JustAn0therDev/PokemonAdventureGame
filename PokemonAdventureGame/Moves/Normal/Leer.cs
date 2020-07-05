using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Leer : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => new List<StatusMove> { StatusMove.ATTACK_DOWN }; }
        public StatusMoveTarget? MoveTarget { get => StatusMoveTarget.TARGET; }

        public Leer()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
