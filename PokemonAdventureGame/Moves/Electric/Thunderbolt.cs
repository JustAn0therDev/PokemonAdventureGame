namespace PokemonAdventureGame.Moves.Electric
{
    public class Thunderbolt : IMove
    {
        public Enums.Type Type { get => Enums.Type.ELECTRIC; } 
        public int Damage { get => 15; }
        public int PowerPoints { get => 35; set { PowerPoints = value; } }
        public bool Special { get => true; }
    }
}
