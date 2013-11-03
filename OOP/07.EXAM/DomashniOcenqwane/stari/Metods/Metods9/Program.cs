using System;

class Metods_9
{
    static int MaxElement(int[] arr, int starter)
    {
        int i = 1 + starter;
        for (; i < arr.Length; i++)
        {
            if (arr[i - 1] < arr[i])
            {

                return arr[i];
            }


        }
        return 0;
    }

    static void SortingArray(int[] arr, int result)
    {



        for (int i = 1; i < arr.Length; i++)
        {
            if (result == 1)
            {
                Console.WriteLine(MaxElement(arr, 5));
                arr[i - 1] = 0;
            }
            else
            {
                Console.WriteLine(arr[i - 1]);


            }


        }


    }
    static void Main()
    {
        Console.WriteLine("Enter Max index: ");
        int Maxindex = int.Parse(Console.ReadLine());

        int[] arr = new int[Maxindex];
        Console.WriteLine("Enter elemens for Array");



        for (int i = 0; i < Maxindex; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter start index: ");
        int index = int.Parse(Console.ReadLine());


        SortingArray(arr, index);

    }
}