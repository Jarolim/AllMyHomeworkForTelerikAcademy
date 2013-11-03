/* Write a program that finds in given array of integers 
 (all belonging to the range [0..1000]) how many times each 
 of them occurs.
 Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 2  2 times
 3  4 times
 4  3 times */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.OccurancesOfNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OccurancesOfNums
    {
        static void Main()
        {
            List<int> originalList = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (var element in originalList)
            {
                int value = 0;
                if (!dictionary.TryGetValue(element, out value))
                {
                    dictionary.Add(element, 1);
                }
                else
                {
                    dictionary[element]++;
                }
            }

            var keyList = dictionary.Keys.ToList();

            //to display the answers like the example
            keyList.Sort();

            foreach (var key in keyList)
            {
                Console.WriteLine("{0}->{1} times", key, dictionary[key]);
            }
        }
    }
}
