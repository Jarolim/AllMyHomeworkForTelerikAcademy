/*Code to refactor*/

//      int i=0;
//      for (i = 0; i < 100;) 
//      {
//         if (i % 10 == 0)
//         {
//         	Console.WriteLine(array[i]);
//         	if ( array[i] == expectedValue ) 
//         	{
//         	   i = 666;
//         	}
//         	i++;
//         }
//         else
//         {
//              Console.WriteLine(array[i]);
//         	i++;
//         }
//      }
//      // More code here
//      if (i == 666)
//      {
//          Console.WriteLine("Value Found");
//      }

using System;

public class RefactorLoop
{
    public static void Main()
    {
        int[] array = new int[] { 111, 222, 333, 444, 555, 666, 777, 888, 999, 101010, 666 }; // Used only to make it work
        int expectedValue = 666;
        int arrayLength = array.Length;

        for (int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}


