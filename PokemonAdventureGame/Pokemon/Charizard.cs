using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Fire;
using PokemonAdventureGame.Moves.Flying;
using System.Collections.Generic;

namespace PokemonAdventureGame.Pokemon
{
    public class Charizard : IPokemon
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
            HealthPoints = 78;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 84;
            DefensePoints = 78;
            SpecialAttackPoints = 109;
            SpecialDefensePoints = 85;
            SpeedPoints = 100;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Flamethrower(), new WingAttack(), new Gust(), new FireBlast() };
            Types = new List<Type> { Type.FIRE, Type.FLYING };
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
