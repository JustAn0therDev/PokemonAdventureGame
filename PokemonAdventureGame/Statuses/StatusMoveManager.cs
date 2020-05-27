using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAdventureGame.Statuses 
{
    public static class StatusMoveManager
    {
        private static int MODIFIER = 2;
        public static List<StatusMove> ProcessStatusMove(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            IPokemon pokemonToChangeStatus = move.MoveTarget == StatusMoveTarget.SELF ? attackingPokemon : targetPokemon;

            for (int i = 0; i < move.StatusMoves.Count; i++)
            {
                switch (move.StatusMoves[i])
                {
                    case StatusMove.ATTACK_UP:
                        pokemonToChangeStatus.AttackPoints += MODIFIER;
                        break;
                    case StatusMove.ATTACK_DOWN:
                        pokemonToChangeStatus.AttackPoints -= MODIFIER;
                        break;
                    case StatusMove.DEFENSE_UP:
                        pokemonToChangeStatus.DefensePoints += MODIFIER;
                        break;
                    case StatusMove.DEFENSE_DOWN:
                        pokemonToChangeStatus.DefensePoints -= MODIFIER;
                        break;
                    case StatusMove.SPECIALATTACK_UP:
                        pokemonToChangeStatus.SpecialAttackPoints += MODIFIER;
                        break;
                    case StatusMove.SPECIALATTACK_DOWN:
                        pokemonToChangeStatus.SpecialAttackPoints -= MODIFIER;
                        break;
                    case StatusMove.SPECIALDEFENSE_UP:
                        pokemonToChangeStatus.SpecialDefensePoints += MODIFIER;
                        break;
                    case StatusMove.SPECIALDEFENSE_DOWN:
                        pokemonToChangeStatus.SpecialDefensePoints -= MODIFIER;
                        break;
                    case StatusMove.SPEED_UP:
                        pokemonToChangeStatus.SpeedPoints += MODIFIER;
                        break;
                    case StatusMove.SPEED_DOWN:
                        pokemonToChangeStatus.SpeedPoints -= MODIFIER;
                        break;
                    default:
                        break;
                }
            }

            return move.StatusMoves;
        }
    }
}