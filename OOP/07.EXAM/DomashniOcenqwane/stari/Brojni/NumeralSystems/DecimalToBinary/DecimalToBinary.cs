using System;
using System.Collections.Generic;

class DecimalToBinary
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        List<int> bin = new List<int>();
        while (number > 0)
        {
            bin.Add(number % 2);
            number = number / 2;
        }
        bin.Reverse();
        for (int i = 0; i < bin.Count; i++)
        {
            Console.Write("{0} ", bin[i]);
        }
        Console.WriteLine();
    }
}
