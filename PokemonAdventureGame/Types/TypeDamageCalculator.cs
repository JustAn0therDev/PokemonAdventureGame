using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.ParameterObjects.Types;

namespace PokemonAdventureGame.Types
{
    public static class TypeDamageCalculator
    {
        private readonly static float _stabModifierWhenDamageIsSuperEffective = 1.2f;

        public static int CalculateDamage(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move, TypeEffect typeEffect)
        {
            float modifier = CalculateSTABModifier(attackingPokemon, move);

            var initialDamageParameter = new InitialDamageParameter(attackingPokemon, targetPokemon, modifier, move);

            int calculatedDamage = Convert.ToInt32(TypeDamageFormulas.DictionaryOfFormulas[typeEffect].DynamicInvoke(initialDamageParameter));

            return calculatedDamage;
        }

        private static float CalculateSTABModifier(IPokemon attackingPokemon, IMove move)
            => attackingPokemon.Types.Contains(move.Type) ? move.Damage * _stabModifierWhenDamageIsSuperEffective : move.Damage;
    }
}