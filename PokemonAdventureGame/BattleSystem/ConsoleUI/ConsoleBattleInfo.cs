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

        public static void Clear() => ConsoleUtils.ClearScreen();

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

        public static int GetPlayerChosenIndex(string userInput)
        {
            ConsoleUtils.ClearScreen();
            return int.TryParse(userInput, out int chosenIndex) ? chosenIndex : -1;
        }

        public static void ShowTrainerWins(ITrainer trainer) 
            => ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} wins!");

        public static void TrainerHasNoPokemonLeft(ITrainer trainer)
        {
            ConsoleUtils.ClearScreen();
            ConsoleUtils.ShowMessageBetweenEmptyLines($"{trainer.GetType().Name} has no other pokemon left to battle...");
        }

        public static void ShowHowEffectiveTheMoveWas(TypeEffect typeEffect, IPokemon pokemon)
        {
            string messageForTypeEffect = string.Empty;
            switch (typeEffect)
            {
                case TypeEffect.IMMUNE:
                    messageForTypeEffect = $"It didn't affect {pokemon.GetType().Name}!";
                    break;
                case TypeEffect.NOT_VERY_EFFECTIVE:
                    messageForTypeEffect = "It's not very effective...";
                    break;
                case TypeEffect.SUPER_EFFECTIVE:
                    messageForTypeEffect = "It's super effective!";
                    break;
            }
            ConsoleUtils.ShowMessageAndWaitOneSecond(messageForTypeEffect);
        }

        public static void MovementIsOutOfPowerPoints() => Console.WriteLine("The chosen move is out of Power Points!");

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

        public static void ShowInflictedStatuses(IPokemon targetPokemon, StatusMove[] statusMoves)
        {
            for (int i = 0; i < statusMoves.Length; i++)
            {
                switch (statusMoves[i])
                {
                    case StatusMove.ATTACK_UP:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s attack went up!");
                        break;
                    case StatusMove.ATTACK_DOWN:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s attack went down!");
                        break;
                    case StatusMove.DEFENSE_UP:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s defense went up!");
                        break;
                    case StatusMove.DEFENSE_DOWN:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s defense went down!");
                        break;
                    case StatusMove.SPECIALATTACK_UP:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s special attack went up!");
                        break;
                    case StatusMove.SPECIALATTACK_DOWN:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s special attack went down!");
                        break;
                    case StatusMove.SPECIALDEFENSE_UP:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s special defense went up!");
                        break;
                    case StatusMove.SPECIALDEFENSE_DOWN:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s special defense went down!");
                        break;
                    case StatusMove.SPEED_UP:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s speed went up!");
                        break;
                    case StatusMove.SPEED_DOWN:
                        Console.WriteLine($"{targetPokemon.GetType().Name}'s speed went down!");
                        break;
                    default:
                        break;
                }
                ConsoleUtils.WaitTwoSeconds();
            }
        }

        public static void ShowChosenPokemonIsAlreadyInBattle()
        {
            ConsoleUtils.ShowMessageAndWaitOneSecond("The chosen pokemon is already in battle!");
            ConsoleUtils.ClearScreen();
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