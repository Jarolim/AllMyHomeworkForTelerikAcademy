using System;
using System.Collections.Generic;

// Write a program that finds the most frequent number in an array.
// Example:	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

namespace Task09ArraysMostFreqNum
{
    class Task09ArraysMostFreqNum
    {
        static void Main()
        {
            Console.WriteLine("Please enter length and elements for an array to find the most frequent number in it.");
            Console.Write("Length: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            int count;
            int bestCount = 0;
            List<int> mostFreqNum = new List<int>();

            for (int i = 0; i < length; i++)
            {
                count = 1;
                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] == array[i])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    if (count == bestCount)
                    {
                        mostFreqNum.Add(array[i]);
                    }
                    if (count > bestCount)
                    {
                        mostFreqNum.Clear();
                        mostFreqNum.Add(array[i]);
                        bestCount = count;
                    }
                }
            }

            Console.WriteLine("Most frequent number(s):");
            foreach (var element in mostFreqNum)
            {
                Console.WriteLine
(element + " (" + bestCount + " times)");
            }
        }
    }
}
