using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.Trainers;
using System.Linq;
using Xunit;

namespace PokemonAdventureGame.Tests.Battles
{
    public class LanceBattleTests
    {
        [Fact]
        public void LanceFirstPokemon()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Lance>();

            IPokemon currentPokemon = BattleTestUtils.GetCurrentPokemonForBattle(trainer);

            BattleTestUtils.AssertPokemonAndNotFainted<Gyarados>(currentPokemon);
        }

        [Fact]
        public void LanceSecondPokemon()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Lance>();

            // Simulate Gyarados fainting
            TrainerPokemon gyarados = trainer.PokemonTeam.FirstOrDefault(x => x.Pokemon is Gyarados);
            gyarados.Fainted = true;

            // Check next Pokemon is Dragonite
            IPokemon currentPokemon = BattleTestUtils.GetCurrentPokemonForBattle(trainer);

            BattleTestUtils.AssertPokemonAndNotFainted<Dragonite>(currentPokemon);
        }

        [Fact]
        public void LanceThirdPokemon()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Lance>();

            // Simulate Gyarados fainting
            BattleTestUtils.FaintPokemon<Gyarados>(trainer);

            // Simulate first Dragonite fainting
            TrainerPokemon firstDragonite = trainer.PokemonTeam.FirstOrDefault(x => x.Pokemon is Dragonite);
            BattleTestUtils.FaintSpecificPokemon(firstDragonite);

            // Check next Pokemon is Dragonite
            IPokemon currentPokemon = BattleTestUtils.GetCurrentPokemonForBattle(trainer);

            BattleTestUtils.AssertPokemonAndNotFainted<Dragonite>(currentPokemon);
        }

        [Fact]
        public void LanceAllDragoniteDown()
        {
            ITrainer trainer = TrainerFactory.CreateTrainer<Lance>();

            // Simulate Gyarados fainting
            BattleTestUtils.FaintPokemon<Gyarados>(trainer);

            // Simulate all Dragonites fainting
            trainer.PokemonTeam
                .Where(x => x.Pokemon is Dragonite)
                .ToList()
                .ForEach(x => BattleTestUtils.FaintSpecificPokemon(x));

            // Check next Pokemon is Dragonite
            IPokemon currentPokemon = BattleTestUtils.GetCurrentPokemonForBattle(trainer);

            BattleTestUtils.AssertPokemonAndNotFainted<Aerodactyl>(currentPokemon);
        }
    }
}
