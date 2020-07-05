using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Ice;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Water;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokemon
{
    public class Blastoise : IPokemon
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
            HealthPoints = 79;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 83;
            DefensePoints = 100;
            SpecialAttackPoints = 85;
            SpecialDefensePoints = 105;
            SpeedPoints = 78;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Surf(), new Blizzard(), new HydroPump(), new Slash() };
            Types = new List<Type> { Type.WATER };
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
