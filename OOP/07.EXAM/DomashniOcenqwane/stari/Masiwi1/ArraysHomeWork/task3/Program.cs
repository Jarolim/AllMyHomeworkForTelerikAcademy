using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    //Write a program that compares two char arrays lexicographically (letter by letter).

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Type the legth of the first array: ");
            int size1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the legth of the second array: ");
            int size2 = int.Parse(Console.ReadLine());
            char[] firstArray = new char[size1];
            char[] secondArray = new char[size2];
            int lengthFirst = firstArray.Length;
            int lengthSecond = secondArray.Length;
            int count = 0;

            for (int index = 0; index < lengthFirst; index++)
            {
                Console.WriteLine("Type the {0} index of the first array:", index);
                firstArray[index] = char.Parse(Console.ReadLine());
            }
            for (int index = 0; index < lengthSecond; index++)
            {
                Console.WriteLine("Type the {0} index of the second array:", index);
                secondArray[index] = char.Parse(Console.ReadLine());
            }
            if (size1 != size2)
            {
                if (size1 > size2)
                {
                    Console.WriteLine("The second string is lexicographically FIRST because its shorter");
                }
                else if (size1 < size2)
                {
                    Console.WriteLine("The first string is lexicographically FIRST because its shorter");
                }
            }
            else if (size1 == size2)
            {
                for (int index = 0; index < size1; index++)
                {
                    if (firstArray[index] == secondArray[index])
                    {
                        count += 1;
                    }
                }
                if (count == size1)
                {
                    Console.WriteLine("strings are equal");
                }
                else if (count != size1)
                {
                    for (int index = 0; index < size1; index++)
                    {
                        if (firstArray[index] > secondArray[index])
                        {
                            Console.WriteLine("The strings are equal by length but the second is first because its characters");
                        }
                        else if (firstArray[index] < secondArray[index])
                        {
                            Console.WriteLine("The strings are equal by length but the first is lexicographically before the second because of its characters");
                        }
                    }
                }
            }
        }
    }
}
