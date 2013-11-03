using System;

class RemoveToSort
{

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();

        int[] index = new int[n];
        int[] length = new int[n];

        length[0] = 1;
        index[0] = -1;

        for (int i = 1; i < n; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (array[i] >= array[j])
                {
                    if (length[i] <= length[j])
                    {
                        length[i] = length[j] + 1;
                        index[i] = j;
                    }
                }
                else if (length[i] == 0)
                {
                    length[i] = 1;
                    index[i] = -1;
                }
            }
        }

        int maxValue=0, maxIndex=-1;

        for (int i = 0, lengths = length.Length; i < lengths; i++)
        {
            if (length[i].CompareTo(maxValue) > 0 || maxIndex == -1)
            {
                maxIndex = i;
                maxValue = length[i];
            }
        }

        if (maxValue == 1)
        {
            Console.WriteLine("There was no increasing sequence in the array.");
            return;
        }

        int[] newArray = new int[maxValue];

        int ind = maxValue-1;
        do
        {
            newArray[ind] = array[maxIndex];
            ind--;
            maxIndex = index[maxIndex];
        }
        while(ind>=0);

        int equal=newArray[0];
        bool isEqual = true;
        foreach (int item in newArray)
        {
            if (item != equal)
            {
                isEqual = false;
                break;
            }
        }

        if (isEqual == false)
        {
            foreach (int item in newArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There was no increasing sequence in the array.");
        }
    }
}