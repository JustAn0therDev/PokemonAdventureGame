using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using System.Linq;
using Xunit;

namespace PokemonAdventureGame.Tests.Battles
{
    public static class BattleTestUtils
    {
        public static void FaintPokemon<TPokemon>(ITrainer trainer)
            where TPokemon : IPokemon
        {
            TrainerPokemon pokemon = trainer.PokemonTeam.FirstOrDefault(x => x.Pokemon is Gyarados);
            FaintSpecificPokemon(pokemon);
        }

        public static void FaintSpecificPokemon(TrainerPokemon pokemon)
        {
            pokemon.Pokemon.ReceiveDamage(9999);
            pokemon.SetAsFainted();
        }

        public static IPokemon GetCurrentPokemonForBattle(ITrainer trainer)
        {
            // This will set the "Current" property to true for the first available Pokemon.
            _ = trainer.GetNextAvailablePokemon();

            // This will return the Pokemon that will be used in the battle.
            // NOTE: This might return a different instance of the Pokemon
            // than "GetNextAvailablePokemon" when multiple of the same are in the team.
            return trainer.GetCurrentPokemon();
        }

        public static void AssertPokemonAndNotFainted<TPokemon>(IPokemon pokemon)
            where TPokemon : IPokemon
        {
            //string pokemonName = typeof(TPokemon).Name;
            //Assert.Equal(pokemonName, pokemon?.GetType().Name);
            Assert.False(pokemon.HasFainted());
            Assert.IsType<TPokemon>(pokemon);
        }
    }
}
