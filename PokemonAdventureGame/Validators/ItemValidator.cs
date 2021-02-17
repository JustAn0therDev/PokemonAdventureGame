using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Validators
{
    public static class ItemValidator
    {
        public static bool CanUsePotionOnPokemon(IPokemon pokemon)
            => pokemon.CurrentHealthPoints < pokemon.TotalHealthPoints && !pokemon.HasFainted();
    }
}
