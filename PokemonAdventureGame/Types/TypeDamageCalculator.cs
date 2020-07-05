using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Types
{
    public static class TypeDamageCalculator
    {
        private readonly static decimal STAB_MODIFIER_WHEN_DAMAGE_IS_SUPER_EFFECTIVE = 1.2M;
        private readonly static decimal SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50M;
        private readonly static decimal NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35M;

        public static int CalculateDamage(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move, TypeEffect typeEffect)
        {
            decimal modifier = CalculateSTABModifier(attackingPokemon, move);

            return typeEffect switch
            {
                TypeEffect.IMMUNE => 0,
                TypeEffect.NEUTRAL => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, modifier, move),
                TypeEffect.NOT_VERY_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, NotVeryEffectiveDamage(modifier), move),
                TypeEffect.SUPER_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, SuperEffectiveDamage(modifier), move),
                _ => move.Damage
            };
        }

        //Following the original Pokemon game damage calculations,
        //the "modifier" will envolve things outside the formula itself, such as STAB (Same Type Attack Bonus).
        private static decimal CalculateSTABModifier(IPokemon attackingPokemon, IMove move)
            => attackingPokemon.Types.Contains(move.Type) ?
            move.Damage * STAB_MODIFIER_WHEN_DAMAGE_IS_SUPER_EFFECTIVE :
            move.Damage;

        public static decimal SuperEffectiveDamage(decimal modifier)
            => modifier += modifier * SUPER_EFFECTIVE_DAMAGE_ADDITION;

        public static decimal NotVeryEffectiveDamage(decimal modifier)
            => modifier -= modifier * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION;


        //This is the damage formula used for the Pokemon GO game. I didn't use the actual pokemon formula because it depends
        //on more stuff than what we got in this game, like weather, level, friendship, etc.
        public static int ApplyDamageFormulaToInitialDamage(IPokemon attackingPokemon, IPokemon targetPokemon, decimal modifier, IMove move)
        {
            decimal attackPoints, defensePoints;
            (attackPoints, defensePoints) = GetDamageForSpecialOrCommonMove(attackingPokemon, targetPokemon, move.Special);
            decimal finalDamageResult = ApplyFinalDamageFormula(attackPoints, defensePoints, modifier);

            return (int)Math.Ceiling(finalDamageResult);
        }

        private static (decimal, decimal) GetDamageForSpecialOrCommonMove(IPokemon attackingPokemon, IPokemon targetPokemon, bool moveIsSpecial)
        {
            decimal attackPoints, defensePoints;
            if (moveIsSpecial)
            {
                attackPoints = Convert.ToDecimal(attackingPokemon.SpecialAttackPoints);
                defensePoints = Convert.ToDecimal(targetPokemon.SpecialDefensePoints);
            }
            else
            {
                attackPoints = Convert.ToDecimal(attackingPokemon.AttackPoints);
                defensePoints = Convert.ToDecimal(targetPokemon.DefensePoints);
            }
            return (attackPoints, defensePoints);
        }

        private static decimal ApplyFinalDamageFormula(decimal attackPoints, decimal defensePoints, decimal modifier)
        {
            decimal roundedAttackDividedByDefense = Math.Round(attackPoints / defensePoints, MidpointRounding.AwayFromZero);
            decimal productFromDamageAndModifier = modifier * roundedAttackDividedByDefense;
            return (productFromDamageAndModifier / 2) + 1;
        }
    }
}