using System;

class BinToHexDirect
{
    static void Main()
    
    {
    Console.WriteLine("Enter a binary number: ");
    char[] bin = (Console.ReadLine()).ToCharArray();
    string hex = "";

    for (int i = bin.Length-1; i >= 0; i -= 4)
        {
        string curent ="";
            if (i == 2){curent = "0" + bin[i - 2].ToString() + bin[i - 1].ToString() + bin[i].ToString();}
            else if (i == 1) { curent = "00" + bin[i - 1].ToString() + bin[i].ToString(); }
            else if (i == 0) { curent = "000" + bin[i].ToString(); }
            else
            {
                curent = bin[i - 3].ToString() + bin[i - 2].ToString() + bin[i - 1].ToString() + bin[i].ToString();
            }

            switch (curent)
            {
                case "0000": curent = "0"; break;
                case "0001": curent = "1"; break;
                case "0010": curent = "2"; break;
                case "0011": curent = "3"; break;
                case "0100": curent = "4"; break;
                case "0101": curent = "5"; break;
                case "0110": curent = "6"; break;
                case "0111": curent = "7"; break;
                case "1000": curent = "8"; break;
                case "1001": curent = "9"; break;
                case "1010": curent = "A"; break;
                case "1011": curent = "B"; break;
                case "1100": curent = "C"; break;
                case "1101": curent = "D"; break;
                case "1110": curent = "E"; break;
                case "1111": curent = "F"; break;
            }

            hex=curent + hex;
        }
    Console.WriteLine("Hex representation " + hex);
    }
}
