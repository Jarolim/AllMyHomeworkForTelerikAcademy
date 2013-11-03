using System;
using System.Linq;

// Conclusions - 
// Sorting of reversed and random array is much faster then sorting of sorted array
// For array with 100 elements of integers selection sort is the fastest, quick sort is the slowest
// For array with 100 elements of doubles selection sort is the slowest
// For string quick sort is the fastest, then is insertion sort and selection sort is the slowest (in times)
// Sorting string is slower then sorting int or double
public class Sorting
{
    public static int[] GenerateRandomArray()
    {
        Random randomGenerator = new Random();
        int[] array = new int[100];
        for (int count = 0; count < 100; count++)
        {
            array[count] = randomGenerator.Next(count, 1000000);
        }

        return array;
    }

    static void Main()
    {
        SelectionSorting.SelectionSortArray();
        InsertionSorting.InsertionSortArray();
        QuickSorting.QuickSortArray();
    }
}