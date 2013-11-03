using System;
using System.Collections.Generic;

class QuickSort
{
    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];
 
        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }
 
            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }
 
            if (i <= j)
            {
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;
 
                i++;
                j--;
            }
        }
 
        if (left < j)
        {
            Quicksort(elements, left, j);
        }
 
        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
 

    static void Main()
    {
        string[] arr = { "zgrsae", "efqfea", "xahdf", "cnj;a", "mbjae", "qafea", "adeqef", "asgrsv" };

        Quicksort(arr, 0, arr.Length - 1);

        foreach (string item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
