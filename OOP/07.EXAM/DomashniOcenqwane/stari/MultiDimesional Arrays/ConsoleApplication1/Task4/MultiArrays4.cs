using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MultiArrays4
    {
         static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

        static void InitializationofMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }

            }
        }

    static void Main()
        {
            int Result;
        Console.WriteLine("Input number (integer)");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        InitializationofMatrix(ref matrix);
        Console.WriteLine("Input value K (integer)");
        int maxNumber = int.Parse(Console.ReadLine());
        Array.Sort(matrix);
        int indexOfElement = Array.BinarySearch(matrix, maxNumber);
        if (indexOfElement >= 0)
        { 
            Result = matrix[indexOfElement,indexOfElement]; // exception get need some comments for help!
        }
        else{ Result = ~indexOfElement - 1;}
        Console.WriteLine(Result);       
        
    }
}
    
}
