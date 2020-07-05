using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Items
{
    public class Potion : IItem
    {
        public void UseItemOnPokemon(IPokemon targetPokemon)
            => targetPokemon.CurrentHealthPoints += 20;
    }
}
