using System;

class Array20Ints
{
    static void Main()
    {
        int[] array = new int[20];
        for (int i = 0; i < 20; i++)
        {
            array[i] = i * 5;
        }
        foreach (int item in array)
        {
            Console.WriteLine(item);
        }
    }
}
