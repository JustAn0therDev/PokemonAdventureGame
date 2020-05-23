namespace PokemonAdventureGame.Moves.Electric
{
    public class Thunderbolt : IMove
    {
        public Enums.Type Type { get => Enums.Type.ELECTRIC; } 
        public int Damage { get => 15; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }

        public Thunderbolt()
        {
            PowerPoints = 35;
        }
    }
}
