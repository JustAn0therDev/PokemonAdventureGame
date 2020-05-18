using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame.Interfaces
{
    public interface IPokemon
    {
        int HealthPoints { get; set; }
        int CurrentHealthPoints { get; set; }
        int AttackPoints { get; set; }
        int DefensePoints { get; set; }
        int SpecialAttackPoints { get; set; }
        int SpecialDefensePoints { get; set; }
        int SpeedPoints { get; set; }
        StatusCondition Status { get; set; }
        List<IMove> Moves { get; set; }
        /* Um type pode ser imune a outro */
        List<Type> Types { get; set; }
        void InitializePokemonProperties();
        void ReceiveDamage(int damageReceived);
        void UseMove(int moveIndex);
        bool HasFainted();
    }
}
