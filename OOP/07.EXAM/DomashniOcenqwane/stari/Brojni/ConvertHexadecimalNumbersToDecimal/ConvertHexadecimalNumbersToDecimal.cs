// 04. Write a program to convert hexadecimal numbers to their decimal representation.

using System;

public class ConvertHexadecimalNumbersToDecimal
{
    public static void Main()
    {
        Console.Write("Enter a hexadecimal number: ");
        string originalHexNumber = Console.ReadLine();

        // string OriginalHexNumber = "a3cd";//"d1e";// 
        string hexNumber = originalHexNumber.ToUpper();

        int[] decNumber = new int[16]; // can hold 64-bit number

        int result = 0;
        int indexHexNumber = hexNumber.Length - 1;
        int powerIndex = 0;

        do
        {
            int tempHexNumber = 0;
            
            if (hexNumber[indexHexNumber] > 64)
            {
                tempHexNumber = Convert.ToByte(hexNumber[indexHexNumber] - 55);
            }
            else
            {
                tempHexNumber = Convert.ToByte(hexNumber[indexHexNumber] - 48);
            }

            result += tempHexNumber * (int)Math.Pow(16.0, powerIndex);
            powerIndex++;
            indexHexNumber--;
        } while (indexHexNumber > -1);

        Console.WriteLine();
        Console.WriteLine("Hexadecimal 0x{0} = {1} as decimal.", hexNumber, result);
    }
}