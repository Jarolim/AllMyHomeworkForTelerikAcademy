/* Write a program that reads from the console a sequence of 
 positive integer numbers. The sequence ends when empty 
 line is entered. Calculate and print the sum and average 
 of the elements of the sequence. Keep the sequence in List<int>. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SequenceSumAverage
{
    class SequenceSumAverage
    {
        static void Main()
        {
            List<int> numberContainer = new List<int>();

            Console.WriteLine("Please input the numbers: ");

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == string.Empty)
                {
                    break;
                }

                else
                {
                    numberContainer.Add(int.Parse(inputLine));
                }
            }

            int sum = numberContainer.Sum();
            double average = numberContainer.Average();

            Console.WriteLine("The sum = {0}", sum);
            Console.WriteLine("The average = {0}", average);
        }
    }
}
