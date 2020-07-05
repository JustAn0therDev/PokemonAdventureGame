using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Fire;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Psychic;

namespace PokemonAdventureGame.Pokemon
{
    public class Espeon : IPokemon
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
            HealthPoints = 65;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 65;
            DefensePoints = 60;
            SpecialAttackPoints = 130;
            SpecialDefensePoints = 95;
            SpeedPoints = 110;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Psychic(), new Slash(), new FireBlast() };
            Types = new List<Type> { Type.PSYCHIC };
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
