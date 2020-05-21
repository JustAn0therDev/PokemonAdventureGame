namespace PokemonAdventureGame
{
    public interface IMove
    {
        Enums.Type Type { get; }
        int Damage { get; }
        int PowerPoints { get; set; }
        bool Special { get; }
        //int Ailment { get; set; }
    }
}