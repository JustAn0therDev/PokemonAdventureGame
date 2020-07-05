using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Fighting
{
    public class MegaKick : IMove
    {
        public Type Type { get => Type.FIGHTING; }
        public int Damage { get => 40; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => false; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public MegaKick()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
