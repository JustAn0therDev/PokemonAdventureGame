using System.Collections.Generic;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Moves.Psychic
{
    public class Psychic : IMove
    {
        public Type Type { get => Type.PSYCHIC; }
        public int Damage { get => 35; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Psychic()
        {
            PowerPoints = 30;
        }
    }
}
