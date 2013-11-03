using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                //Write a program that reads two numbers N and K and generates all the combinations
                                //of K distinct elements from the set [1..N].
namespace task21
{
    class Program
    {
        static void Main()
        {
            int n = 5;
            int k = 2;

            int[] array = new int[k];
            Variations(array, 0, n, 1);
        }

        static void Variations(int[] array, int index, int n, int k)
        {
            if (index == array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int j = k; j <= n; j++)
                {
                    array[index] = j;
                    Variations(array, index + 1, n, j + 1);
                }
            }
        }
    }
}