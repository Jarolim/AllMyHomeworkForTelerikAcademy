using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                        //Write a program that finds the sequence of maximal sum in given array. 
namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length N: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("enter array[{0}] : ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            int indexFirst = 0;
            int indexSecond = 0;
            int sum = 0;
            int maxSum = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i + j < length)
                    {
                        sum += arr[i + j];
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            indexFirst = i;
                            indexSecond = i + j;
                        }
                    }
                }
                sum = 0;
            }
            Console.Write("Max sum elements are: ");
            for (int i = indexFirst; i <= indexSecond; i++)
            {
                Console.Write("{0}; ", arr[i]);
            }
            Console.WriteLine("\nThe sum is: {0}", maxSum);
        }
    }
}

