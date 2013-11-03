using System;

class CompareCharArrays
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] firstArray = input.ToCharArray(); 
        int firstArrayLength = firstArray.Length; 

        input = Console.ReadLine();
        char[] secondArray = input.ToCharArray();
        int secondArrayLength = secondArray.Length;

        int minLen = Math.Min(secondArrayLength, firstArrayLength);

        bool equal = true; 

        for (int i = 0; i < minLen; i++)
        {
            if (firstArray[i] != secondArray[i])
            {           
                equal = false;
                if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine("The first array is lexicografically before the second.");
                }
                else
                {
                    Console.WriteLine("The second array is lexicografically before the first.");
                }
                break;
            }
        }
        if (equal == true)
        {
            if (firstArrayLength < secondArrayLength)
            {
                Console.WriteLine("The first array is lexicografically before the second.");
            }
            else if (firstArrayLength > secondArrayLength)
            {
                Console.WriteLine("The second char array is lexicografically before the first.");
            }
            else
            {
                Console.WriteLine("The arrays are equal.");
            }
        }
        
    }
}