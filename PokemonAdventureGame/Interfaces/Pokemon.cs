using PokemonAdventureGame.Enums;
using System.Collections.Generic;

namespace PokemonAdventureGame
{
    //Criar factory que recebe o nome de um pokemon e retorna o objeto com seus stats? Pode receber tambem o index dele da pokedex...
    public interface IPokemon
    {
        int HealthPoints { get; set; }
        int AttackPoints { get; set; }
        int DefensePoints { get; set; }
        int SpecialAttackPoints { get; set; }
        int SpecialDefensePoints { get; set; }
        int SpeedPoints { get; set; }
        /* Sera um enumerador posteriormente e vou ter que verificar o status do Pokemon a cada final de rodada de ataque - Saber se esta Burned, PSN, asleep... */
        StatusCondition Status { get; set; }
        List<IMove> Moves { get; set; }
        /* Um type pode ser imune a outro */
        List<Type> Types { get; set; }
        void InitializePokemonProperties();
        void ReceiveDamage(int damageReceived);
    }
}
