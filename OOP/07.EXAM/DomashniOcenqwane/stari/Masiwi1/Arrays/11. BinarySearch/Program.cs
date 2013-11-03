using System;

class BinarySearch
{
    static void Main()
    {
        int[] sortedArr = { 3, 3, 3, 4, 5, 6, 12, 34, 56, 65, 73 };
        int target = Int32.Parse(Console.ReadLine());

        int first = 0, mid, last = sortedArr.Length - 1;

        while (first <= last)
        {
            mid = (first + last) / 2;
            if (target < sortedArr[mid])
            {
                last = mid - 1;
            }
            else if (target > sortedArr[mid])
            {
                first = mid + 1;
            }
            else
            {
                Console.WriteLine("Target {0} was found at index {1}", target, mid);
                break;
            }
        }

    }
}
