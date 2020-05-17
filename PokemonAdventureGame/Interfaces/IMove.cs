namespace PokemonAdventureGame
{
    public interface IMove
    {
        Enums.Type Type { get; }
        int Damage { get; }
        int PowerPoints { get; set; }
        //int Ailment { get; set; }
    }
}