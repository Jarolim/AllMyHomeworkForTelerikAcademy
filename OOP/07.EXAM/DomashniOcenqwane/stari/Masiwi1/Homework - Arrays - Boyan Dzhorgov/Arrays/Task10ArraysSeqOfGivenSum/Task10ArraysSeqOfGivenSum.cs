using System;

// Write a program that finds in given array of integers a sequence of given sum S (if present).
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

namespace Task10ArraysSeqOfGivenSum
{
    class Task10ArraysSeqOfGivenSum
    {
        static void Main()
        {
            Console.WriteLine("Please enter length and elements of an array.");
            Console.Write("Length: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Now enter a number to find if there is a subsequence that sum to it: ");
            int s = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                
            }
        }
    }
}
