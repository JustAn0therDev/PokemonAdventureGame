using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Trainers
{
    public class Player : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public IPokemon RewardPokemonForWinning => null;

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Venusaur>())
            };
        }

        public IPokemon GetCurrentPokemon()
            => PokemonTeam.Where(pkmn => pkmn.Current).Select(s => s.Pokemon).FirstOrDefault();

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

        public void ShowTrainerDialogue()
        {
            throw new System.NotImplementedException();
        }

        public void ShowFinalDialogueForVictory()
        {
            throw new System.NotImplementedException();
        }

        public void ShowFinalDialogueForLoss()
        {
            throw new System.NotImplementedException();
        }
    }
}
