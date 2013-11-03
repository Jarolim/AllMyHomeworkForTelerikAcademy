/*Write a program that removes from given sequence 
  all negative numbers.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RemoveAllNegativeNums
{
    class RemoveAllNegativeNums
    {
        static void Main()
        {
            string line = "3 -9 6 -5 55 84 22 6 -55 56 -100 22";

            string[] elements = line.Split(' ');

            LinkedList<int> list = new LinkedList<int>();

            foreach (string element in elements)
            {
                list.AddLast(int.Parse(element));
            }

            Console.WriteLine("The list before removing all the negative elements:");
            Console.WriteLine(string.Join(", ", list));

            var firstElement = list.First;

            while (firstElement != null)
            {
                var nextElement = firstElement.Next;

                if (firstElement.Value < 0)
                {
                    list.Remove(firstElement);
                }

                firstElement = nextElement;
            }

            Console.WriteLine("The list after removing all the negative elements:");
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
