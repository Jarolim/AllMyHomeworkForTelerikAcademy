using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                       //Write a program that finds in given array of integers a sequence of given sum S (if present).                      
namespace task10
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
            Console.Write("Write the sum you want to search for S: ");
            int s= int.Parse(Console.ReadLine());
            bool foundSum = false;
            int indexFirst = 0;
            int indexSecond = 0;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i + j < length)
                    {
                        sum += arr[i + j];
                        if (sum == s)
                        {
                            foundSum = true; 
                            indexFirst = i;
                            indexSecond = i + j;
                        }
                    }
                }
                sum = 0;
            }
            if (foundSum==true)
            {
                Console.Write("There is sum={0} of these numbers : ",s);
                for (int i = indexFirst; i <=indexSecond; i++)
                {
                    Console.Write(arr[i]+" ");
                }
                Console.WriteLine();
            }
            else if (foundSum==false)
            {
                Console.WriteLine("there is no such sum in the array");
            }
        }
    }
}
