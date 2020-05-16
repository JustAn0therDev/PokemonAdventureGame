namespace PokemonAdventureGame
{
    public interface IMove
    {
        Enums.Type Type { get; }
        int Damage { get; }
        int PowerPoints { get; }
        //int Ailment { get; set; }
    }
}