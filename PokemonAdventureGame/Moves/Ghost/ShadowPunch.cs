namespace PokemonAdventureGame.Moves.Ghost
{
    public class ShadowPunch : IMove
    {
        public Enums.Type Type { get => Enums.Type.GHOST; }
        public int Damage { get => 25; }
        public int PowerPoints { get; set; }
        public bool Special { get => false; }

        public ShadowPunch()
        {
            PowerPoints = 30;
        }
    }
}
