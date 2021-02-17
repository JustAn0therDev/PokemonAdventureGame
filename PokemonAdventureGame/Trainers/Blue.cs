using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Trainers
{
    public class Blue : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }
        public IPokemon RewardPokemonForWinning => PokemonFactory.CreatePokemon<Dragonite>();
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
                new TrainerPokemon(PokemonFactory.CreatePokemon<Gyarados>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Arcanine>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Exeggutor>())
            };
        }

        public void InitializeTrainerItems() { }

        public IPokemon GetCurrentPokemon() => PokemonTeam.FirstOrDefault(pkmn => pkmn.Current)?.Pokemon;

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.FirstOrDefault(pkmn => !pkmn.Fainted)?.Pokemon;

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name)
                    pkmn.Current = true;
            });
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
            Console.WriteLine("Hey, I'm Blue, former Pokemon League Champion. Since you got here, I hope you give me a good battle");
            Console.WriteLine("because the last trainers that got here were really disapointing...");
            Console.WriteLine("And you're ugly.");
            ConsoleUtils.WaitFiveSeconds();

            ConsoleUtils.TrainerAction<EnemyAction>("I hope you're ready to have your butt handed over to you.");
            ConsoleUtils.WaitTwoSeconds();
            ConsoleUtils.ClearScreen();
            ConsoleBattleInfoTrainer.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory()
        {
            Console.WriteLine("Ok, I'll admit it, you're the real deal.");
            Console.WriteLine("Have this Dragonite. Lance is really good, no wonder he is the Champion.");
            ConsoleUtils.WaitFiveSeconds();

            Console.WriteLine("Good luck, you'll need it.");
            ConsoleUtils.WaitFiveSeconds();
            ConsoleUtils.ClearScreen();
        }

        public void ShowFinalDialogueForLoss()
        {
            ConsoleUtils.TrainerAction<EnemyAction>("Good-bye, joke.");
            ConsoleUtils.WaitFiveSeconds();
            ConsoleUtils.EndGame();
        }
    }
}
