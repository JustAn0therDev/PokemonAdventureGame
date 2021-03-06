﻿using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Moves.Psychic;
using PokemonAdventureGame.Moves.Rock;

namespace PokemonAdventureGame.Pokemon
{
    public class Hypno : IPokemon
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
            TotalHealthPoints = 85;
            CurrentHealthPoints = TotalHealthPoints;

            AttackPoints = 73;
            DefensePoints = 70;
            SpecialAttackPoints = 73;
            SpecialDefensePoints = 115;
            SpeedPoints = 67;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Hyperbeam(), new Psychic(), new RockSlide() };
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
