using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class Labyrinth : Game
    {
        public const int LabyrinthSize = 7;

        private readonly Random randomNumber = new Random();
        private bool isWonWithEscape = false;
        private PlayerPosition position;
        private ScoreBoard scoreBoard = new ScoreBoard();
        private readonly Cell[,] board = new Cell[LabyrinthSize, LabyrinthSize];

        public Labyrinth(PlayerPosition startPosition)
        {
            if (startPosition == null)
            {
                throw new ArgumentNullException("The start position cannot be null");
            }

            this.Position = startPosition;
        }

        public Labyrinth(PlayerPosition startPosition, Cell[,] board)
        {
            if (startPosition == null)
            {
                throw new ArgumentNullException("The start position cannot be null");
            }

            if (board == null)
            {
                throw new ArgumentNullException("The board cannot be null");
            }

            this.Position = startPosition;
            this.board = board;
        }

        #region Properties

        public bool IsWonWithEscape
        {
            get
            {
                return this.isWonWithEscape;
            }

            set
            {
                this.isWonWithEscape = value;
            }
        }

        public PlayerPosition Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public ScoreBoard ScoreBoard
        {
            get
            {
                return this.scoreBoard;
            }

            set
            {
                this.scoreBoard = value;
            }
        }

        public Cell[,] Board
        {
            get
            {
                return this.Clone();
            }
        }

        #endregion

        #region Methods

        public void StartGame()
        {
            this.IsRunning = true;
            Console.WriteLine(Message.Welcome);

            while (this.IsRunning)
            {
                this.IsGameRestarted = false;
                this.IsWonWithEscape = false;

                do
                {
                    this.Generate();
                }
                while (!this.ExitPathAvailable());

                Console.WriteLine(this);
                this.Run(this.Position.X, this.Position.Y);

                if (this.IsWonWithEscape)
                {
                    Console.Write("Please enter your name: ");
                    string name = Console.ReadLine();
                    this.ScoreBoard.AddNewScore(this.CurrentMoves, name);
                    this.IsRunning = true;
                }
            }
        }

        private void Run(int x, int y)
        {
            this.CurrentMoves = 0;

            while (this.IsRunning)
            {
                Console.Write(Message.ValidCommands);
                string moveDirection = Console.ReadLine().ToLower();

                this.ProcessMove(moveDirection, ref x, ref y);

                if (this.IsGameRestarted)
                {
                    return;
                }
                else if (this.IsRunning)
                {
                    this.IsGameWon(x, y);
                    Console.WriteLine(this);
                }
            }
        }

        private void ProcessMove(string moveDirection, ref int x, ref int y)
        {
            switch (moveDirection)
            {
                case "d":
                    this.ProcessMoveDown(ref x, y);
                    break;
                case "u":
                    this.ProcessMoveUp(ref x, y);
                    break;
                case "r":
                    this.ProcessMoveRight(x, ref y);
                    break;
                case "l":
                    this.ProcessMoveLeft(x, ref y);
                    break;
                case "top":
                    Console.WriteLine(this.ScoreBoard);
                    break;
                case "restart":
                    this.IsGameRestarted = true;
                    return;
                case "exit":
                    Console.WriteLine(Message.GoodBye);
                    this.IsRunning = false;
                    return;
                default:
                    Console.WriteLine(Message.InvalidCommand);
                    break;
            }
        }

        private bool IsGameWon(int x, int y)
        {
            if (this.IsOnBorder(x, y))
            {
                Console.WriteLine(Message.Congratulations, this.CurrentMoves);
                this.IsRunning = false;
                this.IsWonWithEscape = true;

                return true;
            }

            return false;
        }

        private void ProcessMoveLeft(int x, ref int y)
        {
            if (this.board[x, y - 1].Value == Cell.Empty)
            {
                this.board[x, y].Value = Cell.Empty;
                this.board[x, y - 1].Value = Cell.Player;
                y--;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }
        }

        private void ProcessMoveRight(int x, ref int y)
        {
            if (this.board[x, y + 1].Value == Cell.Empty)
            {
                this.board[x, y].Value = Cell.Empty;
                this.board[x, y + 1].Value = Cell.Player;
                y++;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }
        }

        private void ProcessMoveUp(ref int x, int y)
        {
            if (this.board[x - 1, y].Value == Cell.Empty)
            {
                this.board[x, y].Value = Cell.Empty;
                this.board[x - 1, y].Value = Cell.Player;
                x--;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }
        }

        private void ProcessMoveDown(ref int x, int y)
        {
            if (this.board[x + 1, y].Value == Cell.Empty)
            {
                this.board[x, y].Value = Cell.Empty;
                this.board[x + 1, y].Value = Cell.Player;
                x++;
                this.CurrentMoves++;
            }
            else
            {
                Console.WriteLine(Message.InvalidMove);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int col = 0; col < this.board.GetLength(1); col++)
                {
                    result.Append(this.board[row, col].Value).Append(" ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public Cell[,] Generate()
        {
            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int column = 0; column < this.board.GetLength(1); column++)
                {
                    int randomValue = this.randomNumber.Next(4);
                    if (randomValue == 0)
                    {
                        this.board[row, column] = new Cell(row, column, '-');
                    }
                    else
                    {
                        this.board[row, column] = new Cell(row, column, 'x');
                    }
                }
            }

            this.board[this.Position.X, this.Position.Y].Value = '*';

            return this.Clone();
        }

        private bool IsOnBorder(int rowIndex, int columnIndex)
        {
            if (rowIndex == 0 || rowIndex == LabyrinthSize - 1)
            {
                return true;
            }
            else if (columnIndex == 0 || columnIndex == LabyrinthSize - 1)
            {
                return true;
            }

            return false;
        }

        private void VisitCell(Cell[,] labyrinth, Queue<Cell> visitedCells, 
            int row, int column)
        {
            if (labyrinth[row, column].Value == Cell.Empty || 
                labyrinth[row, column].Value == Cell.Player)
            {
                labyrinth[row, column].Value = Cell.Block;
                visitedCells.Enqueue(labyrinth[row, column]);
            }
        }

        private bool ExitPathAvailable()
        {
            Queue<Cell> visitedCells = new Queue<Cell>();
            Cell[,] clonedLabyrinth = this.Clone();

            this.VisitCell(clonedLabyrinth, visitedCells, 
                this.Position.X, this.Position.Y);

            while (visitedCells.Count > 0)
            {
                Cell currentCell = visitedCells.Dequeue();
                int row = currentCell.Row;
                int column = currentCell.Column;

                if (this.IsOnBorder(row, column))
                {
                    return true;
                }

                // We are visiting each of the neighbours of the current cell.
                this.VisitCell(clonedLabyrinth, visitedCells, row, column + 1);
                this.VisitCell(clonedLabyrinth, visitedCells, row, column - 1);
                this.VisitCell(clonedLabyrinth, visitedCells, row + 1, column);
                this.VisitCell(clonedLabyrinth, visitedCells, row - 1, column);
            }

            return false;
        }

        public Cell[,] Clone()
        {
            Cell[,] cloned = new Cell[LabyrinthSize, LabyrinthSize];

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int column = 0; column < LabyrinthSize; column++)
                {
                    cloned[row, column] = this.board[row, column].Clone() as Cell;
                }
            }

            return cloned;
        }

        #endregion
    }
}