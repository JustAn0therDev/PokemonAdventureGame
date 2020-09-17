using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.PokemonTeam
{
    public class TrainerPokemon
    {
        public bool Current { get; set; }
        public bool Fainted { get; set; }
        public IPokemon Pokemon { get; set; }
        public TrainerPokemon(IPokemon pokemon)
        {
            Pokemon = pokemon;
        }
        public void SetAsCurrent() => Current = true;
        public void SetAsFainted() => Fainted = true;
    }
}
