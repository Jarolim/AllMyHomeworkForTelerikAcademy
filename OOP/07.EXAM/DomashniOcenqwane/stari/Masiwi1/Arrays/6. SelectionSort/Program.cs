using System;

class SelectionSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(Console.ReadLine());
        }
        
        int min, temp;
 
        for(int i = 0; i < n-1; i++ )
        {
            min = i;
 
            for(int j = i+1; j < n; j++ )
            {
                if( a[j] < a[min] )
                {
                    min = j;
                }
            }
 
            temp = a[i];
            a[i] = a[min];
            a[min] = temp;
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", a[i]);
        }
    }
}
