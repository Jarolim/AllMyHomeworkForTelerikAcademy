using System;

class Program
{

    static int Check(int[] arr)
    {
        int result = 0;
        for (int i = 2; i < arr.Length; i++)
        {


            if (arr[i - 2] < arr[i - 1] && arr[i - 1] > arr[i])
            {
                result = i - 1;
                break;
            }
            else
            {

                result = -1;

            }

        }

        return result;
    }
    static void Main()
    {
        int[] array = new int[6];
        Console.WriteLine("Enter 6 elements for Array");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(Check(array));
    }
}
