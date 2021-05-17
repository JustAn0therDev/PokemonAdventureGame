using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Trainers
{
    public class Brock : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }
        public IPokemon RewardPokemonForWinning => PokemonFactory.CreatePokemon<Pidgeot>();
        public Dictionary<string, List<IItem>> Items { get; set; }

        public void InitializeTrainer()
        {
            InitializeTrainerTeam();
            InitializeTrainerItems();
        }

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Golem>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Onix>())
            };
        }

        public void InitializeTrainerItems() { }

        public IPokemon GetCurrentPokemon() => PokemonTeam.FirstOrDefault(pkmn => pkmn.Current)?.Pokemon;

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            Parallel.ForEach(PokemonTeam, pkmn =>
            {
                if (pkmn.Current)
                {
                    pkmn.Current = false;
                }

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name)
                {
                    pkmn.Current = true;
                }
            });
        }

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.FirstOrDefault(pkmn => !pkmn.Fainted)?.Pokemon;

            if (firstAvailablePokemon != null)
            {
                SetPokemonAsCurrent(firstAvailablePokemon);
            }

            return firstAvailablePokemon;
        }

        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Any();

        public void SetPokemonAsFainted(IPokemon pokemon)
        {
            var foundPokemon = PokemonTeam.FirstOrDefault(fd => fd.Pokemon == pokemon);

            if (foundPokemon != null)
            {
                foundPokemon.Fainted = true;
            }
        }

        public void ShowTrainerDialogue()
        {
            Console.WriteLine("Hey, welcome to the All-Stars Pokemon League!");
            Console.WriteLine("My name's Brock. I'm the pewter city's gym leader, and your first challenge.");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.EnemyPhraseBeforeBattle("I hope you give me a good challenge and we both have a lot of fun.");
            ConsoleBattleInfoTrainer.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory()
        {
            Console.WriteLine("Wow, man, you are really tough!");
            Console.WriteLine("But by no means I'm the strongest trainer in the League.");
            Console.WriteLine("So to help you in the next battle, I'll heal your pokemon and give you something...");

            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        public void ShowFinalDialogueForLoss()
        {
            Console.WriteLine("Hey man, losing happens. We get stronger when we lose.");
            Console.WriteLine("Anytime you want to come back to battle, we'll be here.");

            ConsoleUtils.TrainerAction<EnemyAction>("Good-bye!");
            ConsoleUtils.WaitFourSeconds();
        }
    }
}
