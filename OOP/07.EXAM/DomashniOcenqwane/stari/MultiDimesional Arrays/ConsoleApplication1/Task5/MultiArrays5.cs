using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MultiArrays5
    {
        static void PrintMatrix(ref string[] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.Write("string {0} = ", row);
                Console.Write("{0}" + " ", matrix[row]);
            }
            Console.WriteLine();
        }


        static void InitializationofMatrix(ref string[] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                matrix[i] = Console.ReadLine();

            }
        }

        //class StringComparer : IComparer<string>
        //{
        //    public int Compare(string matrix1, string matrix2)
        //    {
        //        matrix1.Length.CompareTo(matrix2.Length);
        //        return matrix1.CompareTo(matrix2);
        //    }
        //}

        static void Main()
        {

            Console.WriteLine("Input number (integer)");
            int size = int.Parse(Console.ReadLine());
            string[] matrix = new string[size];
            InitializationofMatrix(ref matrix);
            Array.Sort(matrix, (x, y) => x.Length.CompareTo(y.Length));
            PrintMatrix(ref matrix);

        }
        //static void Main()
        //    {
        //        Console.Write("number of strings in array = ");
        //        int N = Int32.Parse(Console.ReadLine());
        //        string[] array = new string[N];
        //        for (int i = 0; i < N; i++)
        //        {
        //            Console.Write("string {0} = ", i);
        //            array[i] = Console.ReadLine();
        //        }
        //        Array.Sort(array,(x,y) => x.Length.CompareTo(y.Length));
        //        Console.WriteLine();
        //        Console.WriteLine("the sorted string array:");
        //        Console.WriteLine();
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            for (int j = 0; j < array[i].Length; j++)
        //            {
        //                Console.Write(array[i][j]);
        //            }
        //            Console.WriteLine();
        //        }
        //        Console.WriteLine();
        //}
    }
}
