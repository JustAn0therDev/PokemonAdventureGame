using System.Threading.Tasks;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.PokemonCenter
{
    public static class PkmnCenter
    {
        public static void HealPlayerTeam(ITrainer player)
        {
            Parallel.ForEach(player.PokemonTeam, pkmn =>
            {
                pkmn.Fainted = false;
                pkmn.Pokemon.CurrentHealthPoints = pkmn.Pokemon.TotalHealthPoints;
                Parallel.ForEach(pkmn.Pokemon.Moves, move => move.CurrentPowerPoints = move.PowerPoints);
            });
        }
    }
}
