using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame.Types
{
    public static class TypeComparer
    {
        public static TypeEffect GetMoveEffectivenessBasedOnPokemonType(Enums.Type attackingType, Enums.Type targetType) 
        {
           switch (attackingType)
           {
               case Enums.Type.NORMAL:
                   return CompareNormalType(targetType);
               case Enums.Type.FIGHTING:
                   return CompareFightingType(targetType);
               case Enums.Type.FLYING:
                   return CompareFlyingType(targetType);
               case Enums.Type.POISON:
                   return ComparePoisonType(targetType);
               case Enums.Type.GROUND:
                   return CompareGroundType(targetType);
               case Enums.Type.ROCK:
                   return CompareRockType(targetType);
               case Enums.Type.BUG:
                   return CompareBugType(targetType);
               case Enums.Type.GHOST:
                   return CompareGhostType(targetType);
               case Enums.Type.STEEL:
                   return CompareSteelType(targetType);
               case Enums.Type.FIRE:
                   return CompareFireType(targetType);
               case Enums.Type.WATER:
                   return CompareWaterType(targetType);
               case Enums.Type.GRASS:
                   return CompareGrassType(targetType);
               case Enums.Type.ELECTRIC:
                   return CompareElectricType(targetType);
               case Enums.Type.PSYCHIC:
                   return ComparePsychicType(targetType);
               case Enums.Type.ICE:
                   return CompareIceType(targetType);
               case Enums.Type.DRAGON:
                   return CompareDragonType(targetType);
               case Enums.Type.FAIRY:
                   return CompareFairyType(targetType);
               case Enums.Type.DARK:
                   return CompareDarkType(targetType);
               default:
                   return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareNormalType(Enums.Type targetType)
        {
            switch (targetType)
            {
                case Enums.Type.ROCK:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                case Enums.Type.STEEL:
                    return TypeEffect.NOT_VERY_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFightingType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareFlyingType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect ComparePoisonType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareGroundType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareRockType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareBugType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareGhostType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareSteelType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareFireType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareWaterType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareGrassType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareElectricType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect ComparePsychicType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareIceType(Enums.Type targetType)
        {
            switch (targetType)
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

        public static TypeEffect CompareDragonType(Enums.Type targetType)
        {
            switch (targetType)
            {
                case Enums.Type.DRAGON:
                    return TypeEffect.SUPER_EFFECTIVE;
                default:
                    return TypeEffect.NEUTRAL;
            }
        }

        public static TypeEffect CompareFairyType(Enums.Type targetType)
        {
            switch (targetType)
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