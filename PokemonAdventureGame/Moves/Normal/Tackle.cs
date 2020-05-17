namespace PokemonAdventureGame.Moves.Normal
{
    public class Tackle : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 10; }
        public int PowerPoints { get => 30; set { PowerPoints = value; } }
    }
}
