using System;

class SubsetSums
{
    void Subsets(int[] a, int s, int k)
    {
        int subsetsCount = a.Length * a.Length - 1;
        int countEl = 0;
        int tempSum = 0;
        string tempEl = "";

        for (int i = 1; i <= subsetsCount; i++)
        {
            countEl = 0;
            tempSum = 0;
            tempEl = "";
            for (int j = 0; j < a.Length; j++)
            {
                if ((((1 << j) & i) >> j) == 1)
                {
                    countEl++;
                    tempSum += a[j];
                    if (tempEl == "")
                    {
                        tempEl += a[j];
                    }
                    else
                    {
                        tempEl += "+" + a[j];
                    }
                }
            }
            if ((tempSum == s) && (countEl == k))
            {
                Console.WriteLine("Yes({0})", tempEl);
                return;
            }
        }
        Console.WriteLine("There is no subset of {0} elements with sum {1}.", k, s);
    }

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int k = Int32.Parse(Console.ReadLine());
        int s = Int32.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }


        SubsetSums subs = new SubsetSums();
        subs.Subsets(array, s, k);

    }
}