using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.ParameterObjects.Types
{
    public class InitialDamageParameter
    {
        public IPokemon AttackingPokemon { get; set; }
        public IPokemon TargetPokemon { get; set; }
        public float Modifier { get; set; }
        public IMove Move { get; set; }

        public InitialDamageParameter(IPokemon attackingPokemon, IPokemon targetPokemon, float modifier, IMove move)
        {
            Move = move;
            Modifier = modifier;
            TargetPokemon = targetPokemon;
            AttackingPokemon = attackingPokemon;
        }
    }
}
