using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Fire;
using PokemonAdventureGame.Moves.Flying;
using PokemonAdventureGame.Moves.Grass;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokemon
{
    public class Venusaur : IPokemon
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
            HealthPoints = 80;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 82;
            DefensePoints = 83;
            SpecialAttackPoints = 100;
            SpecialDefensePoints = 100;
            SpeedPoints = 80;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new VineWhip(), new BulletSeed(), new Gust(), new SolarBeam() };
            Types = new List<Type> { Type.GRASS, Type.POISON };
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
