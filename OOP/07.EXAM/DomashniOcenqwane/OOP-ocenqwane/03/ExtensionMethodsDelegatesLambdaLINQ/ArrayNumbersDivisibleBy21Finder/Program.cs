using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayNumbersDivisibleBy21Finder
{
    class Program
    {
        public static void PrintDivisibleBy21LINQ(int[] numbers)
        {
            var divisibleBy21 =
                from num in numbers
                where num % 21 == 0
                select num;

            foreach (int number in divisibleBy21)
            {
                Console.WriteLine(number);
            }
        }

        public static void PrintDivisibleBy21Lambda(int[] numbers)
        {
            var divisibleBy21 = numbers.Where(x => x % 21 == 0);

            foreach (int number in divisibleBy21)
            {
                Console.WriteLine(number);
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[100];

            for (int i = 0; i < 100; i++)
            {
                numbers[i] = i;
            }

            PrintDivisibleBy21LINQ(numbers);
            Console.WriteLine();
            PrintDivisibleBy21Lambda(numbers);
        }
    }
}
