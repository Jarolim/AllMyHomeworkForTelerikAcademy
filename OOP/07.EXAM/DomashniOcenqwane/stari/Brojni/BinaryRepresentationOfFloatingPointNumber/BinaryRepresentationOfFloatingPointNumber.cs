// 08. * Write a program that shows the internal binary representation of given
// 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
// Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
   
// work fine - no buggs found during the tests

using System;
using System.Globalization;
using System.Threading;

public class BinaryRepresentationOfFloatingPointNumber
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter the 32-bit signed floating-point number: ");
        decimal inputNumber = decimal.Parse(Console.ReadLine());

        // decimal inputNumber = -27.25M; // 0.1015625M; //-27,25M;//-1313.3125M;
        int sign = 0;
        if (inputNumber < 0)
        {
            sign = 1;
        }

        inputNumber = Math.Abs(inputNumber); // will work only with positive numbers
        int integralPart = (int)inputNumber;
        decimal fractionalPart = inputNumber - integralPart;
        
        // A.1. convert integral part in bin format        
        int tempNumber = (int)inputNumber;

        int[] binIntegralPartOfDigit = new int[32];
        int index = binIntegralPartOfDigit.Length - 1;
        int intReminder;
        do
        {
            intReminder = tempNumber % 2;
            tempNumber = tempNumber / 2;
            binIntegralPartOfDigit[index] = intReminder;
            index--;
            if (tempNumber == 0)
            {
                continue;
            }
        } while (tempNumber > 0);

        // A.2. convert fractional part in bin format
        decimal tempFractionalPart = fractionalPart;
        int[] binFractionalPartOfDigit = new int[7]; // not more than 23-bits for Significand
        decimal fractProduct = 0;
        int fractIndex = 0;

        do
        {
            if (fractIndex > binFractionalPartOfDigit.Length - 1)
            {
                continue;
            }

            fractProduct = tempFractionalPart * 2;
            if (fractProduct < 1)
            {
                binFractionalPartOfDigit[fractIndex] = 0;
            }
            else
            {
                binFractionalPartOfDigit[fractIndex] = 1;
                fractProduct = fractProduct - 1.0M;
                if (fractProduct == 0)
                {
                    break;
                }                
            }

            fractIndex++;
            tempFractionalPart = fractProduct;

        } while (fractProduct != 1.0M);

        Console.WriteLine();

        // B. and C. Normalize the number        
        int indexOfMantissa = 0;
        int sizeOfMantissaArray = 23;
        int[] mantissa = new int[sizeOfMantissaArray]; // max size could not be more than 23 
        int exponent = 0;

        // Only for numbers like 0.123456
        if (integralPart == 0)
        {
            // B. Normalize: 0.0001101b = 1.101b × 2^-4.
            Console.WriteLine("Integral Part == 0");
            int tempIndex = 0;
            
            do
            {
                if (binFractionalPartOfDigit[tempIndex] > 0)
                {
                    indexOfMantissa = tempIndex + 1;
                    exponent = 127 - indexOfMantissa;

                    // D.1 Place the mantissa into the mantissa field of the number
                    // Doing it by binFractionalPartOfDigit
                    for (int s = 1; indexOfMantissa < binFractionalPartOfDigit.Length; indexOfMantissa++) 
                    {
                        mantissa[s] = binFractionalPartOfDigit[indexOfMantissa];
                        s++;
                    }

                    break;
                }
                else
                {
                    tempIndex++;
                }
            } while (tempIndex < binFractionalPartOfDigit.Length);
        }
        else
        {
            // D.1 Place the mantissa into the mantissa field of the number
            // Doing it by binFractionalPartOfDigit
            for (int j = 0; j < binIntegralPartOfDigit.Length; j++) 
            {
                // skip all elements == 0 - they haven't usefull information
                if (binIntegralPartOfDigit[j] > 0)
                {
                    for (int k = j; k < binIntegralPartOfDigit.Length; k++)
                    {
                        mantissa[indexOfMantissa] = binIntegralPartOfDigit[k];
                        indexOfMantissa++;
                    }

                    break;
                }
            }
            
            // indexOfMantissa shows 2 things        
            // 1. finde out what is EXPONENT actually == (indexOfMantissa-1) + 127 in binary format
            // 2. where have to put next element from binFractionalPartOfDigit 
            exponent = indexOfMantissa + 126;

            for (int s = 0; s < binFractionalPartOfDigit.Length; s++) 
            {
                mantissa[indexOfMantissa] = binFractionalPartOfDigit[s];
                indexOfMantissa++;
            }

            // fills the rest of mantissa with 0000s
            for (int q = indexOfMantissa; q < mantissa.Length; q++)
            {
                mantissa[q] = 0;
            }
        }

        // Example: -1313.3125 -> sign = 1, exponent = 10001001, mantissa = 01001000010101000000000.
        // Example: 0.1015625 -> sign = 0, exponent = 01111011, mantissa = 10100000000000000000000.        
        // Console.WriteLine("exponent = {0}", exponent);
        string binExponent = Convert.ToString(exponent, 2).PadLeft(8, '0');

        Console.Write("sign = {0}, ", sign);
        Console.Write("exponent = {0}, ", binExponent);
        Console.Write("mantissa = ");
        for (int z = 1; z < mantissa.Length; z++) 
        {
            // z = 1 not 0 because D.2 (Omit the leading one)
            Console.Write(mantissa[z]);
        }

        // last step adding one zero in the end of mantissa -> regarding D.2
        Console.Write(0);
        Console.WriteLine("\n");      
    }
}

////The rules for converting a decimal number into floating point are as follows:

////A. Convert the absolute value of the number to binary, perhaps with a fractional part after the binary point. This can be done
////    by converting the integral and fractional parts separately. 
////A.1.The integral part is converted with the techniques examined previously. 
////A.2.The fractional part can be converted by multiplication. This is basically the inverse of the division method: 
////    we repeatedly multiply by 2, and harvest each one bit as it appears left of the decimal.
////B. Append × 2^0 to the end of the binary number (which does not change its value).
////C. Normalize the number. Move the binary point so that it is one bit from the left. Adjust the exponent of two so that the value does not change.
////D.1 Place the mantissa into the mantissa field of the number. D.2 Omit the leading one, and fill with zeros on the right.
////E. Add the bias to the exponent of two, and place it in the exponent field. The bias is 2^(k−1) − 1, where k is the number of bits in the exponent 
////    field. For the eight-bit format, k = 3, so the bias is 23−1 − 1 = 3. For IEEE 32-bit, k = 8, so the bias is 28−1 − 1 = 127.
////F. Set the sign bit, 1 for negative, 0 for positive, according to the sign of the original number. 
////------------------------------------------------------
////Example: Convert -1313.3125 to IEEE 32-bit floating point format.

//// a. The integral part is 1313 = 10100100001b. 
////    The fractional is:
////    0.3125      × 2 = 	0.625 	0 	Generate 0 and continue.
////    0.625    	× 2 = 	1.25 	1 	Generate 1 and continue with the rest.
////    0.25 	    × 2 = 	0.5 	0 	Generate 0 and continue.
////    0.5 	    × 2 = 	1.0 	1 	Generate 1 and nothing remains.
////    So 1313.3125 = 10100100001.0101b.
//// b. Normalize:     10100100001.0101b = 1.01001000010101b × 2^10.
//// c. Mantissa is     01001000010101000000000, exponent is 10 + 127 = 137 = 10001001b, sign bit is 1.
 
////So -1313.3125 is  |1|10001001|01001000010101000000000 = 0xc4a42a00