using System;
using System.Collections.Generic;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfo
    {
        private static PlayerAction _playerMovement = new PlayerAction();
        private static EnemyAction _enemyMovement = new EnemyAction();

        public static void PlayerSendsPokemon(IPokemon pokemon) => _playerMovement.PlayerSendsPokemon(pokemon);
        public static void EnemyTrainerSendsPokemon(ITrainer enemyTrainer, IPokemon pokemon) => _enemyMovement.EnemyTrainerSendsPokemon(enemyTrainer, pokemon);
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
            Console.WriteLine($"{(int)Command.RUN}: {Command.RUN.ToString()}");
        }

        public static void ShowPokemonUsedMove(IPokemon pokemon, string moveName)
        {
            Console.WriteLine($"{pokemon.GetType().Name} used {moveName}!");
            ConsoleUtils.WaitTwoSeconds();
            ConsoleUtils.SkipLine();
        }

        public static void ShowPokemonReceivedDamage(IPokemon pokemon, int damage)
        {
            Console.WriteLine($"{pokemon.GetType().Name} took {damage} damage!");
            ConsoleUtils.WaitTwoSeconds();
            ConsoleUtils.SkipLine();
        }

        public static void WriteAllAvailableAttacksOnConsole(IPokemon pokemon)
        {
            ConsoleUtils.SkipLine();
            Console.WriteLine("Choose your attack!");
            ConsoleUtils.SkipLine();

            for (int i = 0; i < pokemon.Moves.Count; i++)
                Console.WriteLine($"{i}: {pokemon.Moves[i].GetType().Name} | PP: {pokemon.Moves[i].PowerPoints}");
        }

        public static int GetPlayerChosenInput(string userInput)
        {
            ConsoleUtils.ClearScreen();
            return int.TryParse(userInput, out int chosenMove) ? chosenMove : -1;
        }

        public static void ShowTrainerWins(ITrainer trainer)
        {
            Console.WriteLine($"{trainer.GetType().Name} wins!");
            ConsoleUtils.SkipLine();
        }

        public static void TrainerHasNoPokemonLeft(ITrainer trainer)
        {
            ConsoleUtils.ClearScreen();
            Console.WriteLine($"{trainer.GetType().Name} has no other pokemon left to battle...");
            ConsoleUtils.SkipLine();
        }

        public static void ShowHowEffectiveTheMoveWas(TypeEffect typeEffect, IPokemon pokemon)
        {
            switch (typeEffect)
            {
                case TypeEffect.IMMUNE:
                    MovementDidntAffectPokemon(pokemon);
                    break;
                case TypeEffect.NOT_VERY_EFFECTIVE:
                    MovementIsNotVeryEffective();
                    break;
                case TypeEffect.SUPER_EFFECTIVE:
                    MovementIsSuperEffective();
                    break;
            }
        }

        private static void MovementIsNotVeryEffective()  
        { 
            Console.WriteLine("It's not very effective..."); 
            ConsoleUtils.WaitOneSecond();
        }
        private static void MovementIsSuperEffective() 
        {
            Console.WriteLine("It's super effective!"); 
            ConsoleUtils.WaitOneSecond();
        }

        public static void MovementDidntAffectPokemon(IPokemon pokemon)
        {
            Console.WriteLine($"It didn't affect {pokemon.GetType().Name}!");
            ConsoleUtils.WaitOneSecond();
        }

        public static void MovementIsOutOfPowerPoints() => Console.WriteLine("The chosen move is out of Power Points!");

        public static void ShowAllTrainersPokemon(ITrainer trainer)
        {
            for (int i = 0; i < trainer.PokemonTeam.Count; i++)
                Console.WriteLine($"{i} - {trainer.PokemonTeam[i].Pokemon.GetType().Name}");
        }

        public static void PokemonUnavailable() => Console.WriteLine("The chosen pokemon is not available, please select another!");
        
        public static void ShowPlayerThereAreNoPokemonLeft() 
        {
            Console.WriteLine("There are no other pokemon left to battle!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        }

        public static void ShowInflictedStatuses(IPokemon targetPokemon, List<StatusMove> statusMoves) 
        {
            for (int i = 0; i < statusMoves.Count; i++)
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
                ConsoleUtils.WaitOneSecond();
            }
        }

        public static void ShowChosenPokemonIsAlreadyInBattle() 
        {
            Console.WriteLine("The chosen pokemon is already in battle!");
            ConsoleUtils.WaitOneSecond();
            ConsoleUtils.ClearScreen();
        } 
    }
}