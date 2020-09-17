using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.ParameterObjects.Types
{
    public struct InitialDamageParameter
    {
        public IPokemon AttackingPokemon { get; set; }
        public IPokemon TargetPokemon { get; set; }
        public decimal Modifier { get; set; }
        public IMove Move { get; set; }

        public InitialDamageParameter(IPokemon attackingPokemon, IPokemon targetPokemon, decimal modifier, IMove move)
        {
            AttackingPokemon = attackingPokemon;
            TargetPokemon = targetPokemon;
            Modifier = modifier;
            Move = move;
        }
    }
}
