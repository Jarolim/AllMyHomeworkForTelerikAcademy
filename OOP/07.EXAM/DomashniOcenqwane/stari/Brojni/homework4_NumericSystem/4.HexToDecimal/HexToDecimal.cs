using System;

class HexToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a Hex number: ");
        char[] hex = (Console.ReadLine()).ToCharArray();
        Array.Reverse(hex);
        int dec = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            string st = hex[i].ToString();
            switch (st)
            {
                case "A": st = "10"; break;
                case "B": st = "11"; break;
                case "C": st = "12"; break;
                case "D": st = "13"; break;
                case "E": st = "14"; break;
                case "F": st = "15"; break;
            }
            int number = int.Parse(st) * (int)(Math.Pow(16, i));
            dec = dec + number;
        }
        Console.WriteLine("Decimal representation " + dec);
    }
}

