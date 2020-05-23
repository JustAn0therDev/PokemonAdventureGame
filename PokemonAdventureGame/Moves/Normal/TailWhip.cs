namespace PokemonAdventureGame.Moves.Normal
{
    public class TailWhip : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get; set; }
        public bool Special { get => true; }

        public TailWhip()
        {
            PowerPoints = 40;
        }
    }
}
