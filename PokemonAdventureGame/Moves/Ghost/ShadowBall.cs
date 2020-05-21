namespace PokemonAdventureGame.Moves.Ghost
{
    public class ShadowBall : IMove
    {
        public Enums.Type Type { get => Enums.Type.GHOST; }
        public int Damage { get => 30; }
        public int PowerPoints { get => 30; set { PowerPoints = value; } }
        public bool Special { get => true; }
    }
}
