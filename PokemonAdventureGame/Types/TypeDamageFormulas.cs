using System;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.ParameterObjects.Types;

namespace PokemonAdventureGame.Types
{
    delegate decimal ImmuneDelegate();
    delegate decimal NeutralDamageDelegate(in InitialDamageParameter initialDamageParameter);
    delegate decimal NotVeryEffectiveDamageDelegate(ref InitialDamageParameter initialDamageParameter);
    delegate decimal SuperEffectiveDamageDelegate(ref InitialDamageParameter initialDamageParameter);

    public static class TypeDamageFormulas
    {
        private readonly static decimal SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50M;
        private readonly static decimal NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35M;

        public static IReadOnlyDictionary<TypeEffect, Delegate> DictionaryOfFormulas
        {
            get
            {
                return new Dictionary<TypeEffect, Delegate>
                {
                    { TypeEffect.IMMUNE, new ImmuneDelegate(ImmuneDamageValue) },
                    { TypeEffect.NEUTRAL, new NeutralDamageDelegate(ApplyDamageFormulaToInitialDamage) },
                    { TypeEffect.NOT_VERY_EFFECTIVE, new NotVeryEffectiveDamageDelegate(NotVeryEffectiveDamage) },
                    { TypeEffect.SUPER_EFFECTIVE, new SuperEffectiveDamageDelegate(SuperEffectiveDamage) }
                };
            }
        }

        private static decimal ImmuneDamageValue() => 0M;

        private static decimal SuperEffectiveDamage(ref InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier += initialDamageParameter.Modifier * SUPER_EFFECTIVE_DAMAGE_ADDITION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static decimal NotVeryEffectiveDamage(ref InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier -= initialDamageParameter.Modifier * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static decimal ApplyDamageFormulaToInitialDamage(in InitialDamageParameter initialDamageParameter)
        {
            decimal attackPoints, defensePoints;
            (attackPoints, defensePoints) = GetDamageForSpecialOrNormalMove(initialDamageParameter);
            decimal finalDamageResult = ApplyFinalDamageFormula(attackPoints, defensePoints, initialDamageParameter.Modifier);

            return Math.Ceiling(finalDamageResult);
        }

        private static (decimal, decimal) GetDamageForSpecialOrNormalMove(in InitialDamageParameter initialDamageParameter)
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
