using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Types;
using Xunit;

namespace PokemonAdventureGame.Tests
{
    public class FormulaTests
    {
        [Fact]
        public void ShouldDealMoreThanFiftyDamagePoints()
        {
            IPokemon attackingPokemon = PokemonFactory.CreatePokemon<Venusaur>();
            IPokemon targetPokemon = PokemonFactory.CreatePokemon<Golem>();

            TypeEffect effectOfTypeOnTargetPokemon = TypeComparer.CompareGrassType(targetPokemon.Types[0]);

            int totalDamage = TypeDamageCalculator.CalculateDamage(
                attackingPokemon,
                targetPokemon,
                attackingPokemon.Moves[3],
                effectOfTypeOnTargetPokemon
            );

            Assert.True(totalDamage > 50);
        }

        [Fact]
        public void ShouldMoreThanTwentyButLessThanFiftyDamagePoints()
        {
            IPokemon attackingPokemon = PokemonFactory.CreatePokemon<Gengar>();
            IPokemon targetPokemon = PokemonFactory.CreatePokemon<Pidgeot>();

            TypeEffect effectOfTypeOnTargetPokemon = TypeComparer.CompareGhostType(targetPokemon.Types[0]);

            int totalDamage = TypeDamageCalculator.CalculateDamage(
                attackingPokemon,
                targetPokemon,
                attackingPokemon.Moves[2],
                effectOfTypeOnTargetPokemon
            );

            Assert.True(totalDamage >= 20 && totalDamage < 50);

            totalDamage = TypeDamageCalculator.CalculateDamage(
                attackingPokemon,
                targetPokemon,
                attackingPokemon.Moves[1],
                effectOfTypeOnTargetPokemon
            );

            Assert.True(totalDamage >= 20 && totalDamage < 50);
        }

        [Fact]
        public void ShouldDealLessOrEqualToTwentyDamage()
        {
            IPokemon attackingPokemon = PokemonFactory.CreatePokemon<Pikachu>();
            IPokemon targetPokemon = PokemonFactory.CreatePokemon<Onix>();

            TypeEffect effectOfTypeOnTargetPokemon = TypeComparer.CompareElectricType(targetPokemon.Types[0]);

            int totalDamage = TypeDamageCalculator.CalculateDamage(
                attackingPokemon,
                targetPokemon,
                attackingPokemon.Moves[1],
                effectOfTypeOnTargetPokemon
            );

            Assert.True(totalDamage <= 20);

            totalDamage = TypeDamageCalculator.CalculateDamage(
                attackingPokemon,
                targetPokemon,
                attackingPokemon.Moves[2],
                effectOfTypeOnTargetPokemon
            );

            Assert.True(totalDamage <= 20);
        }
    }
}
