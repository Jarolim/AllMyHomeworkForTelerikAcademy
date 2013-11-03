using System;

class MergeSortAlg
{
    private int[] MergeSort(int[] a)
    {
        if (a.Length == 1)
            return a;
        int middle = a.Length / 2;
        int[] left = new int[middle];
        for (int i = 0; i < middle; i++)
        {
            left[i] = a[i];
        }
        int[] right = new int[a.Length - middle];
        for (int i = 0; i < a.Length - middle; i++)
        {
            right[i] = a[i + middle];
        }
        left = MergeSort(left);
        right = MergeSort(right);

        int leftptr = 0;
        int rightptr = 0;

        int[] sorted = new int[a.Length];
        for (int k = 0; k < a.Length; k++)
        {
            if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
            {
                sorted[k] = left[leftptr];
                leftptr++;
            }
            else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
            {
                sorted[k] = right[rightptr];
                rightptr++;
            }
        }
        return sorted;
    }

    static void Main()
    {
        int[] arr = { -1, 2, -3, 4, -5, 6, -7 };

        MergeSortAlg aSortingClass = new MergeSortAlg();

        int[] sorted = aSortingClass.MergeSort(arr);

        foreach (int item in sorted) Console.WriteLine(item);
    }
}