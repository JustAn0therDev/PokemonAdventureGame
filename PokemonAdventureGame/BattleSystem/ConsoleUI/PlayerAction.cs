using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class PlayerAction
    {
        public void PlayerSendsPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<PlayerAction>($"Go, {pokemon.GetType().Name}!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }

        public void PlayerChangesPokemon(IPokemon pokemon)
        {
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.TrainerAction<PlayerAction>($"{pokemon.GetType().Name}, come back!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }
    }
}