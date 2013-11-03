/*Write a program that removes from given sequence all numbers 
that occur odd number of times. Example:
{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RemoveOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddNumberOfTimes
    {
        static void Main()
        {
            string line = "4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2";

            string[] elements = line.Split(',');

            List<int> originalList = new List<int>();

            foreach (var element in elements)
            {
                originalList.Add(int.Parse(element));
            }

            Console.WriteLine("The list before removing all the odd ocurrances of elements:");
            Console.WriteLine(string.Join(", ", originalList));

            Dictionary<int, int> newList = new Dictionary<int, int>();

            //counting occurances
            foreach (var element in originalList)
            {
                if (!newList.Keys.Contains(element))
                {
                    newList.Add(element, 1);
                }
                else
                {
                    newList[element]++;
                }
            }

            //removing odd occurances
            foreach (KeyValuePair<int, int> pair in newList)
            {
                if (pair.Value % 2 != 0)
                {
                    originalList.RemoveAll(x => x == pair.Key);
                }
            }

            Console.WriteLine("The list after removing all the odd ocurrances of elements:");
            Console.WriteLine(string.Join(", ", originalList));
        }
    }
}
