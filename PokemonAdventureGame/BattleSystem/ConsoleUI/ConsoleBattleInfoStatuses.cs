using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfoStatuses
    {
        public static void ShowInflictedStatuses(IPokemon pokemonThatHadItsStatusInflicted, StatusMove[] arrayOfInflictedStatuses)
        {
            for (int i = 0; i < arrayOfInflictedStatuses.Length; i++)
            {
                switch (arrayOfInflictedStatuses[i])
                {
                    case StatusMove.ATTACK_UP:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s attack went up!");
                        break;
                    case StatusMove.ATTACK_DOWN:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s attack went down!");
                        break;
                    case StatusMove.DEFENSE_UP:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s defense went up!");
                        break;
                    case StatusMove.DEFENSE_DOWN:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s defense went down!");
                        break;
                    case StatusMove.SPECIALATTACK_UP:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s special attack went up!");
                        break;
                    case StatusMove.SPECIALATTACK_DOWN:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s special attack went down!");
                        break;
                    case StatusMove.SPECIALDEFENSE_UP:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s special defense went up!");
                        break;
                    case StatusMove.SPECIALDEFENSE_DOWN:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s special defense went down!");
                        break;
                    case StatusMove.SPEED_UP:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s speed went up!");
                        break;
                    case StatusMove.SPEED_DOWN:
                        ConsoleUtils.ShowMessageAndWaitTwoSeconds($"{pokemonThatHadItsStatusInflicted.GetType().Name}'s speed went down!");
                        break;
                }
            }
        }
    }
}
