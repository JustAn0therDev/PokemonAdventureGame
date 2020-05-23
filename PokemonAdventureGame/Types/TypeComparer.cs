using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame.Types
{
    public static class TypeComparer
    {
        public static TypeEffect GetMoveEffectivenessBasedOnPokemonType(Enums.Type attackingPokemonType, Enums.Type targetPokemonType) 
        {
           switch (attackingPokemonType)
           {
               case Enums.Type.NORMAL:
                   return CompareNormalType(targetPokemonType);
               case Enums.Type.FIGHTING:
                   return CompareFightingType(targetPokemonType);
               case Enums.Type.FLYING:
                   return CompareFlyingType(targetPokemonType);
               case Enums.Type.POISON:
                   return ComparePoisonType(targetPokemonType);
               case Enums.Type.GROUND:
                   return CompareGroundType(targetPokemonType);
               case Enums.Type.ROCK:
                   return CompareRockType(targetPokemonType);
               case Enums.Type.BUG:
                   return CompareBugType(targetPokemonType);
               case Enums.Type.GHOST:
                   return CompareGhostType(targetPokemonType);
               case Enums.Type.STEEL:
                   return CompareSteelType(targetPokemonType);
               case Enums.Type.FIRE:
                   return CompareFireType(targetPokemonType);
               case Enums.Type.WATER:
                   return CompareWaterType(targetPokemonType);
               case Enums.Type.GRASS:
                   return CompareGrassType(targetPokemonType);
               case Enums.Type.ELECTRIC:
                   return CompareElectricType(targetPokemonType);
               case Enums.Type.PSYCHIC:
                   return ComparePsychicType(targetPokemonType);
               case Enums.Type.ICE:
                   return CompareIceType(targetPokemonType);
               case Enums.Type.DRAGON:
                   return CompareDragonType(targetPokemonType);
               case Enums.Type.FAIRY:
                   return CompareFairyType(targetPokemonType);
               case Enums.Type.DARK:
                   return CompareDarkType(targetPokemonType);
               default:
                   return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareNormalType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.ROCK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFightingType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.ICE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.NORMAL:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.PSYCHIC:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DARK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FAIRY:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFlyingType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.ELECTRIC:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect ComparePoisonType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GHOST:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.IMMUNE;
                case Enums.Type.FAIRY:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareGroundType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ELECTRIC:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.IMMUNE;
                case Enums.Type.BUG:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareRockType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ICE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareBugType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.PSYCHIC:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GHOST:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.DARK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FAIRY:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareGhostType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.PSYCHIC:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.NORMAL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GHOST:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareSteelType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.WATER:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ELECTRIC:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FAIRY:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFireType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.WATER:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ICE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareWaterType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.WATER:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareGrassType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.WATER:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.BUG:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.ROCK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareElectricType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.WATER:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ELECTRIC:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GHOST:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.IMMUNE;
                case Enums.Type.FLYING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect ComparePsychicType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.POISON:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.PSYCHIC:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareIceType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.WATER:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GRASS:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.ICE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.GROUND:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.FLYING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareDragonType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.DRAGON:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFairyType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIRE:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FIGHTING:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.POISON:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.DRAGON:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DARK:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareDarkType(Enums.Type targetPokemonType)
        {
            switch (targetPokemonType)
            {
                case Enums.Type.FIGHTING:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.PSYCHIC:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.GHOST:
                    return TypeEffect.SUPER_EFFECTIVE;
                case Enums.Type.DARK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.FAIRY:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static bool PokemonTypeDoesNotMakeContactWithMove(List<Enums.Type> pokemonTypes, IMove move)
        {
            if (pokemonTypes.Contains(Enums.Type.GHOST) && !move.Special)
                return true;

            return false;
        }
    }
}
