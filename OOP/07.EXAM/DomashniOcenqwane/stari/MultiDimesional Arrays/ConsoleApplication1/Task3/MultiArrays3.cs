using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MultiArrays3
    {
        static void PrintMatrix(string bestindex, int bestsum)
        {
            Console.WriteLine("{0} is counted {1}times", bestindex, bestsum);


        }

        static void InitializationofMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }
        }


        static void CouuntStringsRows(string[,] matrix, ref int bestsum, ref string bestindex)
        {
            int count = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = i; k < matrix.GetLength(0) - 1; k++)
                    {
                        if (matrix[k, j] == matrix[k + 1, j])
                        {
                            count++;
                        }
                        else
                        { break; }
                    }
                    if (count > bestsum)
                    {
                        bestsum = count;
                        bestindex = matrix[i, j];
                    }
                    count = 1;
                }

            }
        }
        static void CouuntStringsColumns(string[,] matrix, ref int bestsum, ref string bestindex)
        {
            int count = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = j; k < matrix.GetLength(0) - 1; k++)
                    {
                        if (matrix[k, j] == matrix[k, j + 1])
                        {
                            count++;
                        }
                        else
                        { break; }
                    }
                    if (count > bestsum)
                    {
                        bestsum = count;
                        bestindex = matrix[i, j];
                    }
                    count = 1;
                }

            }
        }
        static void CouuntStringsDiagonals(string[,] matrix, ref int bestsum, ref string bestindex)
        {
            int count = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = j; k < matrix.GetLength(0) - 1; k++)
                    {
                        if (matrix[k, j] == matrix[k, j + 1])
                        {
                            count++;
                        }
                        else
                        { break; }
                    }
                    if (count > bestsum)
                    {
                        bestsum = count;
                        bestindex = matrix[i, j];
                    }
                    count = 1;
                }

            }
        }


        static void Main()
        {
            Console.WriteLine("Input number N (integer)");
            int sizeN = int.Parse(Console.ReadLine());
            Console.WriteLine("Input number M (integer)");
            int sizeM = int.Parse(Console.ReadLine());
            string[,] matrix = new string[sizeN, sizeM];
            InitializationofMatrix(matrix);
            int bestsum = 0;
            string bestindex = "FALSE";
            CouuntStringsRows(matrix, ref bestsum, ref bestindex);
            PrintMatrix(bestindex, bestsum);
            CouuntStringsColumns(matrix, ref bestsum, ref bestindex);
            PrintMatrix(bestindex, bestsum);
            CouuntStringsDiagonals(matrix, ref bestsum, ref bestindex);
            PrintMatrix(bestindex, bestsum);
            //PrintMatrix(matrix);

        }
    }
}
