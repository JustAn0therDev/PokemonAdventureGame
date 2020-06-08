using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Flying;
using PokemonAdventureGame.Moves.Rock;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokemon
{
    public class Aerodactyl : IPokemon
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

            AttackPoints = 105;
            DefensePoints = 85;
            SpecialAttackPoints = 70;
            SpecialDefensePoints = 95;
            SpeedPoints = 150;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new WingAttack(), new Peck(), new RockThrow(), new RockSlide() };
            Types = new List<Type> { Type.ROCK, Type.FLYING };
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
