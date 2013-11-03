using System;

class MaxSequenceEqual
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSeqLength = 1;
        int maxSeqStart = 0;
        int tempLength = 1;
        int tempStart = 0;

        for (int i = 1; i < n; i++)
        {
            if (array[i] == array[i - 1])
            {
                tempLength++;
                if (tempLength > maxSeqLength)
                {
                    maxSeqLength = tempLength;
                    maxSeqStart = tempStart;
                }
            }
            else
            {
                tempLength = 1;
                tempStart = i;
            }
        }

        for (int i = 0; i < maxSeqLength; i++)
        {
            Console.Write("{0} ", array[maxSeqStart + i]);
        }

        Console.WriteLine();
    }
}
