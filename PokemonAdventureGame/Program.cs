using System;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.BattleSystem;

namespace PokemonAdventureGame
{
    class Program
    {
        static void Main()
        {
            try
            {
                IPokemon pikachu = PokemonFactory.CreatePokemon<Pikachu>();

                IPokemon eevee = PokemonFactory.CreatePokemon<Eevee>();

                //TODO: be able to switch first and second pokemon.
                //The Battle class might receive two lists of IPokemon implementations to manage both player's teams
                Battle battle = new Battle(pikachu, eevee);

                battle.MainBattleMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something bad happened in the game! Please report the error. Error: {ex.Message}");
            }
        }
    }
}
