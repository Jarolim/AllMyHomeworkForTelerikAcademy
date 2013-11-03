using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Mines
    {
        public class Points
        {
            string name;
            int thisPoints;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int points
            {
                get { return thisPoints; }
                set { thisPoints = value; }
            }

            public Points() { }

            public Points(string name, int thisPoints)
            {
                this.name = name;
                this.thisPoints = thisPoints;
            }
        }

        static void Main(string[] arguments)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool isBomb = false;
            List<Points> topScore = new List<Points>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            const int maxPoints = 35;
            bool isWinner = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play “Minesweeper”. Try yor luck and find fields without mines!");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("'top' shows the charts");
                    Console.WriteLine("'restart' starts a new game");
                    Console.WriteLine("'exit' ends game");
                    GameField(field);
                    isNewGame = false;
                }

                Console.Write("Enter row and column (with a space between) : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Chart(topScore);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = PlaceBombs();
                        GameField(field);
                        isBomb = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye! Have a wonderfull day!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                SurroundingBombCount(field, bombs, row, column);
                                counter++;
                            }
                            if (maxPoints == counter)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                GameField(field);
                            }
                        }
                        else
                        {
                            isBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (isBomb)
                {
                    GameField(bombs);
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("Your points: {0}", counter);
                    Console.WriteLine("Please enter your nickname: ");
                    string nickname = Console.ReadLine();
                    Points playerPoints = new Points(nickname, counter);
                    if (topScore.Count < 5)
                    {
                        topScore.Add(playerPoints);
                    }
                    else
                    {
                        for (int i = 0; i < topScore.Count; i++)
                        {
                            if (topScore[i].points < playerPoints.points)
                            {
                                topScore.Insert(i, playerPoints);
                                topScore.RemoveAt(topScore.Count - 1);
                                break;
                            }
                        }
                    }

                    topScore.Sort((Points playerOne, Points playerTwo) => playerTwo.Name.CompareTo(playerOne.Name));
                    topScore.Sort((Points playerOne, Points playerTwo) => playerTwo.points.CompareTo(playerOne.points));
                    Chart(topScore);

                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    isBomb = false;
                    isNewGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nCONGRATULATIONS! You opened all fields without a scratch!");
                    GameField(bombs);
                    Console.WriteLine("Please enter your nikname: ");
                    string nickname = Console.ReadLine();
                    Points points = new Points(nickname, counter);
                    topScore.Add(points);
                    Chart(topScore);
                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    isWinner = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria.");
            Console.WriteLine("See you soon.");
            Console.Read();
        }

        private static void Chart(List<Points> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Fields opened",
                        i + 1, points[i].Name, points[i].points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoreboard!\n");
            }
        }

        private static void SurroundingBombCount(char[,] field,
            char[,] bombs, int row, int column)
        {
            char bombsCount = GetSurroundingBombCount(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void GameField(char[,] board)
        {
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < column; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] bombField = new char[fieldRows, fieldColumns];

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    bombField[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int random in randomNumbers)
            {
                int column = (random / fieldColumns);
                int row = (random % fieldColumns);
                if (row == 0 && random != 0)
                {
                    column--;
                    row = fieldColumns;
                }
                else
                {
                    row++;
                }

                bombField[column, row - 1] = '*';
            }

            return bombField;
        }

        private static void SetSurroundingBombCount(char[,] board)
        {
            int column = board.GetLength(0);
            int row = board.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char bombsSurroundingCount = GetSurroundingBombCount(board, i, j);
                        board[i, j] = bombsSurroundingCount;
                    }
                }
            }
        }

        private static char GetSurroundingBombCount(char[,] board, int row, int column)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    count++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}