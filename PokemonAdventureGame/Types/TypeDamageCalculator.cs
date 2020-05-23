using System;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Types 
{
    public static class TypeDamageCalculator
    {
        public static double SUPER_EFFECTIVE_DAMAGE_ADDITION = 0.50;
        public static double NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION = 0.35;

        public static int SuperEffectiveDamage(int moveDamage) 
            => moveDamage += (Convert.ToInt32(moveDamage * SUPER_EFFECTIVE_DAMAGE_ADDITION));
        public static int NotVeryEffectiveDamage(int moveDamage) 
            => moveDamage -= (Convert.ToInt32(moveDamage * NOT_VERY_EFFECTIVE_DAMAGE_SUBTRACTION));
        
        public static int ImmuneToMove() => 0;

        public static int CalculateDamageBasedOnTypeEffect(int moveDamage, TypeEffect typeEffect) 
        {
            return typeEffect switch
            {
                TypeEffect.IMMUNE => ImmuneToMove(),
                TypeEffect.NEUTRAL => moveDamage,
                TypeEffect.NOT_VERY_EFFECTIVE => NotVeryEffectiveDamage(moveDamage),
                TypeEffect.SUPER_EFFECTIVE => SuperEffectiveDamage(moveDamage),
                _ => moveDamage,
            };
        }
    }
}