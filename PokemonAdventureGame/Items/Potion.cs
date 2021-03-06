﻿using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Validators;

namespace PokemonAdventureGame.Items
{
    public class Potion : IItem
    {
        private const int LIMIT_OF_HEALTH_POINTS_TO_RECOVER = 20;
        public bool TryToUseItemOnPokemon(IPokemon targetPokemon)
        {
            bool pokemonIsEligibleToReceiveItem = ItemValidator.CanUsePotionOnPokemon(targetPokemon);

            if (pokemonIsEligibleToReceiveItem)
                targetPokemon.CurrentHealthPoints += GetPositiveDifferenceInHealthPoints(targetPokemon);

            return pokemonIsEligibleToReceiveItem;
        }

        private int GetPositiveDifferenceInHealthPoints(IPokemon targetPokemon)
        {
            int differenceInHealthPoints = targetPokemon.TotalHealthPoints - targetPokemon.CurrentHealthPoints;
            return differenceInHealthPoints > LIMIT_OF_HEALTH_POINTS_TO_RECOVER ? LIMIT_OF_HEALTH_POINTS_TO_RECOVER : differenceInHealthPoints;
        }
    }
}
