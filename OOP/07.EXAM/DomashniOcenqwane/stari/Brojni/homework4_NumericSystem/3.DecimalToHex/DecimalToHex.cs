using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number: ");
        int dec = int.Parse(Console.ReadLine());
        string hex = "",
            reminder="";
        while (dec != 0)

        {
            reminder = (dec % 16).ToString();// +hex;
            switch (reminder)
            {
                case "10": reminder = "A"; break;
                case "11": reminder = "B"; break;
                case "12": reminder = "C"; break;
                case "13": reminder = "D"; break;
                case "14": reminder = "E"; break;
                case "15": reminder = "F"; break;
            }
            hex =reminder+hex;
            dec = (dec / 16);
        }
        Console.WriteLine("Hex representation " + hex);
    }
}

