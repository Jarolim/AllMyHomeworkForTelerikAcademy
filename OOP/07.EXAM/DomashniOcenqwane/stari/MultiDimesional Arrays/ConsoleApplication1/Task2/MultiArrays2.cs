using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MultiArrays2
    {
        //   static void PrintMatrix(int[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write("{0,4}", matrix[row, col]);
        //        }
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }
        //}

        static void InitializationofMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }

            }
        }

        static void Sum3x3Matrix(int[,] matrix,ref int bestSum,ref int bestRow,ref int bestCol)
        {
            
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
           
        }

        static void Main()
        {
            Console.WriteLine("Input number N (integer)");
            int sizeN = int.Parse(Console.ReadLine());
            Console.WriteLine("Input number M (integer)");
            int sizeM = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeN, sizeM];
            InitializationofMatrix(matrix);
            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            Sum3x3Matrix(matrix, ref bestSum, ref bestRow,ref bestCol);


            Console.WriteLine("The best platform is:");
            Console.WriteLine(" {0} {1} {2}", matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1], matrix[bestRow, bestCol + 2]);
            Console.WriteLine(" {0} {1} {2}", matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1], matrix[bestRow + 1, bestCol + 2]);
            Console.WriteLine(" {0} {1} {2}", matrix[bestRow + 2, bestCol], matrix[bestRow + 2, bestCol + 1], matrix[bestRow + 2, bestCol + 2]);
            Console.WriteLine("The maximal sum is: {0}", bestSum);
        }
    }
}
