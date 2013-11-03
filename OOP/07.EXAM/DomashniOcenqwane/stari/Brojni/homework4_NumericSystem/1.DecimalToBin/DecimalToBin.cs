using System;

class DecimalToBin
{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number: ");
        int dec = int.Parse(Console.ReadLine());
        string bin = "";
        while (dec != 0)
        {
            bin =(dec % 2).ToString() + bin;
            dec = (dec / 2);
        }
        Console.WriteLine("Binary representation "+bin);
    }
}

