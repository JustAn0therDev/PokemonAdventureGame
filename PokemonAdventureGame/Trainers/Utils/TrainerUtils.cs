using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAdventureGame.Trainers.Utils
{
    public static class TrainerUtils
    {
        /// <summary>
        /// Utility that should be used for trainers that have more than 1 Pokemon of the same type.
        /// Lance for instance, has multiple Dragonite.
        /// </summary>
        /// <param name="trainer">Pokemon trainer</param>
        /// <param name="pokemon">Desired Pokemon</param>
        /// <returns>Return selected Pokemon as current.</returns>
        public static void UpdateCurrentBattlePokemon(List<TrainerPokemon> pokemonTeam, IPokemon pokemon)
        {
            // Make all Pokemon in the team not current.
            pokemonTeam.ForEach(p => p.Current = false);

            var currentPokemon = pokemonTeam.FirstOrDefault(p =>
                p.Pokemon.GetType() == pokemon.GetType() && !p.Pokemon.HasFainted());

            if (currentPokemon != null)
            {
                // Make sure only 1 of the same Pokemon is current.
                currentPokemon.Current = true;
            }
        }
    }
}
