using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Grass
{
    public class BulletSeed : IMove
    {
        public Type Type { get => Type.GRASS; }
        public int Damage { get => 30; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public BulletSeed()
        {
            PowerPoints = 15;
        }
    }
}
