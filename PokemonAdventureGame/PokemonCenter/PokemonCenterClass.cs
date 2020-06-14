using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.PokemonCenter
{
    public static class PokemonCenterClass
    {
        public static void HealAllPlayerPokemons(ITrainer player)
        {
            player.PokemonTeam.ForEach(pkmn =>
            {
                pkmn.Fainted = false;
                pkmn.Pokemon.CurrentHealthPoints = pkmn.Pokemon.HealthPoints;
            });
        }
    }
}
