using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.PokemonCenter;
using System.Collections.Generic;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        #region Delegates

        private delegate void BrocksDialogue();
        private delegate void BrunosDialogue();
        private delegate void MaryAnnsDialogue();
        private delegate void LancesDialogue();
        private delegate void RedsDialogue();

        #endregion

        private readonly ITrainer _player;
        private ITrainer _enemyTrainer;
        private bool _playerWonBattle;
        private Dictionary<string, Delegate> _finalDialogues;

        public MainStory(ITrainer player)
        {
            _player = player;
            InitiateFirstBattle();
            InitializeFinalDialoguesDictionary();
        }

        private void InitializeFinalDialoguesDictionary()
        {
            _finalDialogues = new Dictionary<string, Delegate>();
            BrocksDialogue brocksDialogue = BrocksFinalDialogue;
            BrunosDialogue brunosDialogue = BrunosFinalDialogue;
            MaryAnnsDialogue maryAnnsDialogue = MaryAnnsFinalDialogue;
            LancesDialogue lancesDialogue = LancesFinalDialogue;
            RedsDialogue redsDialogue = RedsFinalDialogue;

            _finalDialogues.Add("Brock", brocksDialogue);
            _finalDialogues.Add("Bruno", brunosDialogue);
            _finalDialogues.Add("MaryAnn", maryAnnsDialogue);
            _finalDialogues.Add("Lance", lancesDialogue);
            _finalDialogues.Add("Red", redsDialogue);
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

            StartBattle();

            HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Pidgeot>());

            _finalDialogues[_enemyTrainer.GetType().Name].DynamicInvoke();

            InitiateSecondBattle();
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

            StartBattle();

            _finalDialogues[_enemyTrainer.GetType().Name].DynamicInvoke();
            InitiateThirdBattle();
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

            StartBattle();

            _finalDialogues[_enemyTrainer.GetType().Name].DynamicInvoke();
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

            StartBattle();

            _finalDialogues[_enemyTrainer.GetType().Name].DynamicInvoke();
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

            StartBattle();

            _finalDialogues[_enemyTrainer.GetType().Name].DynamicInvoke();
        }

        private void InitiateFinalBattle()
        {
            EnemyPhraseBeforeBattle("...");

            _enemyTrainer = TrainerFactory.CreateTrainer<Red>();
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(_enemyTrainer);
            ConsoleUtils.WaitTwoSeconds();

            StartBattle();
        }

        #region Helper Methods

        private void BrocksFinalDialogue()
        {
            if (_playerWonBattle)
            {
                Console.WriteLine("Wow, man, you are really tough!");
                Console.WriteLine("But by no means I'm the strongest trainer in the League.");
                Console.WriteLine("So to help you in the next battle, I'll heal your pokemon and give you this: ");
                HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Pidgeot>());

                Console.WriteLine("Good luck out there.");
                ConsoleUtils.WaitFourSeconds();
            }
            else
            {
                Console.WriteLine("Hey man, losing happens. We get stronger when we lose.");
                Console.WriteLine("Anytime you want to come back to battle, we'll be here.");

                ConsoleUtils.TrainerAction<EnemyAction>("Good-bye!");
                ConsoleUtils.WaitFourSeconds();
                Environment.Exit(0);
            }
        }

        private void BrunosFinalDialogue()
        {
            if (_playerWonBattle)
            {
                Console.WriteLine("You are really good! I like your energy and the way you treat your Pokemon");
                Console.WriteLine("And keep that in mind when entering the next room. You will need that energy.");
                HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Gengar>());

                Console.WriteLine("Take care out there, kid");
                ConsoleUtils.WaitFourSeconds();
            }
            else
            {
                Console.WriteLine("HAHAHA! You are really good, kid.");
                Console.WriteLine("But I'm WAY STRONGER");
                ConsoleUtils.TrainerAction<EnemyAction>("Come back when you get tougher!!");
                ConsoleUtils.WaitFourSeconds();
                Environment.Exit(0);
            }
        }

        private void MaryAnnsFinalDialogue()
        {
            if (_playerWonBattle)
            {
                Console.WriteLine("Hey, that was a great battle, congratulations on winning! Now, the next trainer is really tough.");
                Console.WriteLine("Watch out and have this, you'll need it.");
                HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Lapras>());

                Console.WriteLine("And if you see my cat, please tell her to come back, I'm a bit worried...");
                ConsoleUtils.WaitFourSeconds();
            }
            else
            {
                Console.WriteLine("I told you...");
                Console.WriteLine("Come back when you get better.");
                ConsoleUtils.TrainerAction<EnemyAction>("Or if you see my cat, I'm worried about her...");
                ConsoleUtils.WaitFourSeconds();
                Environment.Exit(0);
            }
        }

        private void BluesFinalDialogue()
        {
            if (_playerWonBattle)
            {
                Console.WriteLine("Ok, I'll admit it, you're the real deal.");
                Console.WriteLine("Have this Dragonite. Lance is really good, no wonder he is the Champion.");
                HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Dragonite>());

                Console.WriteLine("Good luck, you'll need it.");
                ConsoleUtils.WaitFourSeconds();
            }
            else
            {
                ConsoleUtils.TrainerAction<EnemyAction>("Good-bye, joke.");
                ConsoleUtils.WaitFourSeconds();
                Environment.Exit(0);
            }
        }
        private void LancesFinalDialogue()
        {
            if (_playerWonBattle)
            {
                Console.WriteLine("Congratulations! You beat me and you deserve every single moment of good feelings about yourself!");
                Console.WriteLine("Now, the league does not end here... You need to face a final challenge. Have this: ");
                HealPlayerTeamAndReward(PokemonFactory.CreatePokemon<Snorlax>());

                Console.WriteLine("Watch out and think carefully about every. Single. Movement.");
                ConsoleUtils.WaitFourSeconds();
            }
            else
            {
                Console.WriteLine("Hey, c'mon, I know you can do better than this!");
                ConsoleUtils.TrainerAction<EnemyAction>("Come back when you get stronger.");
                ConsoleUtils.WaitFourSeconds();
                Environment.Exit(0);
            }
        }

        private void RedsFinalDialogue()
        {
            ConsoleUtils.TrainerAction<EnemyAction>("...");
            ConsoleUtils.WaitFourSeconds();
        }

        private void HealPlayerTeamAndReward(IPokemon pokemon)
        {
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} heals your Pokemon to prepare you for the next battle.");
            ConsoleUtils.TrainerAction<PlayerAction>("You go there and replenish all of your Pokemon's health");
            PokemonCenterClass.HealPlayerTeam(_player);

            GivePokemonToPlayer(pokemon);
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} gave you a {pokemon.GetType().Name}!");
            ConsoleUtils.WaitFourSeconds();
        }

        private void GivePokemonToPlayer(IPokemon pokemon) => _player.PokemonTeam.Add(new TrainerPokemon(pokemon));

        private void EnemyPhraseBeforeBattle(string enemyPhrase)
        {
            ConsoleUtils.ClearScreen();

            ConsoleUtils.TrainerAction<EnemyAction>(enemyPhrase);
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.ClearScreen();
        }

        private void StartBattle()
        {
            using var battle = new Battle(_player, _enemyTrainer);
            _playerWonBattle = battle.StartBattle();
        }

        #endregion
    }
}
