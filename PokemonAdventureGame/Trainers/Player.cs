using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAdventureGame.Trainers
{
    public class Player : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon (PokemonFactory.CreatePokemon<Pikachu>(), true) 
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
