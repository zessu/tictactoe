using System;

namespace udemycsharpcourse
{
    public class Entry
    {
        static void Main()
        {
            string[] players = { "player one", "plasyer two" };
            TicTacToeGame Game = new TicTacToeGame(players);
            Game.DrawBoard();
        }
    }


    public class TicTacToeGame
    {
        private string[] _players;
        private string[,] Board = new string[3, 3];
        private string winner;
        private string currentPlayer = "player one";
        private int playerChoice;
        enum playerCharacters
        {
            X = 1,
            O = 2
        };
        public TicTacToeGame(string[] players)
        {
            _players = players;

        }
        public void DrawBoard()
        {
            Console.WriteLine(
                "     |     |     |" + "\n" +
                "  1  |  2  |  3  |" + "\n" +
                "_____|_____|_____" + "\n" +
                "     |     |     " + "\n" +
                "  4  |  5  |  6  " + "\n" +
                "_____|_____|_____" + "\n" +
                "     |     |     " + "\n" +
                "  7  |  8  |  9  |" + "\n" +
                "     |     |     ");
            IntroGame();
        }

        public void IntroGame()
        {
            Console.WriteLine("Welcome to a game of classic Tic Tac Toe");
            Console.WriteLine("Play as player one X or as player two 0");
            StartRound();
        }

        public void StartRound()
        {
            Console.WriteLine("current player, {0}", currentPlayer);
            string playerInput = Console.ReadLine();
            if (int.TryParse(playerInput, out playerChoice))
            {
                MarkBoard(playerChoice);
                return;
            }
            ThrowInputError();
        }

        public void MarkBoard(int playerChoice)
        {
            if (playerChoice - 1 <= 2)
            {
                Board[0, (playerChoice - 1)] = ComputerCharacter(currentPlayer);
            }
            else if ((playerChoice - 1) <= 5)
            {
                Board[1, (playerChoice - 4)] = ComputerCharacter(currentPlayer);
            }
            else
            {
                Board[2, (playerChoice - 7)] = ComputerCharacter(currentPlayer);
            }
            bool GameDone = ComputeState();
            if (!GameDone)
            {
                NewTurn();
            }
            else
            {
                EndGame();
            }
        }

        public string ComputerCharacter(string currentPlayer)
        {
            string character;
            switch (currentPlayer)
            {
                case "player one":
                    character = "X";
                    break;
                case "player two":
                    character = "0";
                    break;
                default:
                    character = "error";
                    break;
            }
            return character;
        }

        public void NewTurn()
        {
            currentPlayer = currentPlayer == "player one" ? "player two" : "player one";
            StartRound();
        }

        public bool ComputeState()
        {
            bool winnerExists;
            Winner winner;
            CheckXAxis(out winnerExists);
            if (winnerExists)
            {
                return winnerExists;
            }
            CheckYAxis(out winnerExists);
            if (winnerExists)
            {
                return winnerExists;
            }
            CheckDiagonalAxis(out winnerExists);
            return winnerExists;
        }

        public void CheckXAxis(out bool winnerExists)
        {
            winnerExists = false;
            for (int x = 0; x < 3; x++)
            {
                if (Board[x, 0] == null)
                {
                    continue;
                }
                if (Board[x, 0] == Board[x, 1] && Board[x, 1] == Board[x, 2])
                {
                    winnerExists = true;
                }
            }
        }

        public void CheckYAxis(out bool winnerExists)
        {
            winnerExists = false;
            for (int x = 0; x < 3; x++)
            {
                if (Board[0, x] == null)
                {
                    continue;
                }
                if (Board[0, x] == Board[1, x] && Board[1, x] == Board[2, x])
                {
                    winnerExists = true;
                }
            }
        }

        public void CheckDiagonalAxis(out bool winnerExists)
        {
            winnerExists = false;
            if (Board[1, 1] == null)
            {
                return;
            }
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                winnerExists = true;
            }
            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            {
                winnerExists = true;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to a game of tic tac toe");
        }

        public void EndGame()
        {
            Console.WriteLine("{0} won", currentPlayer);
        }

        public void ThrowInputError()
        {
            Console.WriteLine("Input you provided was not correct");
            Console.WriteLine("Input must be a number between 0 and 9");
            Console.WriteLine("Please try again");
            StartRound();
        }
    }

    public class Winner
    {
        private string _winner;
        public Winner(string player)
        {
            _winner = player;
        }
    }
}
