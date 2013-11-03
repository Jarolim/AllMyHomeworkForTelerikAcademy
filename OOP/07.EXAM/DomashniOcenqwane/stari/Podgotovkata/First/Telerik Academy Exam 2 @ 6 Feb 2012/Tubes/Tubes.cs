using System;
using System.Linq;

class Tubes
{
    static void Main()
    {
        int startCount = int.Parse(Console.ReadLine());
        int endCount = int.Parse(Console.ReadLine());
        int[] tubes = new int[startCount];
        for (int tube = 0; tube < startCount; tube++)
        {
            tubes[tube] = int.Parse(Console.ReadLine());
        }
        int currentMaxSize = 0;
        int start = 0;
        int end = int.MaxValue;
        int median = (start + end) / 2;

        while (start <= end)
        {

            int count = CountEventualTubes(tubes, median);
            if (count > endCount)
            {
                start = median + 1;
            }
            else if (count < endCount)
            {
                end = median - 1;
            }
            else
            {
                start = median + 1;
                if (median > currentMaxSize)
                {
                    currentMaxSize = median;
                }
            }

            median = (start + end) / 2;
        }

        Console.WriteLine(currentMaxSize);
    }

    static int CountEventualTubes(int[] tubes, int size)
    {
        int count = 0;
        foreach (var tube in tubes)
        {
            count += tube / size;
        }

        return count;
    }
}