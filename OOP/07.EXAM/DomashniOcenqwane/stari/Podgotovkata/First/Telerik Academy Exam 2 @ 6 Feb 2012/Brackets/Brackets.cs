using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger[,] DP = new BigInteger[input.Length + 1, input.Length + 2];
        DP[0, 0] = 1;

        for (int index = 1; index <= input.Length; index++)
        {
            if (input[index - 1] == '(')
            {
                DP[index, 0] = 0;
            }
            else
            {
                DP[index, 0] = DP[index - 1, 1];
            }

            for (int count = 1; count <= input.Length; count++)
            {
                if (input[index - 1] == '(')
                {
                    DP[index, count] = DP[index - 1, count - 1];
                }
                else if (input[index - 1] == ')')
                {
                    DP[index, count] = DP[index - 1, count + 1];
                }
                else
                {
                    DP[index, count] = DP[index - 1, count - 1] + DP[index - 1, count + 1];
                }
            }
        }
        Console.WriteLine(DP[input.Length, 0]);
    }
}
