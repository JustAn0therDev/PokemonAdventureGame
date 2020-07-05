using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Normal
{
    public class Hyperbeam : IMove
    {
        public Type Type { get => Type.NORMAL; }
        public int Damage { get => 40; }
        public int PowerPoints { get => 5; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Hyperbeam()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
