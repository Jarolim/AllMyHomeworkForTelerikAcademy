//Write a program that reads a text file containing a square matrix of numbers and finds in 
//the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in
//the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file. Example:
//4
//2 3 3 4
//0 2 3 4			17
//3 7 1 2
//4 3 3 2
using System;
using System.IO;

class AreaWithMaxSumInMatrixInFile
{
    static int size = 2;

    static void Main()
    {
        StreamReader reader = new StreamReader("Matrix.txt");
        using (reader)
        {
            int[,] matrix = ReadFromFile(reader);


            PrintMatrix(matrix);

            int MaxSum = int.MinValue;
            int rowOfMaxSquare = 0;
            int colOfMaxSquare = 0;
            int rownum = matrix.GetLength(0);
            int colnnum = matrix.GetLength(1);
            for (int row = 0; row <= rownum - size; row++)
            {
                for (int col = 0; col <= colnnum - size; col++)
                {
                    int tempSum = SquareSum(matrix, size, row, col);
                    if (tempSum > MaxSum)
                    {
                        MaxSum = tempSum;
                        rowOfMaxSquare = row;
                        colOfMaxSquare = col;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("MaxSum->{0},coordinates of first element->[{1},{2}]", MaxSum, rowOfMaxSquare, colOfMaxSquare);
        }
    }

    private static int[,] ReadFromFile(StreamReader reader)
    {
        int N = int.Parse(reader.ReadLine());
        int[,] matrix = new int[N, N];

        string line = reader.ReadLine();
        for (int row = 0; row < N && line != null; row++)
        {
            string[] lineNumbers = line.Split(' ');
            for (int col = 0; col < N; col++)
            {
                matrix[row, col] = int.Parse(lineNumbers[col]);
            }
            line = reader.ReadLine();
        }
        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void RandomMatrix(int[,] matrix)
    {
        Random rand = new Random();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rand.Next(-10, 10);
            }
        }
    }

    private static int SquareSum(int[,] matrix, int squareSize, int row, int col)
    {
        int tempSum = 0;
        for (int row1 = row; row1 < squareSize + row; row1++)
        {
            for (int col1 = col; col1 < squareSize + col; col1++)
            {
                tempSum += matrix[row1, col1];
            }
        }

        return tempSum;
    }
}
