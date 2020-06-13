using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Trainers
{
    public class Bruno : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Onix>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Machamp>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Hitmonlee>())
            };
        }

        public IPokemon GetCurrentPokemon() => PokemonTeam.Where(pkmn => pkmn.Current).Select(s => s.Pokemon).FirstOrDefault();

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name && pkmn.Pokemon.CurrentHealthPoints > 0)
                    pkmn.Current = true;
            });
        }

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.Where(pkmn => !pkmn.Fainted).Select(pkmn => pkmn.Pokemon).FirstOrDefault();

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Count() > 0;

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
