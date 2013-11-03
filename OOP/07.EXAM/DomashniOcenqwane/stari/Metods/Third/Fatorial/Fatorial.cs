using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Fatorial
{
    class Fatorial
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(Factorial(i));
            }
        }

        private static BigInteger Factorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
