using System;

// Write a program that finds the sequence of maximal sum in given array.
// Example:
// {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
// Can you do it with only one loop (with single scan through the elements of the array)?

namespace Task08ArraysSeqOfMaxSum
{
    class Task08ArraysSeqOfMaxSum
    {
        static void Main()
        {
            Console.Write("Please enter array legth to finds the sequence of maximal sum in it: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("It's element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            int max = array[0];
            int maxEnd = array[0];
            int seq = 1;
            int maxSeq = 1;
            int start = 0;
            int startTemp = 0;
            
            for (int i = 1; i < length; ++i)
            {
                if (array[i] + maxEnd > array[i])
                {
                    maxEnd = array[i] + maxEnd;
                    seq++;
                }
                else
                {
                    maxEnd = array[i];
                    startTemp = i;
                    seq = 1;
                }
                if (maxEnd > max)
                {
                    max = maxEnd;
                    maxSeq = seq;
                    start = startTemp;
                }
            }

            Console.Write("The sequence of maximal sum is ");
            for (int i = start; i < start + maxSeq; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
