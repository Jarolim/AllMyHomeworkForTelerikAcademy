/*Write a program that reads a sequence of integers 
(List<int>) ending with an empty line and sorts them 
in an increasing order.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SortInIncreasingOrder
{
    class SortInIncreasingOrder
    {
        static void Main()
        {
            List<int> numberContainer = new List<int>();

            Console.WriteLine("Please input the numbers to sort:");

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

            numberContainer.Sort();

            Console.WriteLine(string.Join(" ", numberContainer));
        }
    }
}
