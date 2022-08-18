using System;
using PokemonAdventureGame.Story;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame
{
    class Program
    {
        public static void Main()
        {
            try
            {
                ITrainer player = TrainerFactory.CreateTrainer<Player>();
                MainStory mainStory = new(player);
                mainStory.BeginStory();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something bad happened in the game! Please report the error. Error: {ex.Message} \n Error's StackTrace: {ex.StackTrace}");
            }
        }
    }
} 