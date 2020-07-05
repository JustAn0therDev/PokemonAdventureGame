using PokemonAdventureGame.Interfaces;
using System.Collections.Generic;

namespace PokemonAdventureGame.Factories
{
    public static class ItemFactory
    {
        public static IItem CreateItem<T>() where T : IItem, new()
            => new T();

        public static IEnumerable<IItem> CreateItems<T>(int numOfItemsToCreate) where T : IItem, new()
        {
            for (int i = 0; i < numOfItemsToCreate; i++)
            {
                yield return CreateItem<T>();
            }
        }
    }
}
