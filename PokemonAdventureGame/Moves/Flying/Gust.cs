using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Moves.Flying
{
    public class Gust : IMove
    {
        public Type Type { get => Type.FLYING; }
        public int Damage { get => 20; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }
        public List<StatusMove> StatusMoves { get => null; }
        public StatusMoveTarget? MoveTarget { get => null; }

        public Gust()
        {
            PowerPoints = 30;
        }
    }
}
