using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Ground;
using PokemonAdventureGame.Moves.Ice;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Rock;
using PokemonAdventureGame.Moves.Water;

namespace PokemonAdventureGame.Pokemon
{
    public class Snorlax : IPokemon
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
            TotalHealthPoints = 200;
            CurrentHealthPoints = TotalHealthPoints;

            AttackPoints = 110;
            DefensePoints = 65;
            SpecialAttackPoints = 65;
            SpecialDefensePoints = 110;
            SpeedPoints = 30;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Surf(), new Blizzard(), new Hyperbeam(), new Earthquake() };
            Types = new List<Type> { Type.WATER, Type.ICE };
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
