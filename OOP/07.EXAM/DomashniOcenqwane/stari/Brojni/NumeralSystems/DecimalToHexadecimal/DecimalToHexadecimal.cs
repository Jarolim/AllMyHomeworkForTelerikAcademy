using System;

class DecimalToHexadecimal
{
    public static void Main()
    {
        string hex = Console.ReadLine();
        int number = 0;
        int i = 0;
        while (i!=hex.Length)
        {
            switch (hex[i])
            {
                case 'A':
                    number += 10 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                case 'B':
                    number += 11 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                case 'C':
                    number += 12 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                case 'D':
                    number += 13 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                case 'E':
                    number += 14 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                case 'F':
                    number += 15 * (int)Math.Pow(16, hex.Length - i - 1);
                    break;
                default:
                    number += ((Convert.ToInt32(hex[i])-48) * (int)Math.Pow(16, hex.Length - i - 1));
                    break;
            }
            i++;
        }
        Console.WriteLine(number);
    }
}
