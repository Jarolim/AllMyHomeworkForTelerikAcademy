using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                //Write a program that finds the most frequent number in an array. 
namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 4, 1, 3, 2, 6, 1, 9, 1, 1 };
            int length = arr.Length;
            int tempCommon = 0;
            int maxCommon = 1;
            int number = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        tempCommon++;
                        if (tempCommon >= maxCommon)
                        {
                            maxCommon = tempCommon;
                            number = i;
                        }
                    }
                } tempCommon = 0;
            } Console.WriteLine("the number {0} is found {1} times in the array.", arr[number], maxCommon);
        }
    }
}
