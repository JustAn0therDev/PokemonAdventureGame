﻿using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Moves.Fire;
using PokemonAdventureGame.Moves.Normal;

namespace PokemonAdventureGame.Pokemon
{
    public class Arcanine : IPokemon
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
            TotalHealthPoints = 90;
            CurrentHealthPoints = TotalHealthPoints;

            AttackPoints = 110;
            DefensePoints = 80;
            SpecialAttackPoints = 100;
            SpecialDefensePoints = 80;
            SpeedPoints = 95;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new Flamethrower(), new Tackle(), new FireBlast() };
            Types = new List<Type> { Type.FIRE };
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
