using PokemonAdventureGame.Interfaces;
using System;

namespace PokemonAdventureGame.BattleSystem
{
    //TODO-ish: Make the class implement a console interface if it gets too big and used for many other things 
    //rather than managing the battle system in the terminal.
    public static class ConsoleBattleInfo
    {
        public static void ClearScreen() => Console.Clear();

        public static void SendPokemon(ITrainer trainer, IPokemon pokemon)
        {
            SkipLine();
            Console.WriteLine($"{trainer.GetType().Name} sent out {pokemon.GetType().Name}!");
        }

        public static void SkipLine() => Console.WriteLine(string.Empty);
    }
}
