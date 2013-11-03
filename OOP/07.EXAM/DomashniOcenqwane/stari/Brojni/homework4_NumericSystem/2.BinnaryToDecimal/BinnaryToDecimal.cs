using System;

class BinnaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a binary number: ");
        char[] bin = (Console.ReadLine()).ToCharArray();
        Array.Reverse(bin);
        int dec = 0;
        for (int i = 0; i < bin.Length; i++ )
        {
            string st = bin[i].ToString();
            int number = int.Parse( st )*(int)(Math.Pow(2, i));
            dec=dec + number;
        }
        Console.WriteLine("Decimal representation " + dec);
    }
}

