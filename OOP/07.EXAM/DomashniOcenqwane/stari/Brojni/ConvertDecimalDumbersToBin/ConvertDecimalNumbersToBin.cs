// 01. Write a program to convert decimal numbers to their binary representation.

using System;
using System.Text;

public class ConvertDecimalNumbersToBin
{
    public static void Main()
    {        
        bool parseSuccess;
        int inputNumber; 
        do
        {
            Console.Write("Enter a positive decimal number for binary conversion: ");
            string strA = Console.ReadLine();
            parseSuccess = int.TryParse(strA, out inputNumber);
        }
        while ((inputNumber <= 0) || (!parseSuccess));

        // int inputNumber = 148;
        int tempNumber = inputNumber;

        int[] binDigit = new int[32];
        int index = binDigit.Length - 1;
        int reminder; 
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

        Console.WriteLine("32-bit binary representation of {0} is: \n", inputNumber);
        for (int i = 0; i < 32; i++)
        {
            Console.Write(binDigit[i]);
        }

        Console.WriteLine("\n");        
    }
}