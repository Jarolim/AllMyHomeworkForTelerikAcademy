using System;

class HexToBinDirect
{
    static void Main()
    {
        string[] Convert = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111", };
        string bin = "";
        Console.WriteLine("Enter a Hex number: ");
        char[] hex = (Console.ReadLine()).ToCharArray();
        for (int i = 0; i < hex.Length; i++)
        {
            string curent = hex[i].ToString();
            switch (curent)
            {
                case "A": curent = "10"; break;
                case "B": curent = "11"; break;
                case "C": curent = "12"; break;
                case "D": curent = "13"; break;
                case "E": curent = "14"; break;
                case "F": curent = "15"; break;
            }
            int number = int.Parse(curent);
            bin = Convert[number] + bin;
        }
        Console.WriteLine("Decimal representation " + bin);
    }
}

