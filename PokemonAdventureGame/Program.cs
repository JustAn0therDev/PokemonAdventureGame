using System;

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

            Pokemon pikachu = PokemonFactory.CreatePokemonStatsByIndex(23);
            Pokemon eevee = PokemonFactory.CreatePokemonStatsByIndex(133);

            Console.WriteLine(pikachu.ToString());
            Console.WriteLine(eevee.ToString());
        }
    }
}
