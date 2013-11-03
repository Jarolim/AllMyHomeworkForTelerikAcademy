using System;

// Write a program that compares two char arrays lexicographically (letter by letter).

namespace Task03ArraysCompateTwoCharArrays
{
    class Task03ArraysCompateTwoCharArrays
    {
        static void Main()
        {

            // building array one
            Console.Write("Enter the length of char array one:");    
            int arrayOneLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Now enter {0} characters.", arrayOneLength);
            char[] arrayOne = new char[arrayOneLength];
            for (int i = 0; i < arrayOneLength; i++)
            {
                Console.Write("Character number {0}: ", i+1);
                arrayOne[i] = char.Parse(Console.ReadLine());
            }

            // building array two
            Console.Write("Enter the length of second char array:");    
            int arrayTwoLength = int.Parse(Console.ReadLine());
            Console.WriteLine("And now it's characters.");
            char[] arrayTwo = new char[arrayTwoLength];
            for (int i = 0; i < arrayTwoLength; i++)
            {
                Console.Write("Second array, char {0}: ", i+1);
                arrayTwo[i] = char.Parse(Console.ReadLine());
            }


            // comparing the arrays
            bool arrEqual = true;
            bool elEqual;

            if (arrayOneLength == arrayTwoLength)
            {
                for (int i = 0; i < arrayOneLength; i++)
                {
                    if (arrayOne[i] == arrayTwo[i])
                    {
                        elEqual = true;
                    }
                    else
                    {
                        elEqual = false;
                        arrEqual = false;
                    }

                    if (elEqual == true)
                    {
                        Console.WriteLine("Element {0} and {1} are equal", arrayOne[i], arrayTwo[i]);
                    }
                    else
                    {
                        Console.WriteLine("Element {0} and {1} are not equal.", arrayOne[i], arrayTwo[i]);
                    }
                }

                if (arrEqual == false)
                {
                    Console.WriteLine("Arrays are not equal.");
                }
                else
                {
                    Console.WriteLine("Arrays are equal.");
                }
            }
            else
            {
                Console.WriteLine("Arrays are not equal.");
            }
        }
    }
}
