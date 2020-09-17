using PokemonAdventureGame.Interfaces;
using System;
using System.Collections.Generic;

namespace PokemonAdventureGame.Factories
{
    public static class ItemFactory
    {
        public static IItem[] CreateItems<T>(int numOfItemsToCreate) where T : IItem, new()
        {
            var arrayOfItems = new IItem[numOfItemsToCreate];

            for (int i = 0; i < numOfItemsToCreate; i++)
                arrayOfItems[i] = CreateItem<T>();

            return arrayOfItems;
        }

        public static IItem CreateItem<T>() where T : IItem, new()
            => new T();
    }
}
