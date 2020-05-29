using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class PlayerMovement
    {
        public void PlayerSendsPokemon(IPokemon pokemon)
        {
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.TrainerAction<PlayerMovement>($"Go, {pokemon.GetType().Name}!");
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.ClearScreen();
        }

        public void PlayerChangesPokemon(IPokemon pokemon)
        {
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.TrainerAction<PlayerMovement>($"{pokemon.GetType().Name}, come back!");
            ConsoleBattleUtils.WaitOneSecond();
            ConsoleBattleUtils.ClearScreen();
        }
    }
}