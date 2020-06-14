using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.PokemonCenter;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        private readonly ITrainer _player;
        private ITrainer _enemyTrainer;

        public MainStory(ITrainer player)
        {
            _player = player;
            InitiateFirstBattle();
        }

        private void InitiateFirstBattle()
        {
            Console.WriteLine("Hey, welcome to the All-Stars Pokemon League!");
            Console.WriteLine("My name's Brock. I'm the pewter city's gym leader, and your first challenge.");
            ConsoleUtils.WaitFourSeconds();

            EnemyPhraseBeforeBattle("I hope you give me a good challenge and we both have a lot of fun.");

            _enemyTrainer = TrainerFactory.CreateTrainer<Brock>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();

            //At the end of the battle, if the player wins, Brock you give her/him a Pidgeot.
            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Pidgeot>());

            //Final dialogue here
            //InitiateSecondBattle()
        }

        private void InitiateSecondBattle()
        {
            Console.WriteLine("Hello, trainer, and welcome to the new Pokemon League.");
            Console.WriteLine("It takes a lot of courage to be here, and you must keep going strong to face the challenges up ahead.");
            ConsoleUtils.WaitFourSeconds();

            EnemyPhraseBeforeBattle("Do you think you can handle me and my Pokemon?");

            _enemyTrainer = TrainerFactory.CreateTrainer<Bruno>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();

            //If the player wins, Bruno gives the player a Gengar.
            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Gengar>());
        }

        private void InitiateThirdBattle()
        {
            Console.WriteLine("Hi, welcome to the new Pokemon League. Congratualtions on beating Brock and Bruno.");
            Console.WriteLine("But I can guarantee that I won't be that much of a pushover like those two.");
            ConsoleUtils.WaitFourSeconds();

            EnemyPhraseBeforeBattle("Are you ready to take a beating?");
            EnemyPhraseBeforeBattle("By the way, have you seen my cat?");

            _enemyTrainer = TrainerFactory.CreateTrainer<MaryAnn>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();

            //If the player wins, MaryAnn you give the player a Lapras.
            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Lapras>());
        }

        private void InitiateFourthBattle()
        {
            Console.WriteLine("Hey, I'm Blue, former Pokemon League Champion. Since you got here, I hope you give me a good battle");
            Console.WriteLine("because the last trainers that got here were really disapointing...");
            Console.WriteLine("And you're ugly.");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("I hope you're ready to have your butt handed over to you.");
            ConsoleUtils.WaitTwoSeconds();
            ConsoleUtils.ClearScreen();

            _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();

            //If the player wins, Blue will give the player a Dragonite.
            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Dragonite>());
        }

        private void InitiateFifthBattle()
        {
            Console.WriteLine("Congratulations on getting all the way here, trainer.");
            Console.WriteLine("You look strong and like someone who has faced a lot of tough battles.");
            Console.WriteLine("And with that said...");
            ConsoleUtils.WaitFourSeconds();

            EnemyPhraseBeforeBattle("May you who have come to challenge me, fulfill my desire for a good battle!");

            _enemyTrainer = TrainerFactory.CreateTrainer<Lance>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();

            //At the end of a battle, if the player wins, Lance will give the player a Snorlax with more HP and earthquake.
            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Snorlax>());
        }

        private void InitiateFinalBattle()
        {
            EnemyPhraseBeforeBattle("...");

            _enemyTrainer = TrainerFactory.CreateTrainer<Red>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            using var battle = new Battle(_player, _enemyTrainer);
            battle.StartBattle();
        }

        private void HealPlayerTeamAndReward(IPokemon pokemon)
        {
            ConsoleUtils.TrainerAction<PlayerAction>("You found out that after a battle, there is a Pokemon Center.");
            ConsoleUtils.TrainerAction<PlayerAction>("You go there and replenish all of your Pokemon's health");

            PokemonCenterClass.HealPlayerTeam(_player);
            ConsoleUtils.WaitFourSeconds();
            GivePokemonToPlayer(pokemon);
        }

        #region Helper Methods

        private void GivePokemonToPlayer(IPokemon pokemon) => _player.PokemonTeam.Add(new TrainerPokemon(pokemon));

        private void EnemyPhraseBeforeBattle(string enemyPhrase)
        {
            ConsoleUtils.ClearScreen();

            ConsoleUtils.TrainerAction<EnemyAction>(enemyPhrase);
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.ClearScreen();
        }

        #endregion
    }
}
