using System;

class SubsetSums
{
    void Subsets(int[] a, int s)
    {
        int subsetsCount = a.Length * a.Length - 1;
        int tempSum = 0;
        string tempEl = "";

        for (int i = 1; i <= subsetsCount; i++)
        {
            tempSum=0;
            tempEl = "";
            for (int j = 0; j < a.Length; j++)
            {
                if ((((1 << j) & i) >> j) == 1)
                {
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
            if (tempSum == s)
            {
                Console.WriteLine("Yes({0})", tempEl);
                return;
            }
        }
        Console.WriteLine("There is no subset with sum {0}.", s);
    }

    static void Main()
    {
        int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int s = Int32.Parse(Console.ReadLine());

        SubsetSums subs = new SubsetSums();
        subs.Subsets(arr, s);

    }
}