using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Trainers
{
    public class Red : ITrainer
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
                new TrainerPokemon(PokemonFactory.CreatePokemon<Pikachu>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Espeon>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Blastoise>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Charizard>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Lapras>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Venusaur>())
            };
        }

        public void InitializeTrainerItems() { }

        public IPokemon GetCurrentPokemon() => PokemonTeam.FirstOrDefault(pkmn => pkmn.Current)?.Pokemon;

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

        public void ShowTrainerDialogue()
        {
            RedsDialogue();
            ConsoleBattleInfoTrainer.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory() => RedsDialogue();

        public void ShowFinalDialogueForLoss() => RedsDialogue();

        private static void RedsDialogue()
        {
            ConsoleUtils.TrainerAction<EnemyAction>("...");
            ConsoleUtils.WaitFourSeconds();
        }
    }
}
