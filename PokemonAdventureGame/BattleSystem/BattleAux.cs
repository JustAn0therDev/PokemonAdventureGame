using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Statuses;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.BattleSystem
{
    // This class contains methods that do not depend on an order of execution.
    public class BattleAux
    {
        private readonly ITrainer Player;
        private readonly ITrainer EnemyTrainer;

        public BattleAux (ITrainer player, ITrainer enemyTrainer)
        {
            Player = player;
            EnemyTrainer = enemyTrainer;
        }

        public bool CannotSendNextAvailablePokemon(bool isEnemyTrainer = false)
        {
            ITrainer trainer = isEnemyTrainer ? EnemyTrainer : Player;

            trainer.SetPokemonAsFainted(trainer.GetCurrentPokemon());
            TrainerDrawsbackPokemon(isEnemyTrainer);
            return TrainerIsOutOfPokemonToBattle(isEnemyTrainer);
        }

        private void TrainerDrawsbackPokemon(bool isEnemyTrainer)
        {
            if (isEnemyTrainer)
            {
                EnemyAction.EnemyTrainerDrawsbackPokemon(EnemyTrainer.GetCurrentPokemon());
            }
            else
            {
                PlayerAction.PlayerDrawsbackPokemon(Player.GetCurrentPokemon());
            }
        }

        private bool TrainerIsOutOfPokemonToBattle(bool isEnemyTrainer)
        {
            ITrainer trainer = isEnemyTrainer ? EnemyTrainer : Player;

            if (trainer.GetNextAvailablePokemon() == null)
            {
                FinishBattle(isEnemyTrainer);
                return true;
            }
            else
            {
                SetCurrentToSendNextPokemon(isEnemyTrainer);
                return false;
            }
        }

        private void FinishBattle(bool enemyTrainerLost)
        {
            if (enemyTrainerLost)
            {
                ConsoleBattleInfoTrainer.TrainerHasNoPokemonLeft(EnemyTrainer);
                ConsoleBattleInfoTrainer.ShowTrainerWins(Player);
            }
            else
            {
                ConsoleBattleInfoTrainer.TrainerHasNoPokemonLeft(Player);
                ConsoleBattleInfoTrainer.ShowTrainerWins(EnemyTrainer);
            }
        }

        private void SetCurrentToSendNextPokemon(bool isEnemyTrainer) {
            ITrainer trainer = isEnemyTrainer ? EnemyTrainer : Player;
            trainer.SetPokemonAsCurrent(trainer.GetNextAvailablePokemon());
        }

        internal void ShowTrainerSentPokemonMessage(bool isEnemyTrainer) 
        {
            ITrainer trainer = isEnemyTrainer ? EnemyTrainer : Player;

            if (isEnemyTrainer)
            {
                EnemyAction.EnemyTrainerSendsPokemon(trainer);
            }
            else
            {
                PlayerAction.PlayerSendsPokemon(Player.GetCurrentPokemon());
            }
        }

        public int KeepPlayerChoosingMove(int movesLimit)
        {
            int chosenMove = -1;
            
            IPokemon currentPokemon = Player.GetCurrentPokemon();

            while (chosenMove <= -1 || chosenMove > movesLimit)
            {
                ConsoleBattleInfo.WriteAllAvailableAttacksOnConsole(currentPokemon);
                chosenMove = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenMove;
        }

        public int KeepPlayerChoosingItem(int limitOfItemStacksInTheInventory)
        {
            int chosenItem = -1;
            
            while (chosenItem <= -1 || chosenItem > limitOfItemStacksInTheInventory)
            {
                ConsoleBattleInfo.WriteAllAvailableItemsOnConsole(Player);
                chosenItem = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenItem;
        }

        public int KeepPlayerChoosingPokemon()
        {
            int chosenPokemonIndex = -1;
            
            while (chosenPokemonIndex <= -1 || IsNotValidPokemonIndex(chosenPokemonIndex))
            {
                ConsoleBattleInfoTrainer.ShowAllTrainersPokemon(Player);
                chosenPokemonIndex = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenPokemonIndex;
        }

        public void ShowPlayerCurrentPokemonStatus()
        {
            IPokemon currentPokemon = Player.GetCurrentPokemon();
            ConsoleBattleInfo.WritePokemonStats(currentPokemon);

            Console.WriteLine("Press Enter to continue battle...");
            Console.ReadLine();
        }

        // This method uses a "try-catch" structure so if the player chooses an index that's outside
        // the bounds of the array, it doesn't break the game. The other methods
        // have constant or customizable limit of array indexes when choosing.
        private bool IsNotValidPokemonIndex(int trainerPokemonIndex)
        {
            try
            {
                return Player.PokemonTeam[trainerPokemonIndex] == null;
            } 
            catch 
            {
                return true; 
            }
        }

        public void ShowDrawbackMessageAndSetChosenPokemonIndexAsCurrent(int chosenPokemon)
        {
            PlayerAction.PlayerDrawsbackPokemon(Player.GetCurrentPokemon());
            Player.SetPokemonAsCurrent(Player.PokemonTeam[chosenPokemon].Pokemon);
        }

        public static void ProcessStatusAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            StatusMove[] pokemonAlteredStatuses = StatusMoveManager.ProcessStatusMove(attackingPokemon, targetPokemon, move);

            if (move.MoveTarget.Value == StatusMoveTarget.SELF)
            {
                ConsoleBattleInfoStatuses.ShowInflictedStatuses(attackingPokemon, pokemonAlteredStatuses);
            }
            else
            {
                ConsoleBattleInfoStatuses.ShowInflictedStatuses(targetPokemon, pokemonAlteredStatuses);
            }
        }
    }
}
