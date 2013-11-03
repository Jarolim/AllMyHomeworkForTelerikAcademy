using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                            //Sorting an array means to arrange its elements in increasing order. 
                                            //Write a program to sort an array. Use the "selection sort" algorithm:
                                            //Find the smallest element, move it at the first position, find the smallest from the rest,
                                            //move it at the second position, etc.


namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length N: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("enter array[{0}] : ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            int min;
            for (int j = 0; j < length; j++)
            {
                min = j;
                for (int i = j + 1; i < length; i++)
                {
                    if (arr[min] > arr[i])
                    {
                        min = i;
                    }
                }
                if (min != j)
                {
                    int k = arr[j];
                    arr[j] = arr[min];
                    arr[min] = k;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sorted array: ");
            for (int j = 0; j < length; j++)
            {
                Console.Write(arr[j] + " ");
            }
            Console.WriteLine();
        }
    }
}
