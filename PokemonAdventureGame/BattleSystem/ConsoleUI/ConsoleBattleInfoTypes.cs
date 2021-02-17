using System.Collections.Generic;
using PokemonAdventureGame.Enums;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfoTypes
    {
        private static IReadOnlyDictionary<TypeEffect, string> DictionaryOfMessageToTypeEffect
        {
            get
            {
                return new Dictionary<TypeEffect, string>
                {
                    { TypeEffect.IMMUNE, "It didn't affect the pokemon!" },
                    { TypeEffect.NOT_VERY_EFFECTIVE , "It's not very effective..."},
                    { TypeEffect.SUPER_EFFECTIVE, "It's super effective!" },
                    { TypeEffect.NEUTRAL, string.Empty }
                };
            }
        }

        public static void ShowHowEffectiveTheMoveWas(TypeEffect typeEffect)
         => ConsoleUtils.ShowMessageAndWaitOneSecond(DictionaryOfMessageToTypeEffect[typeEffect]);
    }
}
