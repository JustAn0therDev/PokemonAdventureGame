using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Trainers
{
    public class Bruno : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }
        public IPokemon RewardPokemonForWinning => PokemonFactory.CreatePokemon<Gengar>();
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
                new TrainerPokemon(PokemonFactory.CreatePokemon<Onix>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Machamp>())
            };
        }

        public void InitializeTrainerItems() { }

        public IPokemon GetCurrentPokemon() 
            => PokemonTeam
            .Where(pkmn => pkmn.Current)
            .Select(s => s.Pokemon).FirstOrDefault();

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name &&
                    pkmn.Pokemon.CurrentHealthPoints > 0)
                    pkmn.Current = true;
            });
        }

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam
                .Where(pkmn => !pkmn.Fainted)
                .Select(pkmn => pkmn.Pokemon).FirstOrDefault();

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public bool HasAvailablePokemon() => PokemonTeam
            .Where(w => !w.Fainted).Count() > 0;

        public void SetPokemonAsFainted(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Pokemon == pokemon)
                    pkmn.Fainted = true;
            });
        }

        public void ShowTrainerDialogue()
        {
            Console.WriteLine("Hello, trainer, and welcome to the new Pokemon League.");
            Console.WriteLine("It takes a lot of courage to be here, and you must keep going strong to face the challenges up ahead.");
            ConsoleUtils.WaitFiveSeconds();

            ConsoleUtils.EnemyPhraseBeforeBattle("Do you think you can handle me and my Pokemon?");
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory()
        {
            Console.WriteLine("You are really good! I like your energy and the way you treat your Pokemon");
            Console.WriteLine("And keep that in mind when entering the next room. You will need that energy.");
            ConsoleUtils.WaitFiveSeconds();

            Console.WriteLine("Take care out there, kid");
            ConsoleUtils.WaitFiveSeconds();
            ConsoleUtils.ClearScreen();
        }

        public void ShowFinalDialogueForLoss()
        {
            Console.WriteLine("HAHAHA! You are really good, kid.");
            Console.WriteLine("But I'm WAY STRONGER");
            ConsoleUtils.TrainerAction<EnemyAction>("Come back when you get tougher!!");
            ConsoleUtils.WaitFiveSeconds();
        }
    }
}
