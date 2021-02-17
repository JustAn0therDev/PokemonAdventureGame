using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Flying;
using PokemonAdventureGame.Moves.Normal;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokemon
{
    public class Pidgeot : IPokemon
    {
        public int TotalHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public int SpecialAttackPoints { get; set; }
        public int SpecialDefensePoints { get; set; }
        public int SpeedPoints { get; set; }
        public StatusCondition Status { get; set; }
        public List<IMove> Moves { get; set; }
        public List<Type> Types { get; set; }

        public void InitializePokemonProperties()
        {
            TotalHealthPoints = 83;
            CurrentHealthPoints = TotalHealthPoints;

            AttackPoints = 80;
            DefensePoints = 75;
            SpecialAttackPoints = 70;
            SpecialDefensePoints = 70;
            SpeedPoints = 101;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Gust(), new WingAttack(), new Tackle() };
            Types = new List<Type> { Type.FLYING };
        }

        public void ReceiveDamage(int damageReceived)
        {
            CurrentHealthPoints -= damageReceived;

            if (HasFainted())
                CurrentHealthPoints = 0;
        }

        public void UseMove(IMove move)
        {
            IMove moveToRemovePowerPoints = Moves.Find(f => f == move);

            if (moveToRemovePowerPoints != null)
                moveToRemovePowerPoints.CurrentPowerPoints -= 1;
        }

        public bool HasFainted() => CurrentHealthPoints <= 0;
    }
}
