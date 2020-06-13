using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;
using System;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        private readonly ITrainer _player;
        private ITrainer _enemyTrainer;

        public MainStory(ITrainer player)
        {
            _player = player;
        }

        public void InitiateFirstBattle()
        {
            Console.WriteLine("Hey, welcome to the All-Stars Pokemon League!");
            Console.WriteLine("My name's Brock. I'm the pewter city's gym leader, and your first challenge.");
            ConsoleUtils.TrainerAction<EnemyAction>("I hope you give me a good challenge and we both have a lot of fun.");
            _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateSecondBattle()
        {

        }

        public void InitiateThirdBattle()
        {

        }

        public void InitiateFourthBattle()
        {

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

            _enemyTrainer = TrainerFactory.CreateTrainer<Lance>();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateFinalBattle()
        {
            Console.WriteLine("...");
            Console.WriteLine("...");
            ConsoleUtils.WaitFiveSeconds();
        }

        public void HealPokemon()
        {

        }
    }
}
