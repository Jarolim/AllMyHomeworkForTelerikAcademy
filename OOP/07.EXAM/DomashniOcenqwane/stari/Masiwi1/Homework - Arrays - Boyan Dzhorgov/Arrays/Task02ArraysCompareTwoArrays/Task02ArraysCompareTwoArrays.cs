using System;

namespace Task02ArraysCompareTwoArrays
{
    class Task02ArraysCompareTwoArrays
    {
        static void Main()
        {
            Console.Write("Enter the length of array one:");    // building array one
            int arrayOneLength = int.Parse(Console.ReadLine());
            Console.WriteLine("And now it's members.");
            int[] arrayOne = new int[arrayOneLength];
            for (int i = 0; i < arrayOneLength; i++)
            {
                Console.Write("Array one member {0}: ", i);
                arrayOne[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the length of array two:");    // building array two
            int arrayTwoLength = int.Parse(Console.ReadLine());
            Console.WriteLine("And now it's members.");
            int[] arrayTwo = new int[arrayTwoLength];
            for (int i = 0; i < arrayTwoLength; i++)
            {
                Console.Write("Array two member {0}: ", i);
                arrayTwo[i] = int.Parse(Console.ReadLine());
            }

            // printing members of array one on the console
            for (int index = 0; index < arrayOne.Length; index++)   
            {
                Console.WriteLine("Array one element[{0}] = {1}", index, arrayOne[index]);
            }

            // printing members of array two on the console
            for (int index = 0; index < arrayTwo.Length; index++)
            {
                Console.WriteLine("Array two element[{0}] = {1}", index, arrayTwo[index]);
            }

            // comparing arrays
            if (arrayOneLength != arrayTwoLength)
            {
                Console.WriteLine("The arrays have different lengths.");
            }
            else
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] != arrayTwo[i])
                    {
                        Console.WriteLine("The arrays are not equal.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The arrays are equal");
                        break;
                    }
                }
            }
        }
    }
}
