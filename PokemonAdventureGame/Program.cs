using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;

namespace PokemonAdventureGame
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("You enter a large room with a lot of 'Dragonite statues' looking up with their mouths open...");
                Console.WriteLine("A smell of gas fills the room as you start to grasp for a bit more of air...");
                ConsoleUtils.WaitFourSeconds();

                Console.WriteLine("As soon as you notice the smell of gas is coming from the Dragonite statues, the gas turns into fire, reaching the top of the room!");
                Console.WriteLine("In the distance... A man wearing a cape that resembles the wings of a dragon, shouts out:");
                ConsoleUtils.WaitFourSeconds();

                ConsoleUtils.TrainerAction<EnemyAction>("MAY YOU WHO HAVE COME TO CHALLENGE ME, FULFILL MY DESIRE FOR A GOOD BATTLE!");
                ConsoleUtils.WaitTwoSeconds();

                ITrainer player = TrainerFactory.CreateTrainer<Player>();
                ITrainer computer = TrainerFactory.CreateTrainer<Lance>();
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
