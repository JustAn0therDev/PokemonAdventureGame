﻿using PokemonAdventureGame.Enums;
using PokemonAdventureGame.ParameterObjects.Types;
using System;
using System.Collections.Generic;

namespace PokemonAdventureGame.Types
{
    delegate decimal ImmuneDelegate();
    delegate decimal NeutralDamageDelegate(InitialDamageParameter initialDamageParameter);
    delegate decimal NotVeryEffectiveDamageDelegate(InitialDamageParameter initialDamageParameter);
    delegate decimal SuperEffectiveDamageDelegate(InitialDamageParameter initialDamageParameter);

    public static class TypeDamageFormulas
    {
        private readonly static decimal SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50M;
        private readonly static decimal NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35M;

        public static Dictionary<TypeEffect, Delegate> DictionaryOfFormulas
        {
            get
            {
                ImmuneDelegate immuneDelegate = ImmuneDamageValue;
                NeutralDamageDelegate neutralDamageDelegate = ApplyDamageFormulaToInitialDamage;
                NotVeryEffectiveDamageDelegate notVeryEffectiveDamageDelegate = NotVeryEffectiveDamage;
                SuperEffectiveDamageDelegate superEffectiveDamageDelegate = SuperEffectiveDamage;

                return new Dictionary<TypeEffect, Delegate>
                {
                    { TypeEffect.IMMUNE, immuneDelegate },
                    { TypeEffect.NEUTRAL, neutralDamageDelegate },
                    { TypeEffect.NOT_VERY_EFFECTIVE, notVeryEffectiveDamageDelegate },
                    { TypeEffect.SUPER_EFFECTIVE, superEffectiveDamageDelegate }
                };
            }
        }

        private static decimal ImmuneDamageValue() => 0M;

        private static decimal SuperEffectiveDamage(InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier += initialDamageParameter.Modifier * SUPER_EFFECTIVE_DAMAGE_ADDITION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static decimal NotVeryEffectiveDamage(InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier -= initialDamageParameter.Modifier * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static decimal ApplyDamageFormulaToInitialDamage(InitialDamageParameter initialDamageParameter)
        {
            decimal attackPoints, defensePoints;
            (attackPoints, defensePoints) = GetDamageForSpecialOrNormalMove(initialDamageParameter);
            decimal finalDamageResult = ApplyFinalDamageFormula(attackPoints, defensePoints, initialDamageParameter.Modifier);

            return Math.Ceiling(finalDamageResult);
        }

        private static (decimal, decimal) GetDamageForSpecialOrNormalMove(InitialDamageParameter initialDamageParameter)
        {
            decimal attackPoints, defensePoints;
            if (initialDamageParameter.Move.Special)
            {
                attackPoints = Convert.ToDecimal(initialDamageParameter.AttackingPokemon.SpecialAttackPoints);
                defensePoints = Convert.ToDecimal(initialDamageParameter.TargetPokemon.SpecialDefensePoints);
            }
            else
            {
                attackPoints = Convert.ToDecimal(initialDamageParameter.AttackingPokemon.AttackPoints);
                defensePoints = Convert.ToDecimal(initialDamageParameter.TargetPokemon.DefensePoints);
            }
            return (attackPoints, defensePoints);
        }

        private static decimal ApplyFinalDamageFormula(decimal attackPoints, decimal defensePoints, decimal modifier)
        {
            decimal baseDamageResult = Math.Round(attackPoints / defensePoints, MidpointRounding.AwayFromZero);
            decimal productFromDamageAndModifier = modifier * baseDamageResult;
            return (productFromDamageAndModifier / 2) + 1;
        }
    }
}
