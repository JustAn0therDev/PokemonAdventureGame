using System;

using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Statuses;

namespace PokemonAdventureGame.BattleSystem
{
    //This class contains every method that does not depend on an order of execution.
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

            ConsoleBattleInfo.TrainerDrawsbackPokemon(trainer.GetCurrentPokemon(), isEnemyTrainer);

            if (trainer.GetNextAvailablePokemon() == null)
            {
                if (isEnemyTrainer)
                    FinishBattle(_player, _enemyTrainer);
                else
                    FinishBattle(_enemyTrainer, _player);

                return true;
            }
            else
            {
                SetCurrentToSendNextPokemon(trainer, isEnemyTrainer);
                return false;
            }
        }

        private void FinishBattle(ITrainer winner, ITrainer loser)
        {
            ConsoleBattleInfo.TrainerHasNoPokemonLeft(loser);
            ConsoleBattleInfo.ShowTrainerWins(winner);
        }

        private void SetCurrentToSendNextPokemon(ITrainer trainer, bool isEnemyTrainer)
        {
            trainer.SetPokemonAsCurrent(trainer.GetNextAvailablePokemon());

            if (isEnemyTrainer)
                ConsoleBattleInfo.EnemyTrainerSendsPokemon(trainer);
            else
                ConsoleBattleInfo.PlayerSendsPokemon(trainer.GetCurrentPokemon());
        }

        public int KeepPlayerChoosingMove(int movesLimit)
        {
            int chosenMove = -1;
            IPokemon playerCurrentPokemon = _player.GetCurrentPokemon();

            while (chosenMove <= -1 || chosenMove > movesLimit)
            {
                ConsoleBattleInfo.WriteAllAvailableAttacksOnConsole(playerCurrentPokemon);
                chosenMove = ConsoleBattleInfo.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenMove;
        }

        public int KeepPlayerChoosingItem(ITrainer player, int limitOfItemStacksInTheInventory)
        {
            int chosenItem = -1;
            while (chosenItem <= -1 || chosenItem > limitOfItemStacksInTheInventory)
            {
                ConsoleBattleInfo.WriteAllAvailableItemsOnConsole(player);
                chosenItem = ConsoleBattleInfo.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenItem;
        }

        public int KeepPlayerChoosingPokemonIndex()
        {
            int chosenPokemonIndex = -1;
            while (chosenPokemonIndex == -1 || chosenPokemonIndex > _player.PokemonTeam.Count)
            {
                ConsoleBattleInfo.ShowAllTrainersPokemon(_player);
                chosenPokemonIndex = ConsoleBattleInfo.GetPlayerChosenIndex(Console.ReadLine());
            }

            return chosenPokemonIndex;
        }

        public void DrawbackThenSendPokemon(int chosenPokemon)
        {
            ConsoleBattleInfo.TrainerDrawsbackPokemon(_player.GetCurrentPokemon());
            _player.SetPokemonAsCurrent(_player.PokemonTeam[chosenPokemon].Pokemon);
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());
        }

        public void ProcessStatusAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            StatusMove[] pokemonAlteredStatuses = StatusMoveManager.ProcessStatusMove(attackingPokemon, targetPokemon, move);

            if (move.MoveTarget.Value == StatusMoveTarget.SELF)
                ConsoleBattleInfo.ShowInflictedStatuses(attackingPokemon, pokemonAlteredStatuses);
            else
                ConsoleBattleInfo.ShowInflictedStatuses(targetPokemon, pokemonAlteredStatuses);
        }
    }
}
