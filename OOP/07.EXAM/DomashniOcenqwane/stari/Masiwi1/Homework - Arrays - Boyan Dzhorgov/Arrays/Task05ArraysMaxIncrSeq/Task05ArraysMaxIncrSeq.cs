using System;

//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

namespace Task05ArraysMaxIncrSeq
{
    class Task05ArraysMaxIncrSeq
    {
        static void Main()
        {
            Console.WriteLine("Please, enter an integer array to find the maximal increasing sequence in it.");
            // Building the array
            Console.Write("Please enter the length of the array: ");
            int arrayLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Now enter the elements.");
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            // examine the array

            int firstOfIncr = array[0];
            int incrSeqLength = 0;
            int newFirstOfIncr = 0;
            int biggerIncrSeq = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    incrSeqLength++;

                    if (incrSeqLength > biggerIncrSeq)
                    {
                        biggerIncrSeq = incrSeqLength;
                        newFirstOfIncr = firstOfIncr;
                    }
                }
                else
                {
                    incrSeqLength = 1;
                    firstOfIncr = i + 1;
                }
            }

            Console.Write("The maximal increasing sequence is ");
            for (int i = newFirstOfIncr; i < newFirstOfIncr + biggerIncrSeq; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }
    }
}
