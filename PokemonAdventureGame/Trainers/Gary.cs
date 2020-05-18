using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
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
        public IPokemon GetNextAvailablePokemon() => PokemonTeam.Where(pkmn => !pkmn.Fainted).Select(pkmn => pkmn.Pokemon).FirstOrDefault();
        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Select(s => s).Count() > 0;

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
