/* Write a method that finds the longest subsequence of
 equal numbers in given List<int> and returns the result 
 as new List<int>. Write a program to test whether the 
 method works correctly. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.LongestSubsequenceOfEqualNumbers
{
    

    public class LongestSubsequenceOfEqualNumbers
    {
        public static void Main()
        {
            //Console.WriteLine("Please input the sequence of integers separated by an interval: ");
            //string line = Console.ReadLine();
            //string[] elements = line.Split(' ');

            List<int> unsortedList = new List<int>() 
            { 
            3, 4, 5, 6,
            7, 7, 7, 8,
            9, 9, 9, 9
            };

            //foreach (string el in elements)
            //{
            //    unsortedList.Add(int.Parse(el));
            //}

            Console.Write("The longest subsequence of equal elements is: ");
            Console.WriteLine();
            Console.WriteLine(String.Join(" ", GetLongestEqualSubseq(unsortedList)));
            List<int> expected = new List<int>() { 9, 9, 9, 9 };
            Console.WriteLine(String.Join(" ", expected));
            Console.WriteLine(expected[0] == GetLongestEqualSubseq(unsortedList)[0]);
        }

        public static List<int> GetLongestEqualSubseq(List<int> list)
        {
            if (list.Count == 0 || list.Count == 1)
            {
                return list;
            }

            int currentElIndex = 0;
            int currentElStreak = 1;
            int longestElStreak = 0;
            int bestStreakIndex = 0;

            while (currentElIndex < list.Count - 1)
            {
                while ((currentElIndex + currentElStreak < list.Count) &&
                    (list[currentElIndex + currentElStreak] == list[currentElIndex]))
                {
                    currentElStreak++;
                }

                if (currentElStreak >= longestElStreak)
                {
                    longestElStreak = currentElStreak;
                    bestStreakIndex = currentElIndex;
                }

                currentElIndex += currentElStreak;
                currentElStreak = 1;

            }

            var bestSequence = new List<int>();

            for (int i = bestStreakIndex;
                i < bestStreakIndex + longestElStreak;
                i++)
            {
                bestSequence.Add(list[i]);
            }

            return bestSequence;
        }
    }
}
