using System;

// Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

namespace Task06ArraysMaxSumOfKElementsInArray
{
    class Task06ArraysMaxSumOfKElementsInArray
    {
        static void Main()
        {
            Console.WriteLine("Please enter two integers, N and K.");
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Now please enter {0} elements in order to build and array and find in it those {1} thah have maximum sum.", n , k);
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
            
            Console.Write("The {0} elements that have maximun sum are: ",k);
            for (int i = n - k; i < n; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
