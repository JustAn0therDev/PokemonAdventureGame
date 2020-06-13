using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Dragon
{
    public class DragonRage : IMove
    {
        public Type Type { get => Type.DRAGON; }
        public int Damage { get => 35; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public DragonRage()
        {
            PowerPoints = 10;
        }
    }
}
