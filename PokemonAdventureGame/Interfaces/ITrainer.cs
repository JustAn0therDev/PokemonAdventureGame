using System;
using System.Collections.Generic;
using System.Text;
using PokemonAdventureGame.PokemonTeam;

namespace PokemonAdventureGame.Interfaces
{
    public interface ITrainer
    {
        List<TrainerPokemon> PokemonTeam { get; set; }
        void InitializeTrainerTeam();
        IPokemon GetCurrentPokemon();
        void SetPokemonAsCurrent(TrainerPokemon trainerPokemon);
        void SetFirstAvailablePokemonAsCurrent();
        //void InitializeTrainerItems();
    }
}
