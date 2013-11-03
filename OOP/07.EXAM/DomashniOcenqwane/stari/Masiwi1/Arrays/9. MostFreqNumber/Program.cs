using System;
using System.Collections.Generic;
using System.Linq;

class MostFreqNumber
{
    static void Main()
    {
        int[] a = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        Dictionary<int,int> frequency = new Dictionary<int,int>();

        for (int i = 0; i < a.Length; i++)
        {
            if (frequency.ContainsKey(a[i]))
            {
                frequency[a[i]] ++;
            }
            else
            {
                frequency.Add(a[i], 1);
            }
        }

        int bestFreq = 0;
        int bestElement = 0;

        foreach (var element in frequency)
        {
            if (element.Value > bestFreq)
            {
                bestFreq = element.Value;
                bestElement = element.Key;
            }
        }

        Console.WriteLine("{0}({1} times)", bestElement, bestFreq);
    }
}
