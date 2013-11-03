using System;
using System.Linq;
using BiggestElementsInArray;

namespace IndexOfFirstBiggerElement
{
    class IndexOfFirstBiggerElement
    {
        static void Main(string[] args)
        {
            int[] numbers = {4,4,5,5,5,4,5,3};
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (BiggestElementInArray.CheckElementInArray(i, numbers) == true)
                {
                    Console.WriteLine("Array index[{0}] = {1}", i, numbers[i]);
                    break;
                }
                count++;
            }
            if (count==numbers.Length)
            {
                Console.WriteLine(-1);
            }
        }
    }
}
