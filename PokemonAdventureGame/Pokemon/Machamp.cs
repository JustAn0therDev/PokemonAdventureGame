using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Rock;
using PokemonAdventureGame.Moves.Fighting;
using PokemonAdventureGame.Moves.Normal;

namespace PokemonAdventureGame.Pokemon
{
    public class Machamp : IPokemon
    {
        public int HealthPoints { get; set; }
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
            HealthPoints = 90;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 130;
            DefensePoints = 80;
            SpecialAttackPoints = 65;
            SpecialDefensePoints = 85;
            SpeedPoints = 55;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new RockSlide(), new RockThrow(), new BrickBreak(), new Tackle() };
            Types = new List<Type> { Type.FIGHTING };
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
