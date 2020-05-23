using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame.Types
{
    public static class TypeComparer
    {
        public static TypeEffect GetMoveEffectivenessBasedOnPokemonType(Type attackingType, Type targetType) 
        {
            return attackingType switch
            {
                Type.NORMAL => CompareNormalType(targetType),
                Type.FIGHTING => CompareFightingType(targetType),
                Type.FLYING => CompareFlyingType(targetType),
                Type.POISON => ComparePoisonType(targetType),
                Type.GROUND => CompareGroundType(targetType),
                Type.ROCK => CompareRockType(targetType),
                Type.BUG => CompareBugType(targetType),
                Type.GHOST => CompareGhostType(targetType),
                Type.STEEL => CompareSteelType(targetType),
                Type.FIRE => CompareFireType(targetType),
                Type.WATER => CompareWaterType(targetType),
                Type.GRASS => CompareGrassType(targetType),
                Type.ELECTRIC => CompareElectricType(targetType),
                Type.PSYCHIC => ComparePsychicType(targetType),
                Type.ICE => CompareIceType(targetType),
                Type.DRAGON => CompareDragonType(targetType),
                Type.FAIRY => CompareFairyType(targetType),
                Type.DARK => CompareDarkType(targetType),
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareNormalType(Type targetType)
        {
            return targetType switch
            {
                Type.ROCK => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareFightingType(Type targetType)
        {
            return targetType switch
            {
                Type.ICE => TypeEffect.SUPER_EFFECTIVE,
                Type.NORMAL => TypeEffect.SUPER_EFFECTIVE,
                Type.FIGHTING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.POISON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FLYING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.PSYCHIC => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.BUG => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ROCK => TypeEffect.SUPER_EFFECTIVE,
                Type.DARK => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.SUPER_EFFECTIVE,
                Type.FAIRY => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareFlyingType(Type targetType)
        {
            return targetType switch
            {
                Type.ELECTRIC => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.FIGHTING => TypeEffect.SUPER_EFFECTIVE,
                Type.BUG => TypeEffect.SUPER_EFFECTIVE,
                Type.ROCK => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect ComparePoisonType(Type targetType)
        {
            return targetType switch
            {
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.POISON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GROUND => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ROCK => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GHOST => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.STEEL => TypeEffect.IMMUNE,
                Type.FAIRY => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareGroundType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.SUPER_EFFECTIVE,
                Type.ELECTRIC => TypeEffect.SUPER_EFFECTIVE,
                Type.GRASS => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.POISON => TypeEffect.SUPER_EFFECTIVE,
                Type.FLYING => TypeEffect.IMMUNE,
                Type.BUG => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ROCK => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareRockType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.SUPER_EFFECTIVE,
                Type.ICE => TypeEffect.SUPER_EFFECTIVE,
                Type.FIGHTING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FLYING => TypeEffect.SUPER_EFFECTIVE,
                Type.GROUND => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.BUG => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareBugType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.POISON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FLYING => TypeEffect.SUPER_EFFECTIVE,
                Type.PSYCHIC => TypeEffect.SUPER_EFFECTIVE,
                Type.GHOST => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.DARK => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FAIRY => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareGhostType(Type targetType)
        {
            return targetType switch
            {
                Type.PSYCHIC => TypeEffect.SUPER_EFFECTIVE,
                Type.NORMAL => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FIGHTING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GHOST => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareSteelType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.WATER => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ELECTRIC => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.BUG => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FAIRY => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareFireType(Type targetType)
        {
            return targetType switch
            {
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.WATER => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FIGHTING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ICE => TypeEffect.SUPER_EFFECTIVE,
                Type.BUG => TypeEffect.SUPER_EFFECTIVE,
                Type.ROCK => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.DRAGON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.STEEL => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareWaterType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.SUPER_EFFECTIVE,
                Type.WATER => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GROUND => TypeEffect.SUPER_EFFECTIVE,
                Type.ROCK => TypeEffect.SUPER_EFFECTIVE,
                Type.DRAGON => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareGrassType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.WATER => TypeEffect.SUPER_EFFECTIVE,
                Type.GRASS => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.POISON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GROUND => TypeEffect.SUPER_EFFECTIVE,
                Type.FLYING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.BUG => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.ROCK => TypeEffect.SUPER_EFFECTIVE,
                Type.DRAGON => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareElectricType(Type targetType)
        {
            return targetType switch
            {
                Type.WATER => TypeEffect.SUPER_EFFECTIVE,
                Type.ELECTRIC => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GHOST => TypeEffect.SUPER_EFFECTIVE,
                Type.GROUND => TypeEffect.IMMUNE,
                Type.FLYING => TypeEffect.SUPER_EFFECTIVE,
                Type.DRAGON => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect ComparePsychicType(Type targetType)
        {
            return targetType switch
            {
                Type.POISON => TypeEffect.SUPER_EFFECTIVE,
                Type.FIGHTING => TypeEffect.SUPER_EFFECTIVE,
                Type.PSYCHIC => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareIceType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.WATER => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GRASS => TypeEffect.SUPER_EFFECTIVE,
                Type.ICE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.GROUND => TypeEffect.SUPER_EFFECTIVE,
                Type.FLYING => TypeEffect.SUPER_EFFECTIVE,
                Type.DRAGON => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareDragonType(Type targetType)
        {
            return targetType switch
            {
                Type.DRAGON => TypeEffect.SUPER_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareFairyType(Type targetType)
        {
            return targetType switch
            {
                Type.FIRE => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FIGHTING => TypeEffect.SUPER_EFFECTIVE,
                Type.POISON => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.DRAGON => TypeEffect.SUPER_EFFECTIVE,
                Type.DARK => TypeEffect.SUPER_EFFECTIVE,
                Type.STEEL => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static TypeEffect CompareDarkType(Type targetPokemonType)
        {
            return targetPokemonType switch
            {
                Type.FIGHTING => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.PSYCHIC => TypeEffect.SUPER_EFFECTIVE,
                Type.GHOST => TypeEffect.SUPER_EFFECTIVE,
                Type.DARK => TypeEffect.NOT_VERY_EFFECTIVE,
                Type.FAIRY => TypeEffect.NOT_VERY_EFFECTIVE,
                _ => TypeEffect.NEUTRAL,
            };
        }

        public static bool PokemonTypeDoesNotMakeContactWithMove(List<Type> pokemonTypes, IMove move)
        {
            if (pokemonTypes.Contains(Type.GHOST) && !move.Special)
                return true;

            return false;
        }
    }
}