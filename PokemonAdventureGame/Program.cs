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
            //Criar os dois pokemon que entrarao em batalha 
            //Posterior uso de interfaces?
            //Criar comandos para atacar (depois trocar de pokemon) e dar itens ao pokemon
            //Sistema final de batalha, com ataques que sejam super-efetivos, normais, nao efetivos, status ailments, etc...

            IPokemon pikachu = PokemonFactory.CreatePokemon<Pikachu>();

            IPokemon eevee = PokemonFactory.CreatePokemon<Eevee>();

            //TODO: be able to switch first and second pokemon.
            Battle battle = new Battle(pikachu, eevee);

            battle.PokemonOneMove(Enums.Command.ATTACK);
        }
    }
}
