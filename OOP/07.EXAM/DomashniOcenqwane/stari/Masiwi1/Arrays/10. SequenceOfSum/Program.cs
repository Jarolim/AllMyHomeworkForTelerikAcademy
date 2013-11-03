using System;

class SequenceOfSum
{
    static void Main()
    {
        int[] a = { 4, 3, 1, 4, 2, 5, 8 };
        int s = Int32.Parse(Console.ReadLine());
        bool IsSum = false;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i, sum = 0; j < a.Length; j++)
            {
                if ((sum += a[j]) == s)
                {
                    IsSum = true;
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write("{0} ", a[k]);
                    }
                    Console.WriteLine();
                }
            }
        }

        if (IsSum == false)
        {
            Console.WriteLine("There is no such sum !");
        }
    }
}
