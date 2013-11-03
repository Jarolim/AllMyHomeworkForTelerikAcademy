using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MessageInABottle
{

    static void Main()
    {
        string code = Console.ReadLine();
        int numberLenght = code.Length;
        string combination = Console.ReadLine();
        int maxNumber = 1 << (numberLenght - 1);
        Hashtable table = new Hashtable();
        int resultsFound = 0;
        List<string> finalResult = new List<string>();

        {
            char currentChar = ' ';
            int startIndex = 0;
            int lenght = 0;
            bool numberFound = false;

            for (int index = 0; index < combination.Length; index++)
            {
                if (!Char.IsDigit(combination[index]))
                {
                    if (numberFound)
                    {
                        table[combination.Substring(startIndex, lenght)] = currentChar;
                        numberFound = false;
                    }
                    currentChar = combination[index];
                    numberFound = true;
                    startIndex = index + 1;
                    lenght = 0;
                }
                else
                {
                    lenght++;
                }
            }
            table[combination.Substring(startIndex, lenght)] = currentChar;
        }


        for (int currentCombination = 0; currentCombination < maxNumber; currentCombination++)
        {
            int[] result = ReturnCombinations(Convert.ToString(currentCombination, 2).PadLeft(numberLenght, '0'));

            StringBuilder sb = new StringBuilder();

            int index = 0;
            int startIndex = 0;
            bool resultFound = true;

            while (result[index] > 0)
            {
                if (table[code.Substring(startIndex, result[index])] != null)
                {
                    sb.Append(table[code.Substring(startIndex, result[index])]);
                }
                else
                {
                    resultFound = false;
                    break;
                }

                startIndex += result[index];
                index++;
            }
            if (resultFound)
            {
                resultsFound++;
                finalResult.Add(sb.ToString());
            }
        }


        Console.WriteLine(resultsFound);

        finalResult.Sort();
        foreach (string item in finalResult)
        {
            Console.WriteLine(item);
        }

    }

    static int[] ReturnCombinations(string number)
    {
        int[] result = new int[number.Length + 1];
        int numberIndex = 0;
        int lenght = 1;
        char currentDigit = number[0];

        for (int index = 1; index < number.Length; index++)
        {
            if (currentDigit == number[index])
            {
                lenght++;
            }
            else
            {
                currentDigit = number[index];
                result[numberIndex++] = lenght;
                lenght = 1;
            }
        }
        result[numberIndex++] = lenght;
        result[numberIndex] = -1;
        return result;
    }
}
