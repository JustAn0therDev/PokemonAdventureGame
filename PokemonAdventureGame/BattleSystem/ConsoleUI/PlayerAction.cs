using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class PlayerAction
    {
        public static void PlayerSendsPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<PlayerAction>($"Go, {pokemon.GetType().Name}!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }

        public static void PlayerDrawsbackPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<PlayerAction>($"Great job, {pokemon.GetType().Name}. Come back!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }
    }
}