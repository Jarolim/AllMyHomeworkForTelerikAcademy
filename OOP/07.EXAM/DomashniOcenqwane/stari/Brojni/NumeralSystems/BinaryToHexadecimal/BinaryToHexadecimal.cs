using System;

class BinaryToHexadecimal
{
    public static void Main()
    {
        string bin = Console.ReadLine();
        string hexadec = "";
        int i = 0;
        while (i != bin.Length)
        {
            switch (bin.Substring(i, 4))
            {
                case "0000":
                    hexadec += "0";
                    break;
                case "0001":
                    hexadec += "1";
                    break;
                case "0010":
                    hexadec += "2";
                    break;
                case "0011":
                    hexadec += "3";
                    break;
                case "0100":
                    hexadec += "4";
                    break;
                case "0101":
                    hexadec += "5";
                    break;
                case "0110":
                    hexadec += "6";
                    break;
                case "0111":
                    hexadec += "7";
                    break;
                case "1000":
                    hexadec += "8";
                    break;
                case "1001":
                    hexadec += "9";
                    break;
                case "1010":
                    hexadec += "A";
                    break;
                case "1011":
                    hexadec += "B";
                    break;
                case "1100":
                    hexadec += "C";
                    break;
                case "1101":
                    hexadec += "D";
                    break;
                case "1110":
                    hexadec += "E";
                    break;
                case "1111":
                    hexadec += "F";
                    break;
                default:
                    hexadec += "";
                    break;
            }
            i += 4;
        }
        Console.WriteLine(hexadec);
    }
}
