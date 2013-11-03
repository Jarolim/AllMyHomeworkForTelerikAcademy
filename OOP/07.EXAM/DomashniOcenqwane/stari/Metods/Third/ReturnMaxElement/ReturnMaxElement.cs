using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnMaxElement
{
    class ReturnMaxElement
    {
        static int FindBiggestNumFromGivenIndex(int[] arr, int index)
        {
            int length = arr.Length;
            int biggest = 0;
            for (int i = index; i < length; i++)
            {
                if (arr[i] > biggest)
                {
                    biggest = arr[i];
                }
            }
            return biggest;
        }
        static int[] SortAscendingOrder(int[] arr)
        {
            Array.Sort(arr);
            return arr;
        }
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        static void PrintArrayReverse(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int[] arr = { 0, 2, 1, 3, 4, 5, 9, 7, 8, 6 };
            int index = 2;

            Console.WriteLine(FindBiggestNumFromGivenIndex(arr, index));
            PrintArray(SortAscendingOrder(arr));
            PrintArrayReverse(arr);
        }
    }
}
