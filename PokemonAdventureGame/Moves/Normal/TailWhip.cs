namespace PokemonAdventureGame.Moves.Normal
{
    public class TailWhip : IMove
    {
        public Enums.Type Type { get => Enums.Type.NORMAL; }
        public int Damage { get => 0; }
        public int PowerPoints { get => 40; set { PowerPoints = value; } }
    }
}
