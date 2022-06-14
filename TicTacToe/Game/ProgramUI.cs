using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Repository;

    class ProgramUI
    {
        public string name1 = "Player 1";

        public string name2 = "Player 2";

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
                System.Console.WriteLine($"Tic-Tac-Toe              {name1} Wins: {point1} {name2} Wins: {point2}\n" + "===========================================================\n");
                _repo.EmptyBoard();
                System.Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++\n");
                System.Console.WriteLine("Please choose an option from the following menu:\n");
                System.Console.WriteLine("1. Choose player names\n" + 
                "2. Start new Tic-Tac-Toe Game\n" +
                "3. Read Instructions\n" +
                "4. Exit\n");

                string select = Console.ReadLine();

                switch (select) {
                    case "1":
                        Names();
                        break;
                    case "2":
                        CreateNewGame();
                        break;
                    case "3":
                        Instructions();
                        break;
                    case "4":
                        Console.Clear();
                        System.Console.WriteLine($"{name1} points: {point1}          {name2} points: {point2} \n" +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        if (point1 > point2) {
                            System.Console.WriteLine($"{name1} has won the tournament! Better Luck Next Time, {name2}.");
                        }
                        else if (point2 > point1) {
                            System.Console.WriteLine($"{name2} has won the tournament! Better Luck Next Time, {name1}.");
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

        public void Names() {

            Console.Clear();

            System.Console.WriteLine("Player 1, please enter your name:\n");

            name1 = Console.ReadLine();

            System.Console.WriteLine("Player 2. please enter your name:\n");

            name2 = Console.ReadLine();

            WaitForKey();
        }

        public void CreateNewGame() {

            Console.Clear();

            System.Console.WriteLine("New Tic-Tac-Game\n" +
            "--------------------------------------------");

            do {

                _repo.Board();

                if (counter % 2 != 0) {
                    System.Console.WriteLine($"{name1}: Choose where to place your 'X'...");
                } 
                else if (counter % 2 ==0) {
                    System.Console.WriteLine($"{name2}: Choose where to place your 'O'...");
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

            if (checker == 1 && (counter % 2) + 1 == 1) {
                point1++;
                System.Console.WriteLine($"Congratulations! {name1} has won!\n");
                System.Console.WriteLine($"{name1} has {point1} points and {name2} has {point2} points.\n");
                Init();
                WaitForKey();
            }
            else if (checker == 1 && (counter % 2) + 1 == 2) {
                point2++;
                System.Console.WriteLine($"Congratulations! {name2} has won!\n");
                System.Console.WriteLine($"{name1} has {point1} points and {name2} has {point2} points.\n");
                Init();
                WaitForKey();
            }
            else if (checker == -1) {
                System.Console.WriteLine("Cat's Game! The game has ended in a draw.\n");
                System.Console.WriteLine($"{name1} has {point1} points and {name2} has {point2} points.\n");
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
            System.Console.WriteLine("Please press any key to return to the main menu...\n");

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
