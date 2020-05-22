using System;

namespace PokemonAdventureGame.Types 
{
    public static class TypeDamageCalculator 
    {
        public static double SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.20;
        public static double NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.15;

        public static int SuperEffectiveDamage(int moveDamage) 
            => moveDamage += (Convert.ToInt32(moveDamage * SUPER_EFFECTIVE_DAMAGE_ADDITION));

        public static int NotVeryEffectiveDamage(int moveDamage) 
            => moveDamage -= (Convert.ToInt32(moveDamage * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION));
    }
}