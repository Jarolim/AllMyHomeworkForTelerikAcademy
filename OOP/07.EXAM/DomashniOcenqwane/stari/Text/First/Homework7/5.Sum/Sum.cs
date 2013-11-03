using System;
using System.IO;
    class Sum
    {
        static int[,] ReadMatrix()
        {
            using (StreamReader input = new StreamReader(@"..\..\..\Text files are here\05. Input Matrix.txt"))
            {
                int n = int.Parse(input.ReadLine());
                int[,] matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string[] numbers = input.ReadLine().Split(' ');

                    for (int j = 0; j < n; j++)
                        matrix[i, j] = int.Parse(numbers[j]);
                }

                return matrix;
            }
        }

        static int GetMax(int[,] matrix)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    maxSum = Math.Max(maxSum, matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1]);

            return maxSum;
        }

        static void WriteResult(int maxSum)
        {
            using (StreamWriter output = new StreamWriter(@"..\..\..\Text files are here\05. Output Matrix.txt"))
                output.WriteLine(maxSum);
        }

        static void Main()
        {
            WriteResult(GetMax(ReadMatrix()));
        }
    }

