using System;
using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Trainers.Utils;

namespace PokemonAdventureGame.Trainers
{
    public class Lance : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }
        public IPokemon RewardPokemonForWinning => PokemonFactory.CreatePokemon<Snorlax>();
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
                new TrainerPokemon(PokemonFactory.CreatePokemon<Dragonite>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Dragonite>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Dragonite>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Aerodactyl>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Charizard>())
            };
        }

        public void InitializeTrainerItems() { }

        public IPokemon GetCurrentPokemon() => PokemonTeam.FirstOrDefault(pkmn => pkmn.Current)?.Pokemon;

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            // Prevent setting a Pokemon as current if it has fainted.
            TrainerUtils.UpdateCurrentBattlePokemon(PokemonTeam, pokemon);
        }

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.FirstOrDefault(pkmn => !pkmn.Fainted)?.Pokemon;

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

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
            Console.WriteLine("Congratulations on getting all the way here, trainer.");
            Console.WriteLine("You look strong and like someone who has faced a lot of tough battles.");
            Console.WriteLine("And with that said...");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.EnemyPhraseBeforeBattle("May you who have come to challenge me, fulfill my desire for a good battle!");
            ConsoleBattleInfoTrainer.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory()
        {
            Console.WriteLine("Congratulations! You beat me and you deserve every single moment of good feelings about yourself!");
            Console.WriteLine("Now, the league does not end here... You need to face a final challenge. Have this: ");
            ConsoleUtils.WaitFourSeconds();

            Console.WriteLine("Watch out and think carefully about every. Single. Movement.");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        public void ShowFinalDialogueForLoss()
        {
            Console.WriteLine("Hey, c'mon, I know you can do better than this!");
            ConsoleUtils.TrainerAction<EnemyAction>("Come back when you get stronger.");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.EndGame();
        }
    }
}
