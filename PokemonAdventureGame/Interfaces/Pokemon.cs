using System.Collections.Generic;
using System.Linq;

namespace PokemonAdventureGame
{
    //Criar factory que recebe o nome de um pokemon e retorna o objeto com seus stats? Pode receber tambem o index dele da pokedex...
    public class Pokemon
    {
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public int SpecialAttackPoints { get; set; }
        public int SpecialDefensePoints { get; set; }
        public int SpeedPoints { get; set; }

        /* Sera um enumerador posteriormente e vou ter que verificar o status do Pokemon a cada final de rodada de ataque - Saber se esta Burned, PSN, asleep... */
        public string Status { get; set; }

        public HashSet<IMove> Moves { get; set; }

        /* Sera um enumerador posteriormente, comparar o tipo do ataque com o tipo do pokemon. A propriedade "Type" nao sera exclusiva de Pokemon (moves tambem terao um type) */
        /* Um type pode ser imune a outro */
        public HashSet<Enums.Type> Types { get; set; }

        public Pokemon(int healthPoints, int attackPoints, int defensePoints, int specialAttackPoints, int specialDefensePoints, int speedPoints, HashSet<IMove> moves, HashSet<Enums.Type> type)
        {
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            SpecialAttackPoints = specialAttackPoints;
            SpecialDefensePoints = specialDefensePoints;
            SpeedPoints = speedPoints;
            Moves = moves;
            Types = type;
        }

        public override string ToString()
        {
            //WIP - ToString method should envolve more things than just return a description of the pokemon object.
            return $"Health Points: {HealthPoints}, Type: {Types.First().ToString()}";
        }
    }
}
