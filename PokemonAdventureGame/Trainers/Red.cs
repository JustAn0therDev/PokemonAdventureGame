﻿using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Trainers
{
    public class Red : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Pikachu>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Espeon>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Blastoise>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Charizard>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Lapras>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Venusaur>())
            };
        }

        public IPokemon GetCurrentPokemon() => PokemonTeam.Where(pkmn => pkmn.Current).Select(s => s.Pokemon).FirstOrDefault();

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name)
                    pkmn.Current = true;
            });
        }
        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Count() > 0;

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.Where(pkmn => !pkmn.Fainted).Select(pkmn => pkmn.Pokemon).FirstOrDefault();

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public void SetPokemonAsFainted(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn => 
            {
                if (pkmn.Pokemon == pokemon)
                    pkmn.Fainted = true;
            });
        }
    }
}