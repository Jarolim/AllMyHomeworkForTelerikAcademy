// 08. Write a program that shows the binary representation of 
// given 16-bit signed integer number (the C# type short).
   
//// Work fine with positiv and negative numbers using one's complement

using System;

public class BinaryRepresentationOfShortNumber
{
    public static void Main()
    {
        bool parseSuccess;
        short inputNumber;
        do
        {
            Console.Write("Enter a 16-bit signed integer number for binary conversion: ");
            string strA = Console.ReadLine();
            parseSuccess = short.TryParse(strA, out inputNumber);
        }
        while ((inputNumber > short.MaxValue) || (inputNumber < short.MinValue + 1) || (!parseSuccess));

        int tempNumber = Math.Abs(inputNumber);

        if (inputNumber < 0)
        {
            tempNumber--; // add "1" here for two's complement
        }                    

        int[] binDigit = new int[16];
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
        
        Console.WriteLine("16-bit binary representation of {0} is: \n", inputNumber);
        for (int i = 0; i < 16; i++)
        {
            // if inputNumber is negative then make ~ on each bit
            if (inputNumber < 0)
            {
                if (binDigit[i] > 0)
                {
                    binDigit[i] = 0; // 1 becomes 0
                }
                else
                {
                    binDigit[i] = 1; // 0 becomes 1
                }

                Console.Write(binDigit[i]);
            }
            else
            {
                Console.Write(binDigit[i]);
            }            
        }

        Console.WriteLine("\n");  
    }
}