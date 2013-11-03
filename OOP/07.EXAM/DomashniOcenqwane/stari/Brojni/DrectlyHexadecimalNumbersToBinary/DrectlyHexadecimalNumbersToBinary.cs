// 04. Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

public class DrectlyHexadecimalNumbersToBinary
{
    public static void ConvertDecimalToBinary(int[] binDigit, int decNumber)
    {
        int tempNumber = decNumber;      
        int index = binDigit.Length - 1;
        int reminder;

        Array.Clear(binDigit, 0, binDigit.Length); // old value must be cleared        

        do
        {
            reminder = tempNumber % 2;
            tempNumber = tempNumber / 2;
            binDigit[index] = reminder;
            index--;
            if (tempNumber == 0)
            {
                continue;
            }

        } while (tempNumber > 0);
    }

    public static void Main()
    {
        Console.Write("Enter the hexadecimal number to convert in binary: ");
        string hexString = Console.ReadLine();

        // string hexString = "ab4";
        string tempString = hexString; // to be printed as was entered
        hexString = hexString.ToUpper();    

        // convert string in int
        int[] hexDigit = new int[hexString.Length];
        for (int m = 0; m < hexDigit.Length; m++)
        {
            if (hexString[m] > 64)
            {
                hexDigit[m] = hexString[m] - 55;
            }
            else
            {
                hexDigit[m] = hexString[m] - 48;   
            }            
        }

        int[] binDigit = new int[4];
        int[,] nibbles = new int[hexDigit.Length, 4];

        for (int i = 0; i < hexString.Length; i++)
        {        
            // convert each digit in bin format
            ConvertDecimalToBinary(binDigit, hexDigit[i]);
            
            // put bin format in nibbles
            for (int n = 0; n < binDigit.Length; n++)
            {
                nibbles[i, n] = binDigit[n];
            }
        }

        // print result in binary numbers        
        Console.WriteLine("Hexadecimal number \"{0}\" in binary format (directly) is:\n", tempString);
        Console.Write("0x{0} = ", hexString); // , tempString);  

        for (int q = 0; q < nibbles.GetLength(0); q++)
        {
            for (int p = 0; p < nibbles.GetLength(1); p++)
            {
                Console.Write(nibbles[q, p]);
            }

            Console.Write(" ");
        }

        Console.WriteLine();              
    }
}