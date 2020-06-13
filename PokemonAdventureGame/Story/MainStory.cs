using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Trainers;

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
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("I hope you give me a good challenge and we both have a lot of fun.");
            ConsoleUtils.WaitTwoSeconds();

            _enemyTrainer = TrainerFactory.CreateTrainer<Brock>();

            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateSecondBattle()
        {
            Console.WriteLine("Hello, trainer, and welcome to the new Pokemon League.");
            Console.WriteLine("It takes a lot of courage to be here, and you must keep going strong to face the challenges up ahead.");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("Do you think you can handle me and my Pokemon?");

            ConsoleUtils.WaitTwoSeconds();
            _enemyTrainer = TrainerFactory.CreateTrainer<Bruno>();

            ConsoleUtils.ClearScreen();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateThirdBattle()
        {
            // TODO: MARYANN
        }

        public void InitiateFourthBattle()
        {
            Console.WriteLine("Hey, I'm Blue, former Pokemon League Champion. Since you got here, I hope you give me a good battle");
            Console.WriteLine("because the last trainers that got here were really disapointing...");
            Console.WriteLine("And you're ugly.");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("So... are you ready to take a beating?");
            ConsoleUtils.WaitTwoSeconds();

            ConsoleUtils.ClearScreen();

            _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();

            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateFifthBattle()
        {
            Console.WriteLine("Congratulations on getting all the way here, trainer.");
            Console.WriteLine("You look strong and like someone who has faced a lot of tough battles.");
            Console.WriteLine("And with that said...");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("MAY YOU WHO HAVE COME TO CHALLENGE ME, FULFILL MY DESIRE FOR A GOOD BATTLE!");
            ConsoleUtils.WaitTwoSeconds();

            _enemyTrainer = TrainerFactory.CreateTrainer<Lance>();

            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void InitiateFinalBattle()
        {
            Console.WriteLine("...");
            Console.WriteLine("...");
            ConsoleUtils.WaitFiveSeconds();

            _enemyTrainer = TrainerFactory.CreateTrainer<Red>();

            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        public void HealPokemon()
        {

        }
    }
}
