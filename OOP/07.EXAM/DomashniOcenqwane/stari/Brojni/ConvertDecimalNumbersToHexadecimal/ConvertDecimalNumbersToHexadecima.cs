// 03. Write a program to convert decimal numbers to their hexadecimal representation.

using System;

public class ConvertDecimalNumbersToHexadecimal
{
    public static void Main()
    {
        // int inputNumber = 3358;//4567894621
        // ------------------------------
        bool parseSuccess;
        int inputNumber;
        do
        {
            Console.Write("Enter a positive decimal number for hexadecimal conversion: ");
            string strA = Console.ReadLine();
            parseSuccess = int.TryParse(strA, out inputNumber);
        }
        while ((inputNumber <= 0) || (!parseSuccess));

        // --------------------------------
        int tempNumber = inputNumber;
        int[] hexDigit = new int[8]; // big enough to hold Int32.MaxValue
        int index = hexDigit.Length - 1;
        int reminder;
        do
        {
            reminder = tempNumber % 16;
            tempNumber = tempNumber / 16;
           
            hexDigit[index] = reminder;
            index--;
            if (tempNumber == 0)
            {
                continue;
            }

        } while (tempNumber > 0);

        Console.Write("Hexadecimal representation of {0} is: ", inputNumber);
        for (int i = 0; i < hexDigit.Length; i++)
        {
            // skip all elements == 0 - they haven't usefull information
            if (hexDigit[i] > 0)
            {
                for (int j = i; j < hexDigit.Length; j++)
                {
                    if (hexDigit[j] > 9)
                    {
                        hexDigit[j] = hexDigit[j] + 7;
                    }

                    Console.Write((char)(hexDigit[j] + 48));
                }

                break;
            }
        }

        Console.WriteLine("\n");     
    }
}