using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Rock
{
    public class RockThrow : IMove
    {
        public Type Type { get => Type.ROCK; }
        public int Damage { get => 30; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public RockThrow()
        {
            PowerPoints = 10;
        }
    }
}
