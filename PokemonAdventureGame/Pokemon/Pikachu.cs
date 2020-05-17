using System.Text;
using System.Collections.Generic;
using PokemonAdventureGame.Moves.Electric;
using PokemonAdventureGame.Moves.Normal;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;

namespace PokemonAdventureGame.Pokemon
{
    public class Pikachu : IPokemon
    {
        public int HealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public int SpecialAttackPoints { get; set; }
        public int SpecialDefensePoints { get; set; }
        public int SpeedPoints { get; set; }
        public StatusCondition Status { get; set; }
        public List<IMove> Moves { get; set; }
        public List<Type> Types { get; set; }

        public void InitializePokemonProperties()
        {
            HealthPoints = 35;
            CurrentHealthPoints = HealthPoints;

            AttackPoints = 55;
            DefensePoints = 30;
            SpecialAttackPoints = 50;
            SpecialDefensePoints = 40;
            SpeedPoints = 90;
            Status = StatusCondition.OK;
            Moves = new List<IMove> { new TailWhip(), new Tackle(), new Thunderbolt() };
            Types = new List<Type> { Type.ELECTRIC };
        }

        /* Deal damage? */
        public void ReceiveDamage(int damageReceived) => CurrentHealthPoints -= damageReceived;

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
