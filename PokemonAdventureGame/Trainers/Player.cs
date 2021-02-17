using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Items;

namespace PokemonAdventureGame.Trainers
{
    public class Player : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }
        public IPokemon RewardPokemonForWinning => null;
        public Dictionary<string, List<IItem>> Items { get; set; }

        public void InitializeTrainer()
        {
            InitializeTrainerTeam();
            InitializeTrainerItems();
        }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Venusaur>())
            };
        }

        public void InitializeTrainerItems()
        {
            Items = new Dictionary<string, List<IItem>>
            {
                {  "Potions", ItemFactory.CreateItems<Potion>(10).ToList() }
            };
        }

        public IPokemon GetCurrentPokemon() => PokemonTeam.FirstOrDefault(pkmn => pkmn.Current)?.Pokemon;

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            Parallel.ForEach(PokemonTeam, pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name)
                    pkmn.Current = true;
            });
        }

        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Any();

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.FirstOrDefault(pkmn => !pkmn.Fainted)?.Pokemon;

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public void SetPokemonAsFainted(IPokemon pokemon) 
        { 
            var foundPokemon = PokemonTeam.FirstOrDefault(fd => fd.Pokemon == pokemon);

            if (foundPokemon != null) 
            { 
                foundPokemon.Fainted = true; 
            }
        }

        public void ShowTrainerDialogue() =>
            throw new System.NotImplementedException();

        public void ShowFinalDialogueForVictory() =>
            throw new System.NotImplementedException();

        public void ShowFinalDialogueForLoss() =>
            throw new System.NotImplementedException();
    }
}
