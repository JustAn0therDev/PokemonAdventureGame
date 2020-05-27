using System.Collections.Generic;
using PokemonAdventureGame.Enums;
namespace PokemonAdventureGame.Interfaces
{
    public interface IMove
    {
        Enums.Type Type { get; }
        int Damage { get; }
        int PowerPoints { get; set; }
        bool Special { get; }
        List<StatusMove> StatusMoves { get; }
        StatusMoveTarget? MoveTarget { get; }
    }
}