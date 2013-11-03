// 02. Write a program to convert binary numbers to their decimal representation.

using System;

public class ConvertBinaryNumbersToDecimal
{
    public static void Main()
    {
        Console.Write("Enter a binary number as a string: ");
        string binNumber = Console.ReadLine();

        int[] binNumberArray = new int[binNumber.Length];
        int index = binNumber.Length - 1;

        // convert string in a new int[] array and reverse order  
        for (int i = 0; i < binNumber.Length; i++)
        {
            binNumberArray[i] = Convert.ToInt32(binNumber[index]) - 48;

            // Console.Write(" " + binNumberArray[i]);
            index--;
        }
        
        int decimalNumber = 0;
        for (int i = 0; i < binNumber.Length; i++)
        {
            decimalNumber += binNumberArray[i] * (int)Math.Pow(2, i);
        }

        Console.WriteLine("Decimal number is {0}", decimalNumber);
    }
}