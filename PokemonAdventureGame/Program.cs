using System;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.Trainers;

namespace PokemonAdventureGame
{
    class Program
    {
        static void Main()
        {
            try
            {
                ITrainer player = TrainerFactory.CreateTrainer<Player>();
                ITrainer computer = TrainerFactory.CreateTrainer<Gary>();
                Battle battle = new Battle(player, computer);
                battle.StartBattle();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something bad happened in the game! Please report the error. Error: {ex.Message}");
            }
        }
    }
}
