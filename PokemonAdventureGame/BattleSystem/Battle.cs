using System;
using System.Linq;
using PokemonAdventureGame.BattleSystem.ConsoleUI;
using PokemonAdventureGame.Enums;
using PokemonAdventureGame.Interfaces;
using PokemonAdventureGame.Types;

namespace PokemonAdventureGame.BattleSystem
{
    public class Battle
    {
        private const int LIMIT_OF_MOVES_PER_POKEMON = 4;
        private ITrainer _player { get; set; }
        private ITrainer _enemyTrainer { get; set; }
        private BattleAux _battleAux { get; set; }

        public Battle(ITrainer player, ITrainer enemyTrainer)
        {
            _player = player;
            _enemyTrainer = enemyTrainer;
            _battleAux = new BattleAux(player, enemyTrainer);
        }

        public void StartBattle()
        {
            _player.SetPokemonAsCurrent(_player.GetNextAvailablePokemon());
            _enemyTrainer.SetPokemonAsCurrent(_enemyTrainer.GetNextAvailablePokemon());

            ConsoleBattleInfo.EnemyTrainerSendsPokemon(_enemyTrainer, _enemyTrainer.GetCurrentPokemon());
            ConsoleBattleInfo.PlayerSendsPokemon(_player.GetCurrentPokemon());

            MainBattle();
        }

        private void MainBattle() => KeepBattleGoingWhileBothPlayersHavePokemonLeft();

        private void KeepBattleGoingWhileBothPlayersHavePokemonLeft()
        {
            while (_player.HasAvailablePokemon() && _enemyTrainer.HasAvailablePokemon())
            {
                bool keepBattleGoing = false, isChangingToNextAvailablePokemon = false;

                if (_player.GetCurrentPokemon().CurrentHealthPoints == 0 && _enemyTrainer.HasAvailablePokemon())
                {
                    if (_battleAux.CannotSendNextAvailablePokemon(_player))
                        return;
                    else
                        isChangingToNextAvailablePokemon = true;
                }
                else
                {
                    ConsoleBattleInfo.ShowBothPokemonStats(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon());
                    keepBattleGoing = PlayerMove();
                }

                if (keepBattleGoing && !isChangingToNextAvailablePokemon)
                {
                    if (_enemyTrainer.GetCurrentPokemon().CurrentHealthPoints == 0 && _player.HasAvailablePokemon())
                    {
                        if (_battleAux.CannotSendNextAvailablePokemon(_enemyTrainer, true))
                            return;
                    }
                    else
                        EnemyMove();
                }
            }
        }

        private bool PlayerMove()
        {
            bool keepBattleGoing = false;

            Console.WriteLine("What are you going to do next?");
            ConsoleBattleInfo.ShowAvailableCommandsOnConsole();

            Command command = (Command)Enum.Parse(typeof(Command), Console.ReadLine() ?? "1");

            switch (command)
            {
                case Command.ATTACK:
                    PromptTrainerForPokemonMove();
                    keepBattleGoing = true;
                    break;
                case Command.SWITCH_POKEMON:
                    keepBattleGoing = PromptPlayerToSelectPokemon();
                    break;
                case Command.ITEMS:
                case Command.RUN:
                default:
                    Environment.Exit(0);
                    break;
            }

            return keepBattleGoing;
        }

        private void PromptTrainerForPokemonMove()
        {
            int chosenMove = _battleAux.KeepPlayerChoosingMove(LIMIT_OF_MOVES_PER_POKEMON);
            PokemonAttack(_player.GetCurrentPokemon(), _enemyTrainer.GetCurrentPokemon(), chosenMove);
        }

        private void PokemonAttack(IPokemon attackingPokemon, IPokemon targetPokemon, int chosenMove)
        {
            IMove move = attackingPokemon.Moves[chosenMove];

            if (move.PowerPoints == 0)
            {
                ConsoleBattleInfo.MovementIsOutOfPowerPoints();
                PromptTrainerForPokemonMove();
                return;
            }

            ConsoleBattleInfo.ShowPokemonUsedMove(attackingPokemon, move.GetType().Name);

            if (TypeComparer.PokemonTypeDoesNotMakeContactWithMove(targetPokemon.Types, move))
                ConsoleBattleInfo.MovementDidntAffectPokemon(targetPokemon);
            else
                ProcessAttack(attackingPokemon, targetPokemon, move);

            ConsoleBattleInfo.Clear();
        }

        private void ProcessAttack(IPokemon attackingPokemon, IPokemon targetPokemon, IMove move)
        {
            TypeEffect moveEffectOnPokemon = TypeComparer.GetMoveEffectivenessBasedOnPokemonType(move.Type, targetPokemon.Types.FirstOrDefault());
            int calculatedDamage = TypeDamageCalculator.CalculateDamage(attackingPokemon, targetPokemon, move, moveEffectOnPokemon);

            attackingPokemon.UseMove(move);

            if (move.StatusMoves != null)
                _battleAux.ProcessStatusAttack(attackingPokemon, targetPokemon, move);
            else
            {
                targetPokemon.ReceiveDamage(calculatedDamage);
                ConsoleBattleInfo.ShowPokemonReceivedDamage(targetPokemon, calculatedDamage);
                ConsoleBattleInfo.ShowHowEffectiveTheMoveWas(moveEffectOnPokemon, targetPokemon);
            }
        }

        private bool PromptPlayerToSelectPokemon()
        {
            int chosenPokemon = -1;

            if (_player.PokemonTeam.Where(pkmn => !pkmn.Fainted).Count() == 1)
            {
                ConsoleBattleInfo.ShowPlayerThereAreNoPokemonLeft();
                return false;
            }

            while (chosenPokemon == -1 || chosenPokemon > _player.PokemonTeam.Count)
            {
                ConsoleBattleInfo.ShowAllTrainersPokemon(_player);
                chosenPokemon = ConsoleBattleInfo.GetPlayerChosenInput(Console.ReadLine());
            }
            SwitchCurrentPokemon(chosenPokemon);

            return true;
        }

        private void SwitchCurrentPokemon(int chosenPokemon)
        {
            if (_player.PokemonTeam[chosenPokemon].Fainted)
            {
                ConsoleBattleInfo.PokemonUnavailable();
                PlayerMove();
                return;
            }
            else if (_player.PokemonTeam[chosenPokemon].Current)
            {
                ConsoleBattleInfo.ShowChosenPokemonIsAlreadyInBattle();
                PlayerMove();
                return;
            }
        }

        private void EnemyMove()
        {
            IPokemon enemyPokemon = _enemyTrainer.GetCurrentPokemon();
            PokemonAttack(enemyPokemon, _player.GetCurrentPokemon(), new Random().Next(0, enemyPokemon.Moves.Count));
        }
    }
}