using System;
using System.Linq;

// Sort array of 100 random values
public class QuickSorting
{
    private static T[] QuickSort<T>(T[] array, int down, int up) where T : IComparable
    {
        int downLimit = down;
        int upperLimit = up;
        T pivot = array[(down + up) / 2];
        while (downLimit <= upperLimit)
        {
            while (array[downLimit].CompareTo(pivot) < 0)
            {
                downLimit++;
            }

            while (array[upperLimit].CompareTo(pivot) > 0)
            {
                upperLimit--;
            }

            if (downLimit <= upperLimit)
            {
                T exchangeValue = array[downLimit];
                array[downLimit] = array[upperLimit];
                array[upperLimit] = exchangeValue;
                downLimit++;
                upperLimit--;
            }
        }

        if (down < upperLimit)
        {
            QuickSort(array, down, upperLimit);
        }

        if (downLimit < up)
        {
            QuickSort(array, downLimit, up);
        }

        return array;
    }

    public static void QuickSortArray()
    {
        Console.WriteLine("Quick sort");
        int[] array = Sorting.GenerateRandomArray();
        int[] intArray = new int[100];
        Array.Copy(array, intArray, 100);

        Console.Write("Sort array of random int:    ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            intArray = QuickSort<int>(intArray, 0, 99);
        });

        double[] doubleArray = new double[100];
        Array.Copy(array, doubleArray, 100);

        Console.Write("Sort array of random double: ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            doubleArray = QuickSort<double>(doubleArray, 0, 99);
        });

        string[] stringArray = new string[100];
        for (int count = 0; count < 100; count++)
        {
            stringArray[count] = array[count].ToString();
        }

        Console.Write("Sort array of random string: ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            stringArray = QuickSort<string>(stringArray, 0, 99);
        });
    }
}