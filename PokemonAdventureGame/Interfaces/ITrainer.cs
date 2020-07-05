using System.Collections.Generic;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Interfaces
{
    public interface ITrainer
    {
        List<TrainerPokemon> PokemonTeam { get; set; }
        void InitializeTrainer();
        void InitializeTrainerTeam();
        void InitializeTrainerItems();
        IPokemon GetCurrentPokemon();
        void SetPokemonAsCurrent(IPokemon trainerPokemon);
        bool HasAvailablePokemon();
        IPokemon GetNextAvailablePokemon();
        void SetPokemonAsFainted(IPokemon pokemon);
        void ShowTrainerDialogue();
        void ShowFinalDialogueForVictory();
        void ShowFinalDialogueForLoss();
        IPokemon RewardPokemonForWinning { get; }
        Dictionary<string, List<IItem>> Items { get; set; }
    }
}
