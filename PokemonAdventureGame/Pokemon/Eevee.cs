using PokemonAdventureGame.Moves.Electric;
using PokemonAdventureGame.Moves.Normal;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventureGame.Pokemon
{
    public class Eevee : IPokemon
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
            HealthPoints = 55;
            AttackPoints = 55;
            DefensePoints = 50;
            SpecialAttackPoints = 45;
            SpecialDefensePoints = 65;
            SpeedPoints = 55;
            Moves = new HashSet<IMove> { new Leer(), new Tackle() };
            Types = new HashSet<Enums.Type> { Enums.Type.NORMAL };
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
