using System;

class HexadecimalToDecimal
{
    public static void Main()
    {
        int dec = int.Parse(Console.ReadLine());
        string hex = "";
        while (dec > 0)
        {
            switch (dec % 16)
            {
                case 10:
                    hex += "A";
                    break;
                case 11:
                    hex += "B";
                    break;
                case 12:
                    hex += "C";
                    break;
                case 13:
                    hex += "D";
                    break;
                case 14:
                    hex += "E";
                    break;
                case 15:
                    hex += "F";
                    break;
                default:
                    hex += (dec % 16).ToString();
                    break;
            }
            dec = dec / 16;
        }
        for (int i = hex.Length - 1; i > -1; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }
}
