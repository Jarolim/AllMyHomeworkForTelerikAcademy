using System;

class BinaryToDecimal
{
    public static void Main()
    {
        string bin = Console.ReadLine();
        char[] binary = bin.ToCharArray();
        int number = 0;
        for (int i = 0; i < bin.Length; i++)
        {
            number += (int)Math.Pow(2, bin.Length - i - 1)*(Convert.ToInt32(binary[i])-48);
        }
        Console.WriteLine(number);
    }
}
