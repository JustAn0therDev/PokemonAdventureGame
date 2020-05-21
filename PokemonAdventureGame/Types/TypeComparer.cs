using PokemonAdventureGame.Interfaces;
using System;
using System.Collections.Generic;

namespace PokemonAdventureGame.Types
{
    public static class TypeComparer
    {

        private static string TYPE_NOT_IMPLEMENTED = "The type request has not been implemented yet!";
        private static string TYPE_COMPARISON_NOT_IMPLEMENTED = "The type comparison requested has not been implemented yet!";

        //public static bool CompareTypes(Enums.Type typeOne, Enums.Type typeTwo)
        //{
        //    switch (typeOne)
        //    {
        //        case Enums.Type.NORMAL:
        //            return CompareNormalType(typeTwo);
        //        case Enums.Type.FIGHTING:
        //            return CompareFightingType(typeTwo);
        //        case Enums.Type.FLYING:
        //            CompareFlyingType(typeTwo);
        //            break;
        //        case Enums.Type.POISON:
        //            ComparePoisonType(typeTwo);
        //            break;
        //        case Enums.Type.GROUND:
        //            CompareGroundType(typeTwo);
        //            break;
        //        case Enums.Type.ROCK:
        //            CompareRockType(typeTwo);
        //            break;
        //        case Enums.Type.BUG:
        //            CompareBugType(typeTwo);
        //            break;
        //        case Enums.Type.GHOST:
        //            CompareGhostType(typeTwo);
        //            break;
        //        case Enums.Type.STEEL:
        //            CompareSteelType(typeTwo);
        //            break;
        //        case Enums.Type.FIRE:
        //            CompareFireType(typeTwo);
        //            break;
        //        case Enums.Type.WATER:
        //            CompareWaterType(typeTwo);
        //            break;
        //        case Enums.Type.GRASS:
        //            CompareGrassType(typeTwo);
        //            break;
        //        case Enums.Type.ELECTRIC:
        //            CompareElectricType(typeTwo);
        //            break;
        //        case Enums.Type.PSYCHIC:
        //            ComparePsychicType(typeTwo);
        //            break;
        //        case Enums.Type.ICE:
        //            CompareIceType(typeTwo);
        //            break;
        //        case Enums.Type.DRAGON:
        //            CompareDragonType(typeTwo);
        //            break;
        //        case Enums.Type.FAIRY:
        //            CompareFairyType(typeTwo);
        //            break;
        //        case Enums.Type.DARK:
        //            CompareDarkType(typeTwo);
        //            break;
        //        default:
        //            throw new NotImplementedException(TYPE_NOT_IMPLEMENTED);
        //    }
        //}


        public static bool PokemonTypeDoesNotMakeContactWithMove(List<Enums.Type> pokemonTypes, IMove move)
        {
            if (pokemonTypes.Contains(Enums.Type.GHOST) && !move.Special)
                return true;

            return false;
        }

        public static bool CompareNormalType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }

        public static bool CompareFightingType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareFlyingType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool ComparePoisonType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareGroundType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareRockType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareBugType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareGhostType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareSteelType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareFireType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareWaterType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareGrassType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareElectricType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool ComparePsychicType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareIceType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareDragonType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareFairyType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
        public static bool CompareDarkType(Enums.Type moveType)
        {
            throw new NotImplementedException(TYPE_COMPARISON_NOT_IMPLEMENTED);
        }
    }
}
