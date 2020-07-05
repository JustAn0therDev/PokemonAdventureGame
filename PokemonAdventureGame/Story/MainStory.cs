﻿using System;
using PokemonAdventureGame.BattleSystem;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Trainers;
using PokemonAdventureGame.PokemonCenter;

namespace PokemonAdventureGame.Story
{
    public class MainStory
    {
        #region Private Properties

        private readonly ITrainer _player;
        private ITrainer _enemyTrainer;
        private bool _playerWonBattle;

        #endregion

        #region Constructors 

        public MainStory(ITrainer player)
        {
            _player = player;
            BeginStory();
        }

        #endregion

        #region Story Methods

        private void BeginStory()
        {
            Console.WriteLine("You have come a long way with your Venusaur, battling all trainers you encountered,");
            Console.WriteLine("just to get to the All-Stars Pokemon League.");

            ConsoleUtils.WaitFourSeconds();
            Console.WriteLine("As you enter a big hall full of Pokemon Statues, your first challenge is there, looking down at you...");

            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
            InitiateFirstBattle();
        }

        private void InitiateFirstBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Brock>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            InitiateSecondBattle();
        }

        private void InitiateSecondBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Bruno>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            InitiateThirdBattle();
        }

        private void InitiateThirdBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<MaryAnn>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            InitiateFourthBattle();
        }

        private void InitiateFourthBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Blue>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            InitiateFifthBattle();
        }

        private void InitiateFifthBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Lance>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            InitiateFinalBattle();
        }

        private void InitiateFinalBattle()
        {
            _enemyTrainer = TrainerFactory.CreateTrainer<Red>();
            ShowTrainerDialogueToStartBattle();

            EnemyTrainerFinalDialogue();
            EndStory();
        }

        private void EndStory()
        {
            Console.WriteLine("Congratulations on beating the All-Stars Pokemon League! You have come a long way");
            Console.WriteLine("just to get here. If you are a developer and liked the game, please consider giving it a star on GitHub,");
            Console.WriteLine("just look up for PokemonAdventureGame in the repositories tab.");

            ConsoleUtils.WaitFourSeconds();
            Console.WriteLine("Thank you for playing! :)");
            ConsoleUtils.EndProgram();
        }

        #endregion

        #region Final Dialogue

        private void EnemyTrainerFinalDialogue()
        {
            bool didNotComeFromFinalBattle = _enemyTrainer.GetType().Name != "Red";
            if (_playerWonBattle)
            {
                _enemyTrainer.ShowFinalDialogueForVictory();
                if (didNotComeFromFinalBattle)
                    HealPlayerTeamAndReward();
            }
            else
            {
                _enemyTrainer.ShowFinalDialogueForLoss();
                ConsoleUtils.EndProgram();
            }
        }

        #endregion

        #region Helper Methods

        private void HealPlayerTeamAndReward()
        {
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} heals your Pokemon to prepare you for the next battle.");
            PkmnCenter.HealPlayerTeam(_player);

            GivePokemonToPlayer(_enemyTrainer.RewardPokemonForWinning);
            ConsoleUtils.TrainerAction<PlayerAction>($"{_enemyTrainer.GetType().Name} gave you a {_enemyTrainer.RewardPokemonForWinning.GetType().Name}!");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        private void GivePokemonToPlayer(IPokemon pokemon)
            => _player.PokemonTeam.Add(new TrainerPokemon(pokemon));

        private void ShowTrainerDialogueToStartBattle()
        {
            _enemyTrainer.ShowTrainerDialogue();
            using var battle = new Battle(_player, _enemyTrainer);
            _playerWonBattle = battle.StartBattle();
        }

        #endregion
    }
}