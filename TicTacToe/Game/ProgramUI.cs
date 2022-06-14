using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Repository;

    class ProgramUI
    {

        static int counter = 1;

        static int placeholder;

        static int checker = 0;

        static int point1 = 0;

        static int point2 = 0;

        public readonly GameRepository _repo = new GameRepository();

        public void Run() {
            RunMenu();
        }

        public void RunMenu() {

            bool continueToRun = true;

            do {
                Console.Clear();
                System.Console.WriteLine("1. Start new TicTacToe Game\n" +
                "2. Read Instructions\n" +
                "3. Exit from the game.");

                string select = Console.ReadLine();

                switch (select) {
                    case "1":
                        CreateNewGame();
                        break;
                    case "2":
                        Instructions();
                        break;
                    case "3":
                        Console.Clear();
                        System.Console.WriteLine($"Player 1 points: {point1}          Player 2 points: {point2} \n" +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        if (point1 > point2) {
                            System.Console.WriteLine("Player 1 has won the tournament! Better Luck Next Time, Player 2.");
                        }
                        else if (point2 > point1) {
                            System.Console.WriteLine("Player 2 has won the tournament! Better Luck Next Time, Player 1.");
                        }
                        else if (point1 == point2) {
                            System.Console.WriteLine("The tournament has ended in a tie!");
                        }
                        point1 = 0;
                        point2 = 0;
                        System.Console.WriteLine("Bye bye!");
                        continueToRun = false;
                        break;
                } 
            } while (continueToRun);
        }

        public void CreateNewGame() {

            Console.Clear();

            System.Console.WriteLine("New Tic-Tac-Game\n" +
            "--------------------------------------------");

            _repo.Board();

            do {

                _repo.Board();

                if (counter % 2 != 0) {
                    System.Console.WriteLine("Player 1: Choose where to place your 'X'...");
                } 
                else if (counter % 2 ==0) {
                    System.Console.WriteLine("Player 2: Choose where to place your 'O'...");
                }

                placeholder = int.Parse(Console.ReadLine());

                if (_repo.tic[placeholder] != 'X' && _repo.tic[placeholder] != 'O') {
                    if (counter % 2 != 0) {
                        _repo.tic[placeholder] = 'X';
                        counter++;
                    } 
                    else if (counter % 2 == 0) {
                        _repo.tic[placeholder] = 'O';
                        counter++;
                    }
                }
                else {
                    System.Console.WriteLine("This place is already taken, please try another place");
                }

                checker = _repo.CheckForWin();
            } while (checker != 1 && checker != -1);

            Console.Clear();

            _repo.Board();

              if ((counter % 2) + 1 == 1) {
                point1++;
            }
            else if ((counter % 2) + 1 == 2) {
                point2++;
            }

            if (checker == 1) {
                System.Console.WriteLine($"Congratulations! Player {(counter % 2)+1} has won!\n");
                System.Console.WriteLine($"Player 1 has {point1} points and Player 2 has {point2} points.");
                Init();
                WaitForKey();
            }
            else if (checker == -1) {
                System.Console.WriteLine("Cat's Game! The game has ended in a draw.");
                System.Console.WriteLine($"Player 1 has {point1} points and Player 2 has {point2} points.");
                Init();
                WaitForKey();
            }

          
        }

        public void Instructions() {

            System.Console.WriteLine("How to play this game:\n" +
            "--------------------------------------");
            System.Console.WriteLine("1.) Player 1 is 'X' and  Player 2 is 'O'.\n" +
            "2.) Player 1 begins by pressing the number of where they want their 'X' to be placed.\n" +
            "3.) Player 2 then presses the number of where they want their 'O' to be placed.\n" +
            "4.) Either player can block the other player from getting three in a row.\n");

            System.Console.WriteLine("The aim of the game is to get three in a row (horizontally, vertically, or diagonally) of 'X's or 'O's, depending on the player.");

            WaitForKey();
        }

        private void WaitForKey() {
            System.Console.WriteLine("Please press any key to return to the main menu...");

            Console.ReadKey();
        }

        private void Init() {
            _repo.tic[0] = '0';
            _repo.tic[1] = '1';
            _repo.tic[2] = '2';
            _repo.tic[3] = '3';
            _repo.tic[4] = '4';
            _repo.tic[5] = '5';
            _repo.tic[6] = '6';
            _repo.tic[7] = '7';
            _repo.tic[8] = '8';
            _repo.tic[9] = '9';

        }
    }
