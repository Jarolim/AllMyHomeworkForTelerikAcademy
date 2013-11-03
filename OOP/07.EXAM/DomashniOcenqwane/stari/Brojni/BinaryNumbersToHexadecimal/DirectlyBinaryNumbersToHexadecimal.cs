// 06. Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

public class BinaryNumbersToHexadecimal
{
    public static char DirectlyBinToHexNumbers(int[] binNumberArray)
    {
        int hexNumber = 0;
        char hexNumberChar;

        for (int i = 0; i < binNumberArray.Length; i++)
        {
            hexNumber += binNumberArray[i] * (int)Math.Pow(2, i);
        }
        
        if (hexNumber > 9)
        {
            hexNumber = hexNumber + 7;
        }

        hexNumberChar = (char)(hexNumber + 48);

        return hexNumberChar;
    }

    public static void Main()
    {
        Console.Write("Enter a binary number as a string: ");
        string binNumber = Console.ReadLine();
        //// string binNumber = "111011101";

        Console.WriteLine();

        // convert string in a new int[] array and reverse order
        int[] binNumberArray = new int[binNumber.Length];
        int index = binNumber.Length - 1;

        for (int i = 0; i < binNumber.Length; i++)
        {
            binNumberArray[i] = Convert.ToInt32(binNumber[index]) - 48;
            index--;
        }

        // separate string into nibbles
        int[] nibbleArray = new int[4];
        char[] hexNumber = new char[8];
        int indexHexNumberArray = 0;
        for (int k = 0, indexNibbleArray = 0; k < binNumberArray.Length; k++, indexHexNumberArray = k / 4)
        {
            char tempHexNumber;

            if (indexNibbleArray == 4) 
            {
                tempHexNumber = DirectlyBinToHexNumbers(nibbleArray);
                k--;
                indexNibbleArray = 0;
                Array.Clear(nibbleArray, 0, nibbleArray.Length);
            }
            else
            {
                nibbleArray[indexNibbleArray] = binNumberArray[k];
                indexNibbleArray++;

                if ((k - binNumberArray.Length < 4) && (k - binNumberArray.Length >= -1))
                {
                    // indexNibbleArray = 0;
                    // nibbleArray[indexNibbleArray] = binNumberArray[k];
                    while (k < binNumberArray.Length - 1)
                    {
                        indexNibbleArray++;
                        k++;
                        nibbleArray[indexNibbleArray] = binNumberArray[k];
                    }

                    tempHexNumber = DirectlyBinToHexNumbers(nibbleArray);
                    hexNumber[indexHexNumberArray] = tempHexNumber;
                    continue;
                }

                continue;
            }

            hexNumber[indexHexNumberArray - 1] = tempHexNumber;
        }

        // print hex digit
        Console.Write("Binary number {0} as hexadecimal number is = ", binNumber);
        for (int z = indexHexNumberArray; z >= 0; z--)
        {
            Console.Write(hexNumber[z]);
        }

        Console.WriteLine("\n");
    }
}