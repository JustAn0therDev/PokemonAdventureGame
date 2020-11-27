using PokemonAdventureGame.Interfaces;
using System.Linq;

namespace PokemonAdventureGame.Factories
{
    public static class ItemFactory
    {
        public static IItem[] CreateItems<T>(int numOfItemsToCreate) where T : IItem, new() 
            => Enumerable.Range(0, numOfItemsToCreate).Select(_ => CreateItem<T>()).ToArray();

        public static IItem CreateItem<T>() where T : IItem, new() => new T();
    }
}
