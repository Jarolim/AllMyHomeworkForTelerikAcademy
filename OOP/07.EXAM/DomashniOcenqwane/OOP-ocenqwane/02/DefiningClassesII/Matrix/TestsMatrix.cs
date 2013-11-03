using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class TestsMatrix
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(@"../../imput.txt"));          

            int n = int.Parse(Console.ReadLine());
            decimal[,] matrixArrey = FillMatrix<decimal>(n, n);
            Matrix<decimal> matrixOne = new Matrix<decimal>(n, n, matrixArrey);
            Matrix<decimal> matrixTwo = matrixOne;

            matrixOne.Print();
            Console.WriteLine();
            Console.WriteLine("operator +");
            Matrix<decimal> sum = matrixOne + matrixTwo;
            sum.Print();
            Console.WriteLine();
            Console.WriteLine("operator -");
            Matrix<decimal> sub = matrixOne - matrixTwo;
            sub.Print();
            Console.WriteLine();
            Console.WriteLine("operator *");
            Matrix<decimal> mult = matrixOne * matrixTwo;
            mult.Print();
            Console.WriteLine();
            Console.WriteLine("True, False");
            mult.Print();
            Console.WriteLine();
            if (mult)
            {
                Console.WriteLine("no zero elements - true");
            }
            else
            {
                Console.WriteLine("there is zero elements - false");
            }

        }

        static T[,] FillMatrix<T>(int rows, int cols) where T : IComparable
        {
            T[,] matrix = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dynamic input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    matrix[i, j] = input;
                }
            }
            return matrix;
        }
     }
 }
