using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> arrToOrder = new List<int>();        
        Console.WriteLine("The biggest number is:{0}",GetMax(arrToOrder));
    }
    public static int GetMax(List<int> arrToOrder)
    {
        int maxNumber=0;
        bool exitFromGetMax=true;
        do
	    {
            Console.Write("Please insert number( -99 for exit):");
            arrToOrder.Add(int.Parse(Console.ReadLine()));
            foreach (var item in arrToOrder)
            {
                if (maxNumber<item)
                {
                    maxNumber = item;
                }
                if (item==-99)
                {
                    exitFromGetMax = false;
                }
            }           
	    } while (exitFromGetMax);
        return maxNumber;
    }
}
