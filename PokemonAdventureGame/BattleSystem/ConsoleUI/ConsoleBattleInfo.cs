using System;
using System.Linq;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfo
    {
        #region Private Properties

        private readonly static PlayerAction _playerMovement = new PlayerAction();
        private readonly static EnemyAction _enemyMovement = new EnemyAction();

        #endregion 

        #region General Information

        public static void ShowAvailableCommandsOnConsole()
        {
            Console.WriteLine($"{(int)Command.ATTACK}: {Command.ATTACK.ToString()}");
            Console.WriteLine($"{(int)Command.SWITCH_POKEMON}: {Command.SWITCH_POKEMON.ToString().Replace("_", " ")}");
            Console.WriteLine($"{(int)Command.ITEMS}: {Command.ITEMS.ToString()}");
        }

        public static void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose your attack!");
            for (int i = 0; i < pokemon.Moves.Count; i++)
                Console.WriteLine($"{i}: {pokemon.Moves[i].GetType().Name} | PP: {pokemon.Moves[i].CurrentPowerPoints}");
        }

        public static void WriteAllAvailableItemsOnConsole(ITrainer player)
        {
            ConsoleUtils.ShowMessageBetweenEmptyLines("Choose an item!");
            for (int i = 0; i < player.Items.Count; i++)
                Console.WriteLine($"{i}: {player.Items.ElementAt(i).Key} - Remaining: {player.Items.ElementAt(i).Value.Count}");
        }

        #endregion

        #region Pokemon Related Information

        public static void ShowPokemonUsedMove(IPokemon pokemon, string moveName)
            => ConsoleBattleInfoPokemon.ShowPokemonUsedMove(pokemon, moveName);

        public static void ShowPokemonReceivedDamage(IPokemon pokemon, int damage)
            => ConsoleBattleInfoPokemon.ShowPokemonReceivedDamage(pokemon, damage);

        public static void ShowBothPokemonStats(IPokemon playerPokemon, IPokemon enemyPokemon)
            => ConsoleBattleInfoPokemon.ShowBothPokemonStats(playerPokemon, enemyPokemon);

        public static void ShowChosenPokemonIsNotAvailable() => ConsoleBattleInfoPokemon.ShowChosenPokemonIsNotAvailable();

        #endregion

        #region Trainer Related Information

        public static void EnemyTrainerWantsToBattle(ITrainer enemyTrainer)
            => ConsoleBattleInfoTrainer.EnemyTrainerWantsToBattle(enemyTrainer);

        public static void ShowTrainerWins(ITrainer trainer)
           => ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} wins!");

        public static void TrainerHasNoPokemonLeft(ITrainer trainer) => ConsoleBattleInfoTrainer.TrainerHasNoPokemonLeft(trainer);

        public static void ShowPlayerThereAreNoPokemonLeftToSwitch()
            => ConsoleBattleInfoTrainer.ShowPlayerThereAreNoPokemonLeftToSwitch();

        public static void ShowAllTrainersPokemon(ITrainer trainer) => ConsoleBattleInfoTrainer.ShowAllTrainersPokemon(trainer);

        public static void TrainerDrawsbackPokemon(IPokemon pokemon, bool isEnemyTrainer = false)
            => ConsoleBattleInfoTrainer.TrainerDrawsbackPokemon(pokemon, _enemyMovement, _playerMovement, isEnemyTrainer);

        public static void PlayerSendsPokemon(IPokemon pokemon) => _playerMovement.PlayerSendsPokemon(pokemon);
        public static void EnemyTrainerSendsPokemon(ITrainer enemyTrainer) => _enemyMovement.EnemyTrainerSendsPokemon(enemyTrainer);

        #endregion

        #region Types, moves and statuses related information

        public static void ShowHowEffectiveTheMoveWas(TypeEffect typeEffect) => ConsoleBattleInfoTypes.ShowHowEffectiveTheMoveWas(typeEffect);

        public static void ShowInflictedStatuses(IPokemon targetPokemon, StatusMove[] statusMoves)
           => ConsoleBattleInfoStatuses.ShowInflictedStatuses(targetPokemon, statusMoves);

        public static void ShowChosenPokemonIsAlreadyInBattle()
            => ConsoleBattleInfoPokemon.ShowChosenPokemonIsAlreadyInBattle();

        public static bool MoveDoesNotHavePowerPointsLeft(IMove move) => ConsoleBattleInfoMove.MoveDoesNotHavePowerPointsLeft(move);

        #endregion

        #region Items 

        public static void ShowItemWasUsedOnPokemon(IItem item, IPokemon pokemon) => ConsoleBattleInfoItems.ShowItemWasUsedOnPokemon(item, pokemon);

        public static void ShowItemCannotBeUsed() => ConsoleBattleInfoItems.ShowItemCannotBeUsed();

        #endregion
    }
}