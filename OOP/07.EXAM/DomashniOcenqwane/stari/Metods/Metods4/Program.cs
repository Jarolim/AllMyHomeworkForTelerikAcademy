using System;

class Program
{
    static void Check(int[] arr)
    {

        if (arr[1] < arr[2] && arr[2] > arr[3])
        {
            Console.WriteLine("Number {0} is the bigger then {1} {2}", arr[2], arr[1], arr[3]);
        }
        else
        {
            Console.WriteLine("Number {0} isn't the bigger then {1} {2}", arr[2], arr[1], arr[3]);
        }
    }
    static void Main()
    {
        int[] array = new int[6]; //Selected is arr[2]
        Console.WriteLine("Enter 6 elements for Array");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Check(array);
    }
}