﻿using System.Linq;
using System.Collections.Generic;
using PokemonAdventureGame.Factories;
using PokemonAdventureGame.Pokemon;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.PokemonTeam;
using System;
using PokemonAdventureGame.BattleSystem.ConsoleUI;

namespace PokemonAdventureGame.Trainers
{
    public class MaryAnn : ITrainer
    {
        public List<TrainerPokemon> PokemonTeam { get; set; }

        public IPokemon RewardPokemonForWinning => PokemonFactory.CreatePokemon<Lapras>();

        public void InitializeTrainerTeam()
        {
            PokemonTeam = new List<TrainerPokemon>
            {
                new TrainerPokemon(PokemonFactory.CreatePokemon<Machamp>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Hypno>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Alakazam>()),
                new TrainerPokemon(PokemonFactory.CreatePokemon<Gengar>()),
            };
        }

        public IPokemon GetCurrentPokemon() => PokemonTeam.Where(pkmn => pkmn.Current).Select(s => s.Pokemon).FirstOrDefault();

        public void SetPokemonAsCurrent(IPokemon pokemon)
        {
            PokemonTeam.ForEach(pkmn =>
            {
                if (pkmn.Current)
                    pkmn.Current = false;

                if (pkmn.Pokemon.GetType().Name == pokemon.GetType().Name && pkmn.Pokemon.CurrentHealthPoints > 0)
                    pkmn.Current = true;
            });
        }

        public IPokemon GetNextAvailablePokemon()
        {
            IPokemon firstAvailablePokemon = PokemonTeam.Where(pkmn => !pkmn.Fainted).Select(pkmn => pkmn.Pokemon).FirstOrDefault();

            if (firstAvailablePokemon != null)
                SetPokemonAsCurrent(firstAvailablePokemon);

            return firstAvailablePokemon;
        }

        public bool HasAvailablePokemon() => PokemonTeam.Where(w => !w.Fainted).Count() > 0;

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
            Console.WriteLine("Hi, welcome to the new Pokemon League. Congratualtions on beating Brock and Bruno.");
            Console.WriteLine("But I can guarantee that I won't be that much of a pushover like those two.");
            ConsoleUtils.WaitFourSeconds();

            ConsoleUtils.EnemyPhraseBeforeBattle("Are you ready to take a beating?");
            ConsoleUtils.EnemyPhraseBeforeBattle("By the way, have you seen my cat?");
            ConsoleBattleInfo.EnemyTrainerWantsToBattle(this);
        }

        public void ShowFinalDialogueForVictory()
        {
            Console.WriteLine("Hey, that was a great battle, congratulations on winning! Now, the next trainer is really tough.");
            Console.WriteLine("Watch out and have this, you'll need it.");
            ConsoleUtils.WaitFourSeconds();

            Console.WriteLine("And if you see my cat, please tell her to come back, I'm a bit worried...");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.ClearScreen();
        }

        public void ShowFinalDialogueForLoss()
        {
            Console.WriteLine("I told you...");
            Console.WriteLine("Come back when you get better.");
            ConsoleUtils.TrainerAction<EnemyAction>("Or if you see my cat, I'm worried about her...");
            ConsoleUtils.WaitFourSeconds();
            ConsoleUtils.EndProgram();
        }
    }
}
