using System;

namespace Task01Arrays20IntIndexX5
{
    class Task01Arrays20IntIndexX5
    {
        static void Main()
        {
            int[] twentyIntArray = new int[20];
            for (int index = 0; index < twentyIntArray.Length; index++)
            {
                twentyIntArray[index] = index * 5;
            }
            for (int index = 0; index < twentyIntArray.Length; index++)
            {
                Console.WriteLine("element[{0}] = {1}", index, twentyIntArray[index]);
            }
        }
    }
}
