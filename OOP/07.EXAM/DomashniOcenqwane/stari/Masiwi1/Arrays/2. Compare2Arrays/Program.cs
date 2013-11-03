using System;

class Compare2Arrays
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] firstArray = new int[n];
        int[] secondArray = new int[n];

        bool equal = true;

        for (int i = 0; i < n; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());

            if (firstArray[i] != secondArray[i])
            {
                equal = false;
                break;
            }
        }
        Console.WriteLine("Are the arrays equal: {0}", equal);
    }
}
