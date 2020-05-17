using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Trainers
{
    public class Gary : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon> 
            { 
                new TrainerPokemon(PokemonFactory.CreatePokemon<Eevee>(), true) 
            };
        }

        public IPokemon GetCurrentPokemon()
            => PokemonTeam.Where(pkmn => pkmn.Current).Select(s => s.Pokemon).FirstOrDefault();
        public void SetPokemonAsCurrent(TrainerPokemon trainerPokemon)
        {
            PokemonTeam.ForEach(pkmn => 
            { 
                if (pkmn.Current) 
                    pkmn.Current = false;

                if (pkmn.GetType().Name == trainerPokemon.GetType().Name)
                    pkmn.Current = true;
            });
        }

        public void SetFirstAvailablePokemonAsCurrent()
            => SetPokemonAsCurrent(PokemonTeam.Where(pkmn => !pkmn.Fainted).FirstOrDefault());

    }
}
