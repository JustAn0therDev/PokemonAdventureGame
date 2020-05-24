using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Types 
{
    public static class TypeDamageCalculator
    {
        public static double SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50;
        public static double NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35;

        public static int CalculateDamage(IPokemon attackingPokemon, IPokemon targetPokemon, int moveDamage, TypeEffect typeEffect) 
        {
            return typeEffect switch
            {
                TypeEffect.IMMUNE => 0,
                TypeEffect.NEUTRAL => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, moveDamage),
                TypeEffect.NOT_VERY_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, NotVeryEffectiveDamage(moveDamage)),
                TypeEffect.SUPER_EFFECTIVE => ApplyDamageFormulaToInitialDamage(attackingPokemon, targetPokemon, SuperEffectiveDamage(moveDamage)),
                _ => moveDamage
            };
        }

        public static int SuperEffectiveDamage(int moveDamage) 
            => moveDamage += (Convert.ToInt32(moveDamage * SUPER_EFFECTIVE_DAMAGE_ADDITION));
        public static int NotVeryEffectiveDamage(int moveDamage) 
            => moveDamage -= (Convert.ToInt32(moveDamage * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION));

        public static int ApplyDamageFormulaToInitialDamage(IPokemon attackingPokemon, IPokemon targetPokemon, int moveDamage)
            => Convert.ToInt32((0.5 * moveDamage * (attackingPokemon.AttackPoints / targetPokemon.DefensePoints)) + 1);
    }
}