using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Dragon;
using PokemonAdventureGame.Moves.Flying;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Electric;

namespace PokemonAdventureGame.Pokemon
{
    public class Dragonite : IPokemon
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
            TotalHealthPoints = 91;
            CurrentHealthPoints = TotalHealthPoints;

            AttackPoints = 134;
            DefensePoints = 95;
            SpecialAttackPoints = 100;
            SpecialDefensePoints = 100;
            SpeedPoints = 80;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new DragonRage(), new Hyperbeam(), new Thunderbolt(), new WingAttack() };
            Types = new List<Type> { Type.DRAGON, Type.FLYING };
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
