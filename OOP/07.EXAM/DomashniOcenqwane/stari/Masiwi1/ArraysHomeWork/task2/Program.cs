using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    //Write a program that reads two arrays from 
    //the console and compares them element by element.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the length of the first array: ");
            int size1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the length of the second array: ");
            int size2 = int.Parse(Console.ReadLine());
            int count = 0;
            int[] firstArray = new int[size1];
            int[] secondArray = new int[size2];

            for (int index = 0; index < size1; index++)
            {
                Console.WriteLine("Type the {0} index of the first array:", index);
                firstArray[index] = int.Parse(Console.ReadLine());
            }
            for (int index = 0; index < size2; index++)
            {
                Console.WriteLine("Type the {0} index of the second array:", index);
                secondArray[index] = int.Parse(Console.ReadLine());
            }
            if (size1 != size2)
            {
                Console.WriteLine("the two strings are not equal");
            }
            else if (size1==size2)
            {
                for (int index = 0; index < size1; index++)
                {
                    if (firstArray[index]==secondArray[index])
                    {
                        count += 1;
                    }
                }
                if (count == size1)
                {
                    Console.WriteLine("strings are equal");
                }
                else
                {
                    Console.WriteLine("string are not equal");
                }
            }
        }
    }
}


