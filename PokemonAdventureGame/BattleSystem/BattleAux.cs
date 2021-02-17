using System;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Statuses;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.BattleSystem
{
    // This class contains every method that does not depend on an order of execution.
    public class BattleAux
    {
        private readonly ITrainer _player;
        private readonly ITrainer _enemyTrainer;

        public BattleAux (ITrainer player, ITrainer enemyTrainer)
        {
            _player = player;
            _enemyTrainer = enemyTrainer;
        }

        public bool CannotSendNextAvailablePokemon(ITrainer trainer, bool isEnemyTrainer = false)
        {
            trainer.SetPokemonAsFainted(trainer.GetCurrentPokemon());
            TrainerDrawsbackPokemon(isEnemyTrainer);
            return TrainerIsOutOfPokemonToBattle(trainer, isEnemyTrainer);
        }

        private void TrainerDrawsbackPokemon(bool isEnemyTrainer)
        {
            if (isEnemyTrainer)
                EnemyAction.EnemyTrainerDrawsbackPokemon(_enemyTrainer.GetCurrentPokemon());
            else
                PlayerAction.PlayerDrawsbackPokemon(_player.GetCurrentPokemon());
        }

        private bool TrainerIsOutOfPokemonToBattle(ITrainer trainer, bool isEnemyTrainer)
        {
            if (trainer.GetNextAvailablePokemon() == null)
            {
                FinishBattle(isEnemyTrainer);
                return true;
            }
            else
            {
                SetCurrentToSendNextPokemon(trainer, isEnemyTrainer);
                return false;
            }
        }

        private void FinishBattle(bool enemyTrainerLost)
        {
            if (enemyTrainerLost)
            {
                ConsoleBattleInfoTrainer.TrainerHasNoPokemonLeft(_enemyTrainer);
                ConsoleBattleInfoTrainer.ShowTrainerWins(_player);
            }
            else
            {
                ConsoleBattleInfoTrainer.TrainerHasNoPokemonLeft(_enemyTrainer);
                ConsoleBattleInfoTrainer.ShowTrainerWins(_player);
            }
        }

        private void SetCurrentToSendNextPokemon(ITrainer trainer, bool isEnemyTrainer)
        {
            trainer.SetPokemonAsCurrent(trainer.GetNextAvailablePokemon());

            if (isEnemyTrainer)
                EnemyAction.EnemyTrainerSendsPokemon(trainer);
            else
                PlayerAction.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        public int KeepPlayerChoosingMove(int movesLimit)
        {
            int chosenMove = -1;
            IPokemon playerCurrentPokemon = _player.GetCurrentPokemon();

            while (chosenMove <= -1 || chosenMove > movesLimit)
            {
                ConsoleBattleInfo.WriteAllAvailableAttacksOnConsole(playerCurrentPokemon);
                chosenMove = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenMove;
        }

        public static int KeepPlayerChoosingItem(ITrainer player, int limitOfItemStacksInTheInventory)
        {
            int chosenItem = -1;
            while (chosenItem <= -1 || chosenItem > limitOfItemStacksInTheInventory)
            {
                ConsoleBattleInfo.WriteAllAvailableItemsOnConsole(player);
                chosenItem = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenItem;
        }

        public int KeepPlayerChoosingPokemonIndex()
        {
            int chosenPokemonIndex = -1;
            while (chosenPokemonIndex <= -1 || IsNotValidIndexForPlayerPokemonTeam(chosenPokemonIndex))
            {
                ConsoleBattleInfoTrainer.ShowAllTrainersPokemon(_player);
                chosenPokemonIndex = ConsoleUtils.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenPokemonIndex;
        }

        // This method is used so if the player chooses an index that's outside
        // the bounds of the array, it doesn't break the game. The other methods
        // have constant or customizable limit of array indexes when choosing.
        private bool IsNotValidIndexForPlayerPokemonTeam(int trainerPokemonIndex)
        {
            try
            {
                return _player.PokemonTeam[trainerPokemonIndex] == null;
            } catch { return true; }
        }

        public void DrawbackThenSendPokemon(int chosenPokemon)
        {
            PlayerAction.PlayerDrawsbackPokemon(_player.GetCurrentPokemon());
            _player.SetPokemonAsCurrent(_player.PokemonTeam[chosenPokemon].Pokemon);
            PlayerAction.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        public static void ProcessStatusAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            StatusMove[] pokemonAlteredStatuses = StatusMoveManager.ProcessStatusMove(attackingPokemon, targetPokemon, move);

            if (move.MoveTarget.Value == StatusMoveTarget.SELF)
                ConsoleBattleInfoStatuses.ShowInflictedStatuses(attackingPokemon, pokemonAlteredStatuses);
            else
                ConsoleBattleInfoStatuses.ShowInflictedStatuses(targetPokemon, pokemonAlteredStatuses);
        }
    }
}