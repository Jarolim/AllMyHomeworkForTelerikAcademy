using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = 0;
        int maxSumStart = 0;
        int maxSumEnd = 0;

        for (int i = 0; i < n; i++)
        {
            maxSum += a[i];
            maxSumEnd = i;

            if (maxSum <= 0)
            {
                maxSum = 0;
                maxSumStart = i + 1;
            }
        }

        if (maxSumStart == n)
        {
            Console.WriteLine(a.Max());
        }
        else
        {
            for (int i = maxSumStart; i <= maxSumEnd; i++)
            {
                Console.Write("{0} ", a[i]);
            }
        }
    }
}
