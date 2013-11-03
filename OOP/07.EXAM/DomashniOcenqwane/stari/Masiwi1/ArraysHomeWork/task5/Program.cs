using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                    //Write a program that finds the maximal increasing sequence in an array. 
namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array lenght: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter array[{0}] : ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            int currIndex = 0;
            int tempSequence = 1;
            int maxSequence = 0;
            for (int i = 1; i <= array.Length - 1; i++)
            {
                if (array[i - 1] < array[i])
                {
                    tempSequence++;
                    if (tempSequence > maxSequence)
                    {
                        maxSequence = tempSequence;
                        currIndex = i;
                    }
                }
                else if (array[i - 1] >= array[i])
                {
                    tempSequence = 1;
                }
            }
            if (maxSequence == 0)
            {
                Console.WriteLine("there is no increasing sequence of numbers in the array");
            }
            else if (maxSequence > 0)
            {

                Console.Write("max increasing sequence:  ", maxSequence);
                Console.Write("{ ");
                for (int i = (currIndex - maxSequence) + 1; i <= currIndex; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine("}");
                Console.WriteLine();
            }
        }
    }
}
