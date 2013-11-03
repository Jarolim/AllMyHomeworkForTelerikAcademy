using System;

class Variation
{
    static void Print(int[] a)
    {
        foreach (int item in a)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Variations(int[] array, int index, int N)
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
                Variations(array, index + 1, N);
            }
        }
    }

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int k = Int32.Parse(Console.ReadLine());

        int[] variation = new int[k];

        Variations(variation, 0, n);
    }
}
