using System;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public class ConsoleBattleInfoMove
    {
        public static bool MoveDoesNotHavePowerPointsLeft(IMove move)
        {
            if (move.CurrentPowerPoints == 0)
            {
                Console.WriteLine("The chosen move is out of Power Points!");
                return true;
            }

            return false;
        }
    }
}
