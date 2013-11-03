using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                    //Write a program that reads two integer numbers N and K
                                    //and an array of N elements from the console. Find in the 
                                    //array those K elements that have maximal sum.

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length N: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("enter array[{0}] : ",i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter how many digits you want to print K: ");
            int k = int.Parse(Console.ReadLine());
            int maxNum = array.Max();
            Array.Sort(array);
            for (int i = array.Length - k; i <= array.Length - 1; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}



