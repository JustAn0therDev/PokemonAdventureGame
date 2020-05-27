using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Types 
{
    public static class TypeDamageCalculator
    {
        private static double SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50;
        private static double NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35;

        //Is there something I can do to improve the number of parameters in this method?
        public static int CalculateDamage(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move, TypeEffect typeEffect) 
        {
            int modifier = CalculateSTABModifier(attackingPokemon, move);

            return typeEffect switch
            {
                TypeEffect.IMMUNE => 0,
                TypeEffect.NEUTRAL => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, modifier),
                TypeEffect.NOT_VERY_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, NotVeryEffectiveDamage(modifier)),
                TypeEffect.SUPER_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, SuperEffectiveDamage(modifier)),
                _ => move.Damage
            };
        }

        //The "modifier" will envolve things outside the formula itself, such as STAB (Same Type Attack Bonus).
        private static int CalculateSTABModifier(IPokemon attackingPokemon, IMove move)
            => Convert.ToInt32(attackingPokemon.Types.Contains(move.Type) ? move.Damage * 1.2 : move.Damage);

        public static int SuperEffectiveDamage(int modifier) 
            => modifier += (Convert.ToInt32(modifier * SUPER_EFFECTIVE_DAMAGE_ADDITION));

        public static int NotVeryEffectiveDamage(int modifier)
            => modifier -= (Convert.ToInt32(modifier * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION));

        //This is the damage formula used for the Pokemon GO game. I didn't use the actual pokemon formula because it depends
        //on more stuff than what we got in this game, like weather, level, friendship levels, etc.
        public static int ApplyDamageFormulaToInitialDamage(IPokemon attackingPokemon, IPokemon targetPokemon, int modifier)
            => Convert.ToInt32((0.5 * (modifier * (attackingPokemon.AttackPoints / targetPokemon.DefensePoints))) + 1);
    }
}