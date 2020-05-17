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
            IPokemon pikachu = PokemonFactory.CreatePokemon<Pikachu>();

            IPokemon eevee = PokemonFactory.CreatePokemon<Eevee>();

            //TODO: be able to switch first and second pokemon.
            //The Battle class might receive two lists of IPokemon implementations to manage both player's actions
            Battle battle = new Battle(pikachu, eevee);

            battle.PokemonOneMove(Enums.Command.ATTACK);
        }
    }
}
