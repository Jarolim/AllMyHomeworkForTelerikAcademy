using System;
using System.Collections.Generic;

class BestSum
{
    public struct CellCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellCoordinates(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }

    public static int bestSum = int.MinValue;
    public static List<CellCoordinates> bestSubmatrixes = new List<CellCoordinates>();

    static void Main()
    {
        Console.Write("Input first matrix dimension: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Input second matrix dimension: ");
        int columns = int.Parse(Console.ReadLine());

        if (rows < 3 || columns < 3)
        {
            Console.WriteLine("Both matrix dimensions must be >= 3!");
            return;
        }


        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine("Input elements on the row number {0}!", i);
            for (int j = 0; j < columns; j++)
            {
                Console.Write("Input element {0}: ", j);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        PrintMatrix(matrix);

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < columns - 2; j++)
            {
                CheckSubmatrix(matrix, i, j);
            }
        }

        Console.WriteLine("\nThere {2} {0} 3x3 {3} with the maximal element sum of {1}", bestSubmatrixes.Count, bestSum,
            bestSubmatrixes.Count > 1 ? "are" : "is", bestSubmatrixes.Count > 1 ? "submatrixes" : "submatrix");
        int[,] tempMatrix = new int[3, 3];
        foreach (CellCoordinates submatrix in bestSubmatrixes)
        {
            Console.WriteLine();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    tempMatrix[x, y] = matrix[x + submatrix.X, y + submatrix.Y];
                }
            }
            PrintMatrix(tempMatrix);
        }

    }

    public static void CheckSubmatrix(int[,] matrix, int i, int j)
    {
        int sum = 0;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                sum += matrix[i + x, j + y];
            }
        }

        if (sum >= bestSum)
        {
            if (sum > bestSum)
            {
                bestSubmatrixes = new List<CellCoordinates>();
                bestSum = sum;
            }
            bestSubmatrixes.Add(new CellCoordinates(i, j));
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int maxLength = 0;
        foreach (int element in matrix)
        {
            if (element.ToString().Length > maxLength) maxLength = element.ToString().Length;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ",
                    matrix[i, j].ToString().PadLeft(matrix[i, j].ToString().Length + (maxLength - matrix[i, j].ToString().Length) / 2).PadRight(maxLength));
            }
            Console.WriteLine();
        }
        
    }
}