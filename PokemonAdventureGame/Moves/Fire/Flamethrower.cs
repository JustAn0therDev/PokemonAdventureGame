using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Fire
{
    public class Flamethrower : IMove
    {
        public Type Type { get => Type.FIRE; }
        public int Damage { get => 35; }
        public int PowerPoints { get => 10; }
        public int CurrentPowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Flamethrower()
        {
            CurrentPowerPoints = PowerPoints;
        }
    }
}
