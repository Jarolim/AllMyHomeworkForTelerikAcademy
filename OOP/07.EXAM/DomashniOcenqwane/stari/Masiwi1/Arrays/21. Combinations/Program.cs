using System;

class Combination
{
    static bool isEqual(int[] a)
    {
        int x = a[0];
        foreach (int item in a)
        {
            if (item != x)
            {
                return false;
            }
        }
        return true;
    }

    static void Print(int[] a)
    {
        if (isEqual(a) == false)
        {
            foreach (int item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    static void Combinations(int[] array, int index, int N)
    {
        if (index == array.Length)
        {
            Print(array);
        }
        else
        {
            for (int i = 1; i <= N; i++)
            {
                array[index] = i;
                Combinations(array, index + 1, N);
            }
        }
    }

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int k = Int32.Parse(Console.ReadLine());

        int[] variation = new int[k];

        Combinations(variation, 0, n);
    }
}
