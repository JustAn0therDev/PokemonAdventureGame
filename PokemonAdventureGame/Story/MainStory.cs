using System;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.PokemonCenter;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        #region Private Properties

        private readonly ITrainer _player;
        private ITrainer _enemyTrainer;

        #endregion

        #region Constructors 

        public MainStory(ITrainer player) => _player = player;

        #endregion

        #region Story Methods

        public void BeginStory()
        {
            Console.WriteLine("You have come a long way with your Venusaur, battling all trainers you encountered,");
            Console.WriteLine("just to get to the All-Stars Pokemon League.");

            ConsoleUtils.WaitTwoSeconds();
            Console.WriteLine("As you enter a big hall full of Pokemon Statues, your first challenge is there, looking down at you...");

            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
            InitiateFirstBattle();
        }

        private void InitiateFirstBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Brock>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            InitiateSecondBattle();
        }

        private void InitiateSecondBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Bruno>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            InitiateThirdBattle();
        }

        private void InitiateThirdBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<MaryAnn>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            InitiateFourthBattle();
        }

        private void InitiateFourthBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            InitiateFifthBattle();
        }

        private void InitiateFifthBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Lance>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            InitiateFinalBattle();
        }

        private void InitiateFinalBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Red>();
            ShowEnemyTrainerDialogue();
            bool playerWonBattle = StartBattleWithEnemyTrainer();

            EnemyTrainerFinalDialogue(playerWonBattle);
            EndStory();
        }

        private static void EndStory()
        {
            Console.WriteLine("Congratulations on beating the All-Stars Pokemon League!");
            Console.WriteLine("Look up for 'PokemonAdventureGame' on GitHub to see how the game was made.");
            Console.WriteLine("And if you really liked the game, consider giving it a star if you have a GitHub account.");
            ConsoleUtils.WaitFourSeconds();

            Console.WriteLine("Thanks for playing!");
            ConsoleUtils.WaitTwoSeconds();
            ConsoleUtils.EndGame();
        }
        
        #endregion

        #region Final Dialogue

        private void EnemyTrainerFinalDialogue(bool playerWonBattle)
        {
            var didNotComeFromFinalBattle = _enemyTrainer.GetType().Name != "Red";
            
            if (playerWonBattle)
            {
                _enemyTrainer.ShowFinalDialogueForVictory();

                if (didNotComeFromFinalBattle)
                {
                    HealPlayerTeamAndReward();
                }
            }
            else
            {
                _enemyTrainer.ShowFinalDialogueForLoss();
                ConsoleUtils.EndGame();
            }
        }

        #endregion

        #region Helper Methods

        private void HealPlayerTeamAndReward()
        {
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} heals your Pokemon, preparing you for the next battle.");
            PkmnCenter.HealPlayerTeam(_player);

            GivePokemonToPlayer(_enemyTrainer.RewardPokemonForWinning);
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} gave you a {_enemyTrainer.RewardPokemonForWinning.GetType().Name}!");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        private void GivePokemonToPlayer(IPokemon pokemon)
            => _player.PokemonTeam.Add(new TrainerPokemon(pokemon));

        private void ShowEnemyTrainerDialogue() => _enemyTrainer.ShowTrainerDialogue();

        private bool StartBattleWithEnemyTrainer()
        {
            var battle = new Battle(_player, _enemyTrainer);
            return battle.StartBattle();
        }

        #endregion
    }
}
