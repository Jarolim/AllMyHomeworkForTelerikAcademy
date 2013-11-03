using System;

// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position,
// find the smallest from the rest, move it at the second position, etc.

namespace Task07ArraysSelectionSort
{
    class Task07ArraysSelectionSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter array length and it's elements in order to sort them in increasing order.");

            Console.Write("Legth: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            int min;

            for (int i = 0; i < n; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }

            Console.Write("The sorted array looks like this: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
