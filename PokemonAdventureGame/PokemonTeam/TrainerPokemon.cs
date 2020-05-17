﻿using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.PokemonTeam
{
    public class TrainerPokemon
    {
        public bool Current { get; set; }
        public bool Fainted { get; set; }
        public IPokemon Pokemon { get; set; }
        public TrainerPokemon(IPokemon pokemon, bool current = false) 
        {
            Pokemon = pokemon;
            Current = current;
        }
        public void SetAsCurrent() => Current = true;
        public void Drawback() => Current = false;
        public void SetAsFainted() => Fainted = true;
    }
}
