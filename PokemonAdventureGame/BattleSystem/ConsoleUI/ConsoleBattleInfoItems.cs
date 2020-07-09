using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class ConsoleBattleInfoItems
    {
        public static void ShowItemWasUsedOnPokemon(IItem item, IPokemon pokemon)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{item.GetType().Name} was used on {pokemon.GetType().Name}!");
            ConsoleUtils.ClearScreen();
        }

        public static void ShowItemCannotBeUsed()
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds("The selected item cannot be used on the Pokemon!");
            ConsoleUtils.ClearScreen();
        }
    }
}
