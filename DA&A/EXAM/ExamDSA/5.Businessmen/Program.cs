using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        
        int N = int.Parse(Console.ReadLine());

        int m = N / 2;

        BigInteger nTimes2Factorial = 1;
        for (int i = 1; i <= 2 * m; i++)
        {
            nTimes2Factorial *= i;
        }

        BigInteger nPlusOneFactorial = 1;
        for (int i = 1; i <= m + 1; i++)
        {
            nPlusOneFactorial *= i;
        }

        BigInteger nFactorial = 1;
        for (int i = 1; i <= m; i++)
        {
            nFactorial *= i;
        }

        Console.WriteLine(nTimes2Factorial / (nPlusOneFactorial * nFactorial));
    }
}

