// 07. Write a program to convert from any numeral system of given
// base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

public class ConvertFromAnyNumeralSystemToAnyOther
{
    public static void DecimalToOtherBase(int decimalNumber, byte inputD)
    {
        // int decimalNumber = 3358;//4567894621        
        int tempNumber = decimalNumber;
        int[] hexDigit = new int[24]; // big enough to hold Int32.MaxValue
        int index = hexDigit.Length - 1;
        int reminder;
        do
        {
            reminder = tempNumber % inputD;
            tempNumber = tempNumber / inputD;

            hexDigit[index] = reminder;
            index--;
            if (tempNumber == 0)
            {
                continue;
            }

        } while (tempNumber > 0);

        Console.Write("Base D representation of {0} is: ", decimalNumber);
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
    
    public static int ConvertToDecimalBase(string inputN, byte inputS)
    {
        int[] binNumberArray = new int[inputN.Length];
        int index = inputN.Length - 1;

        // convert string in a new int[] array and reverse order  
        for (int i = 0; i < inputN.Length; i++)
        {
            binNumberArray[i] = Convert.ToInt32(inputN[index]) - 48;

            // Console.Write(" " + binNumberArray[i]);
            index--;
        }
            
        int decimalNumber = 0;
        for (int i = 0; i < inputN.Length; i++)
        {
            decimalNumber += binNumberArray[i] * (int)Math.Pow(inputS, i);
        }

        // Console.WriteLine("Decimal number is {0}",decimalNumber);
        return decimalNumber;
    }
    
    public static void Main()
    { 
        // int inputS = 4;
        bool parseSuccess;
        byte inputS;
        do
        {
            Console.WriteLine("Enter the base S of numeral system for given number, ");
            Console.Write("and S >= 2: ");
            string strA = Console.ReadLine();
            parseSuccess = byte.TryParse(strA, out inputS);
        } while ((inputS < 2) || (inputS > 16) || (!parseSuccess));
        
        // int inputN = 25;//       
        Console.Write("Enter the number: ");
        string inputN = Console.ReadLine();

        // int inputD = 4;//456789 
        parseSuccess = false;
        byte inputD;
        do
        {
            Console.WriteLine("Enter a positive decimal number for hexadecimal conversion, ");
            Console.Write("and D <= 16: ");
            string strA = Console.ReadLine();
            parseSuccess = byte.TryParse(strA, out inputD);
        } while ((inputD <= 2) || (inputD > 16) || (!parseSuccess));
        
        // 1.Convert from any numeral system of base S to decimal 
        int decimalN = ConvertToDecimalBase(inputN, inputS);
        Console.WriteLine("Decimal number is {0}", decimalN); // so far so good

        // 2.convert from decimal numeral system to other numeral system of base D
        DecimalToOtherBase(decimalN, inputD);
    }
}