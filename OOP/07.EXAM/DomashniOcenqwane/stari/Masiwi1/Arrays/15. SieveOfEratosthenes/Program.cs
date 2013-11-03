using System;

class PrimeNumbers
{
    void SieveOfEratosthenes(bool[] a)
    {
        double n = Math.Sqrt(a.Length);
        for (int i = 2; i <= n; i++)
        {
            if (a[i] == true)
            {
                for (int j = 2 * i; j < a.Length; j += i)
                {
                    a[j] = false;
                }
            }
        }
    }

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        bool[] primes = new bool[n+1];

        for (int i = 2; i <= n; i++)
        {
            primes[i] = true;
        }

        PrimeNumbers prime = new PrimeNumbers();

        prime.SieveOfEratosthenes(primes);

        for (int i = 2; i <= n; i++)
        {
            if (primes[i] == true)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }
}
