using System;
using System.Text;

namespace RotatingMatrix
{
	public class WalkInMatrix
	{
		public const int MaxSize = 100;

		public int[,] Matrix { get; set; }

		public WalkInMatrix(int size)
		{
			if (size < 1 || size > MaxSize)
			{
				throw new ArgumentOutOfRangeException(
					"size",
					string.Format("size must be in the range between 1 and {0}.", MaxSize));
			}

			this.Matrix = new int[size, size];
			this.Matrix = FillMatrix(size);
		}

		public static void Main(string[] args)
		{
			int n = ReadInput();
			WalkInMatrix matrix = new WalkInMatrix(n);
			Console.Write(matrix.ToString());
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for (int rows = 0; rows < this.Matrix.GetLength(0); rows++)
			{
				for (int cols = 0; cols < this.Matrix.GetLength(1); cols++)
				{
					sb.AppendFormat("{0,4}", this.Matrix[rows, cols]);
				}

				sb.AppendLine();
			}

			string result = sb.ToString();

			return result;
		}

		public static int[,] FillMatrix(int n)
		{
			int[,] matrix = new int[n, n];
			Position position = new Position(0, 0);
			int value = 1, currentDirectionX = 1, currentDirectionY = 1;

			while (value <= n * n)
			{
				matrix[position.Row, position.Col] = value;
				if (!CheckIfFreeCellExists(matrix, position.Row, position.Col))
				{
					value++;

					if (value > n * n)
					{
						break;
					}

					FindEmptyCellCoordinates(matrix, position);
					matrix[position.Row, position.Col] = value;
					currentDirectionX = 1;
					currentDirectionY = 1;
				}

				while (CheckIfPositionAfterChangeIsOutOfMatrix(n, position.Row, currentDirectionX) ||
						CheckIfPositionAfterChangeIsOutOfMatrix(n, position.Col, currentDirectionY) ||
						 matrix[position.Row + currentDirectionX, position.Col + currentDirectionY] != 0)
				{
					ChangeDirection(ref currentDirectionX, ref currentDirectionY);
				}

				position.Update(currentDirectionX, currentDirectionY);
				value++;
			}

			return matrix;
		}

		private static int ReadInput()
		{
			Console.WriteLine("Enter a positive number ");
			string input = Console.ReadLine();
			int n = 0;
			while (!int.TryParse(input, out n) || n < 1 || n > 100)
			{
				Console.WriteLine("You haven't entered a correct positive number. Enter integer between 1 and 100.");
				input = Console.ReadLine();
			}

			return n;
		}

		private static bool CheckIfPositionAfterChangeIsOutOfMatrix(int n, int currentX, int currentDirectionX)
		{
			bool isOutOfMatrix = currentX + currentDirectionX >= n || currentX + currentDirectionX < 0;
			return isOutOfMatrix;
		}

		private static void ChangeDirection(ref int currentDirectionX, ref int currentDirectionY)
		{
			int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
			int lastDirectionPosition = 7;

			int currentDirection = 0;

			for (int position = 0; position <= lastDirectionPosition; position++)
			{
				if (directionX[position] == currentDirectionX && directionY[position] == currentDirectionY)
				{
					currentDirection = position;
					break;
				}
			}

			if (currentDirectionX == directionX[lastDirectionPosition] &&
				currentDirectionY == directionY[lastDirectionPosition])
			{
				currentDirectionX = directionX[0];
				currentDirectionY = directionY[0];
				return;
			}

			// change the direction of the walk
			currentDirectionX = directionX[currentDirection + 1];
			currentDirectionY = directionY[currentDirection + 1];
		}

		private static bool CheckIfFreeCellExists(int[,] matrix, int currentX, int currentY)
		{
			int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
			int lastDirectionPosition = 7;

			// check if increase of x and y will get us out of the array
			for (int i = 0; i <= lastDirectionPosition; i++)
			{
				if (CheckIfPositionAfterChangeIsOutOfMatrix(matrix.GetLength(0), currentX, directionX[i]))
				{
					directionX[i] = 0;
				}

				if (CheckIfPositionAfterChangeIsOutOfMatrix(matrix.GetLength(0), currentY, directionY[i]))
				{
					directionY[i] = 0;
				}
			}

			for (int i = 0; i <= lastDirectionPosition; i++)
			{
				// if we have free cells
				if (matrix[currentX + directionX[i], currentY + directionY[i]] == 0)
				{
					return true;
				}
			}

			return false;
		}

		private static void FindEmptyCellCoordinates(int[,] matrix, Position position)
		{
			position.Row = 0;
			position.Col = 0;

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					// if the cell is free
					if (matrix[row, col] == 0)
					{
						position.Row = row;
						position.Col = col;
						return;
					}
				}
			}
		}
	}
}