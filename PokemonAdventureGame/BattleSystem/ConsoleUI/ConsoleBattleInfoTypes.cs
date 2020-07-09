using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame.BattleSystem.ConsoleUI
{
    public static class ConsoleBattleInfoTypes
    {
        private delegate void ShowMessageAndWaitOneSecondDelegate(string messageToShow);

        private static IReadOnlyDictionary<TypeEffect, string> _dictionaryOfMessageForTypeEffect
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
         => ConsoleUtils.ShowMessageAndWaitOneSecond(_dictionaryOfMessageForTypeEffect[typeEffect]);
    }
}
