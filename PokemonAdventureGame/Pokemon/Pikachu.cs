using PokemonAdventureGame.Moves.Electric;
using PokemonAdventureGame.Moves.Normal;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Pokemon
{
    public class Pikachu : IPokemon
    {
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public int SpecialAttackPoints { get; set; }
        public int SpecialDefensePoints { get; set; }
        public int SpeedPoints { get; set; }
        public string Status { get; set; }
        public HashSet<IMove> Moves { get; set; }
        public HashSet<Enums.Type> Types { get; set; }

        public void InitializePokemonProperties()
        {
            HealthPoints = 35;
            AttackPoints = 55;
            DefensePoints = 30;
            SpecialAttackPoints = 50;
            SpecialDefensePoints = 40;
            SpeedPoints = 90;
            Moves = new HashSet<IMove> { new TailWhip(), new Tackle(), new Thunderbolt() };
            Types = new HashSet<Enums.Type> { Enums.Type.ELECTRIC };
        }

        /* Deal damage? */
        public void ReceiveDamage(int damageReceived) => HealthPoints -= damageReceived;

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.GetType().GetProperties())
            {
                sb.AppendLine($"{item.Name}: {item.GetGetMethod()}");
            }

            return sb.ToString();
        }
    }
}
