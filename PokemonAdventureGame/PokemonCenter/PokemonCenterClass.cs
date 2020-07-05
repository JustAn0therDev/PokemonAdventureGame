﻿using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.PokemonCenter
{
    public static class PkmnCenter
    {
        public static void HealPlayerTeam(ITrainer player)
        {
            player.PokemonTeam.ForEach(pkmn =>
            {
                pkmn.Fainted = false;
                pkmn.Pokemon.CurrentHealthPoints = pkmn.Pokemon.HealthPoints;
                pkmn.Pokemon.Moves.ForEach(move => move.CurrentPowerPoints = move.PowerPoints);
            });
        }
    }
}
