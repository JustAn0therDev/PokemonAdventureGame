namespace PokemonAdventureGame.Moves.Normal
{
    public class Tackle : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 10; }
        public int PowerPoints { get; set; }
        public bool Special { get => false; }

        public Tackle()
        {
            PowerPoints = 30;
        }
    }
}
