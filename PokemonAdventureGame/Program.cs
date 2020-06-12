using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Story;
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
                MainStory mainStory = new MainStory(player);

                mainStory.InitiateFirstBattle();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something bad happened in the game! Please report the error. Error: {ex.Message}");
            }
        }
    }
} 