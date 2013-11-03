using System;

// Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

namespace Task04ArraysMaxSeqOfEqual
{
    class Task04ArraysMaxSeqOfEqual
    {
        static void Main()
        {
            // Building the array
            Console.WriteLine("Please enter length for an array: ");
            int arrayLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Now enter the elements of that array.");
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            // examine the array

            int firstEqual;
            int equalsLength;
            int betterFirstEqual = 0;
            int biggerEqualsLength = 0;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                int j = i;
                firstEqual = array[j];
                equalsLength = 1;
                while (j < (arrayLength - 1) && array[j] == array[j + 1])
                {
                    equalsLength++;
                    j++;
                }
                if (equalsLength > biggerEqualsLength)
                {
                    biggerEqualsLength = equalsLength;
                    betterFirstEqual = firstEqual;
                }

            }

            Console.WriteLine("The maximal sequence of equal elements is: ");
            for (int i = 0; i < biggerEqualsLength; i++)
                Console.Write(betterFirstEqual + ", ");
        }

    }

}
