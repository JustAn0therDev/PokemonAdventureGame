using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        private readonly ITrainer _player;

        //LOAD THE PLAYER FROM THE CONSTRUCTOR, USING A NEW ITRAINER OBJECT THAT MIGHT COME FROM A:
        //1 - SAVE FILE
        //2 - NEW GAME
        public MainStory(ITrainer player)
        {
            _player = player;
        }

        public void InitiateFifthBattle()
        {
            Console.WriteLine("You enter a large room with a lot of 'Dragonite statues' looking up with their mouths open...");
            Console.WriteLine("A smell of gas fills the room as you start to grasp for a bit more of air...");
            ConsoleUtils.WaitFourSeconds();

            Console.WriteLine("As soon as you notice the smell of gas is coming from the Dragonite statues, the gas turns into fire, reaching the top of the room!");
            Console.WriteLine("In the distance... A man wearing a cape that resembles the wings of a dragon, shouts out:");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("MAY YOU WHO HAVE COME TO CHALLENGE ME, FULFILL MY DESIRE FOR A GOOD BATTLE!");
            ConsoleUtils.WaitTwoSeconds();

            ITrainer enemyTrainer = TrainerFactory.CreateTrainer<Lance>();

            using var battle = new Battle(_player, enemyTrainer);
            battle.StartBattle();
        }
    }
}
