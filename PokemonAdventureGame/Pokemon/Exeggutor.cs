using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Fire;
using PokemonAdventureGame.Moves.Grass;

namespace PokemonAdventureGame.Pokemon
{
    public class Exeggutor : IPokemon
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
            HealthPoints = 95;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 95;
            DefensePoints = 85;
            SpecialAttackPoints = 125;
            SpecialDefensePoints = 75;
            SpeedPoints = 55;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Flamethrower(), new VineWhip(), new BulletSeed(), new SolarBeam() };
            Types = new List<Type> { Type.GRASS, Type.PSYCHIC };
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
                moveToRemovePowerPoints.PowerPoints -= 1;
        }

        public bool HasFainted() => CurrentHealthPoints <= 0;
    }
}
