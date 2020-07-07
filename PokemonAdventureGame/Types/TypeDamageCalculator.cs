using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.ParameterObjects.Types;

namespace PokemonAdventureGame.Types
{
    public static class TypeDamageCalculator
    {
        private readonly static decimal STAB_MODIFIER_WHEN_DAMAGE_IS_SUPER_EFFECTIVE = 1.2M;

        public static int CalculateDamage(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move, TypeEffect typeEffect)
        {
            decimal modifier = CalculateSTABModifier(attackingPokemon, move);
            InitialDamageParameter initialDamageParameters = new InitialDamageParameter(attackingPokemon, targetPokemon, modifier, move);

            int calculatedDamage = Convert.ToInt32(TypeDamageFormulas.DictionaryOfFormulas[typeEffect].DynamicInvoke(initialDamageParameters));

            return calculatedDamage;
        }

        private static decimal CalculateSTABModifier(IPokemon attackingPokemon, IMove move)
            => attackingPokemon.Types.Contains(move.Type) ?
            move.Damage * STAB_MODIFIER_WHEN_DAMAGE_IS_SUPER_EFFECTIVE :
            move.Damage;
    }
}