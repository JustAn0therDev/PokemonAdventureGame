using System;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.Statuses
{
    public static class StatusMoveManager
    {
        private readonly static int POINTS_MODIFIER = 2;
        public static StatusMove[] ProcessStatusMove(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            IPokemon pokemonToChangeStatus = move.MoveTarget == StatusMoveTarget.SELF ? attackingPokemon : targetPokemon;
            
            for (int i = 0; i < move.StatusMoves.Count; i++)
            {
                switch (move.StatusMoves[i])
                {
                    case StatusMove.ATTACK_UP:
                        pokemonToChangeStatus.AttackPoints         += POINTS_MODIFIER;
                        break;
                    case StatusMove.ATTACK_DOWN:
                        pokemonToChangeStatus.AttackPoints         -= POINTS_MODIFIER;
                        break;
                    case StatusMove.DEFENSE_UP:
                        pokemonToChangeStatus.DefensePoints        += POINTS_MODIFIER;
                        break;
                    case StatusMove.DEFENSE_DOWN:
                        pokemonToChangeStatus.DefensePoints        -= POINTS_MODIFIER;
                        break;
                    case StatusMove.SPECIALATTACK_UP:
                        pokemonToChangeStatus.SpecialAttackPoints  += POINTS_MODIFIER;
                        break;
                    case StatusMove.SPECIALATTACK_DOWN:
                        pokemonToChangeStatus.SpecialAttackPoints  -= POINTS_MODIFIER;
                        break;
                    case StatusMove.SPECIALDEFENSE_UP:
                        pokemonToChangeStatus.SpecialDefensePoints += POINTS_MODIFIER;
                        break;
                    case StatusMove.SPECIALDEFENSE_DOWN:
                        pokemonToChangeStatus.SpecialDefensePoints -= POINTS_MODIFIER;
                        break;
                    case StatusMove.SPEED_UP:
                        pokemonToChangeStatus.SpeedPoints          += POINTS_MODIFIER;
                        break;
                    case StatusMove.SPEED_DOWN:
                        pokemonToChangeStatus.SpeedPoints          -= POINTS_MODIFIER;
                        break;
                }
            }

            return move.StatusMoves.ToArray();
        }
    }
}
