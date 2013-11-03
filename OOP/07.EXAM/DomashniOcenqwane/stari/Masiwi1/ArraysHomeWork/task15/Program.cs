using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                //Write a program that finds all prime numbers in the range [1...10 000 000].
                                //Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
namespace task15
{
    class Program
    {

        static void Main()
        {
            List<int> numbers = new List<int>();
            int count = 10000000;
            for (int i = 0; i <= count; i++)
            {
                numbers.Add(i);
            }

            for (int i = 2; i < count; i++)
            {
                if (numbers[i] != 0)
                {
                    for (int k = numbers[i] * 2; k <= count; k += numbers[i])
                    {
                        numbers[k] = 0;
                    }
                    Console.WriteLine("{0,4} ", numbers[i]);
                }
            }
        }
    }
}
