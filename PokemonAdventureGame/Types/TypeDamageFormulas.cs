using System;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.ParameterObjects.Types;

namespace PokemonAdventureGame.Types
{

    public static class TypeDamageFormulas
    {
        private delegate float ImmuneDelegate();
        private delegate float NeutralDamageDelegate(InitialDamageParameter initialDamageParameter);
        private delegate float NotVeryEffectiveDamageDelegate(InitialDamageParameter initialDamageParameter);
        private delegate float SuperEffectiveDamageDelegate(InitialDamageParameter initialDamageParameter);
        private readonly static float SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50f;
        private readonly static float NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35f;

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

        // The immune damage value comes from a method so we can use the Strategy Pattern at runtime for all other values as well.
        private static float ImmuneDamageValue() => 0;

        private static float SuperEffectiveDamage(InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier += initialDamageParameter.Modifier * SUPER_EFFECTIVE_DAMAGE_ADDITION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static float NotVeryEffectiveDamage(InitialDamageParameter initialDamageParameter)
        {
            initialDamageParameter.Modifier -= initialDamageParameter.Modifier * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION;
            return ApplyDamageFormulaToInitialDamage(initialDamageParameter);
        }

        private static float ApplyDamageFormulaToInitialDamage(InitialDamageParameter initialDamageParameter)
        {
            float attackPoints, defensePoints;
            (attackPoints, defensePoints) = GetDamageForSpecialOrNormalMove(initialDamageParameter);
            float finalDamageResult = GetFinalDamageFromFinalDamageFormula(attackPoints, defensePoints, initialDamageParameter.Modifier);

            return Convert.ToInt32(Math.Ceiling(finalDamageResult));
        }

        private static (float, float) GetDamageForSpecialOrNormalMove(InitialDamageParameter initialDamageParameter)
        {
            float attackPoints, defensePoints;
            if (initialDamageParameter.Move.Special)
            {
                attackPoints = initialDamageParameter.AttackingPokemon.SpecialAttackPoints;
                defensePoints = initialDamageParameter.TargetPokemon.SpecialDefensePoints;
            }
            else
            {
                attackPoints = initialDamageParameter.AttackingPokemon.AttackPoints;
                defensePoints = initialDamageParameter.TargetPokemon.DefensePoints;
            }

            return (attackPoints, defensePoints);
        }

        private static float GetFinalDamageFromFinalDamageFormula(float attackPoints, float defensePoints, float modifier)
        {
            float baseDamageResult = attackPoints / defensePoints;
            float productFromDamageAndModifier = modifier * baseDamageResult;
            return (productFromDamageAndModifier / 2) + 1;
        }
    }
}
