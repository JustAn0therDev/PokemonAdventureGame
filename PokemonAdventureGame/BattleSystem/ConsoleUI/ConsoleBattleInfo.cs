using System;
using System.Linq;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfo
    {
        private readonly static PlayerAction _playerMovement = new PlayerAction();
        private readonly static EnemyAction _enemyMovement = new EnemyAction();

        public static void PlayerSendsPokemon(IPokemon pokemon) => _playerMovement.PlayerSendsPokemon(pokemon);
        public static void EnemyTrainerSendsPokemon(ITrainer enemyTrainer) => _enemyMovement.EnemyTrainerSendsPokemon(enemyTrainer);

        public static void TrainerDrawsbackPokemon(IPokemon pokemon, bool isEnemyTrainer = false)
        {
            if (isEnemyTrainer)
                _enemyMovement.EnemyTrainerChangesPokemon(pokemon);
            else
                _playerMovement.PlayerChangesPokemon(pokemon);
        }

        public static void EnemyTrainerWantsToBattle(ITrainer enemyTrainer)
        {
            Console.WriteLine($"{enemyTrainer.GetType().Name} wants to battle!");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        public static void ShowBothPokemonStats(IPokemon playerPokemon, IPokemon enemyPokemon)
        {
            //TODO: Show status ailments in front of the Pokémon's HP.
            ConsoleUtils.TrainerAction<EnemyAction>($"{enemyPokemon.GetType().Name} - HP: {enemyPokemon.CurrentHealthPoints}/{enemyPokemon.HealthPoints}");
            ConsoleUtils.TrainerAction<PlayerAction>($"{playerPokemon.GetType().Name} - HP: {playerPokemon.CurrentHealthPoints}/{playerPokemon.HealthPoints}");
        }

        public static void ShowAvailableCommandsOnConsole()
        {
            Console.WriteLine($"{(int)Command.ATTACK}: {Command.ATTACK.ToString()}");
            Console.WriteLine($"{(int)Command.SWITCH_POKEMON}: {Command.SWITCH_POKEMON.ToString().Replace("_", " ")}");
            Console.WriteLine($"{(int)Command.ITEMS}: {Command.ITEMS.ToString()}");
        }

        public static void ShowPokemonUsedMove(IPokemon pokemon, string moveName)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemon.GetType().Name} used {moveName}!");
            ConsoleUtils.SkipLine();
        }

        public static void ShowPokemonReceivedDamage(IPokemon pokemon, int damage)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemon.GetType().Name} took {damage} damage!");
            ConsoleUtils.SkipLine();
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

        public static void ShowTrainerWins(ITrainer trainer)
            => ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} wins!");

        public static void TrainerHasNoPokemonLeft(ITrainer trainer)
        {
            ConsoleUtils.ClearScreen();
            ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} has no other pokemon left to battle...");
        }

        public static void ShowHowEffectiveTheMoveWas(TypeEffect typeEffect) => ConsoleBattleInfoTypes.ShowHowEffectiveTheMoveWas(typeEffect);

        public static void ShowAllTrainersPokemon(ITrainer trainer)
        {
            for (int i = 0; i < trainer.PokemonTeam.Count; i++)
            {
                Console.WriteLine(
                    $"{i} - {trainer.PokemonTeam[i].Pokemon.GetType().Name} - HP: {trainer.PokemonTeam[i].Pokemon.CurrentHealthPoints}/{trainer.PokemonTeam[i].Pokemon.HealthPoints}"
                    );
            }
        }

        public static void ShowChosenPokemonIsNotAvailable() => Console.WriteLine("The chosen pokemon is not available, please select another!");

        public static void ShowPlayerThereAreNoPokemonLeftToSwitch()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("There are no other pokemon left to battle!");
            ConsoleUtils.ClearScreen();
        }

        public static void ShowInflictedStatuses(IPokemon targetPokemon, StatusMove[] statusMoves) => ConsoleBattleInfoStatuses.ShowInflictedStatuses(targetPokemon, statusMoves);

        public static void ShowChosenPokemonIsAlreadyInBattle()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("The chosen pokemon is already in battle!");
            ConsoleUtils.ClearScreen();
        }

        public static bool MoveDoesNotHavePowerPointsLeft(IMove move)
        {
            if (move.CurrentPowerPoints == 0)
            {
                Console.WriteLine("The chosen move is out of Power Points!");
                return true;
            }

            return false;
        }

        #region Items 

        public static void ShowItemWasUsedOnPokemon(IItem item, IPokemon pokemon)
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{item.GetType().Name} was used on {pokemon.GetType().Name}!");
            ConsoleUtils.ClearScreen();
        }

        public static void ShowItemCannotBeUsed()
        {
            ConsoleUtils.ShowMessageAndWaitTwoSeconds("The selected item cannot be used on the Pokemon!");
            ConsoleUtils.ClearScreen();
        }

        #endregion
    }
}