using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Validators
{
    public class ItemValidator
    {
        public static bool CanUsePotionOnPokemon(IPokemon pokemon)
            => pokemon.CurrentHealthPoints < pokemon.HealthPoints && !pokemon.HasFainted();
    }
}
