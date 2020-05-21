namespace PokemonAdventureGame.Moves.Normal
{
    public class Leer : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get => 35; set { PowerPoints = value; } }
        public bool Special { get => true; }
    }
}
