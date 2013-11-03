using System;

class MaxSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = Int32.MinValue;
        int maxSumStart = Int32.MinValue;
        int tempMaxSum = 0;

        for (int i = 0; i < n-k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                tempMaxSum += array[i + j];
            }
            if (tempMaxSum > maxSum)
            {
                maxSum = tempMaxSum;
                maxSumStart = i;
            }
            tempMaxSum = 0;
        }

        for (int i = 0; i < k; i++)
        {
            Console.Write("{0} ", array[maxSumStart + i]);
        }

    }
}
