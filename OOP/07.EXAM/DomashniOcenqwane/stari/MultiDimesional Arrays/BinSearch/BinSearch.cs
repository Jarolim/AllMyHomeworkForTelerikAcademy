using System;

class BinSearch
{
    static void Main()
    {
        int[] arr = new int[] { 3, -3, 12, 3, 14, 6, 54, 23, 41, 24 };
        int k = 20;
        Array.Sort(arr);

        int index = Array.BinarySearch(arr, k);

        Console.WriteLine("K = {0}", k);

        while (true)
        {
            if (index < 0)
            {
                --k;
                index = Array.BinarySearch(arr, k);
            }
            else if (index <= k)
            {
                Console.WriteLine("the best element that is <=  is {0}", arr[index]); break;
            }
            else
            {
                Console.WriteLine("no such element"); break;
            }
        }
    }
}