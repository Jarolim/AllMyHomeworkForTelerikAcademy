using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                            //Write a program that finds the index of given element in a 
                                            //sorted array of integers by using the binary search algorithm 
namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write ("Enter array length :");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("enter array[{0}] : ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter the number you want to search for: ");
            int k = int.Parse(Console.ReadLine());
            Array.Sort(arr);
            int min = 0;
            int max = length - 1;
            int mid;
            if (min > max)
            {
                Console.WriteLine("there is no array length");

            }

            while (max >= min)
            {
                mid = (min + max) / 2;
                if (k > arr[mid])
                {
                    min = mid + 1;
                    mid = mid = (min + max) / 2;

                }
                else if (k < arr[mid])
                {
                    max = mid - 1;
                    mid = (min + max) / 2;
                }
                else if (k == arr[mid])
                {
                    Console.WriteLine("The number {0} is at array index : {1}", k, mid);
                    for (int i = 0; i < length; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }
                    break;
                }

            }

        }
    }
}
