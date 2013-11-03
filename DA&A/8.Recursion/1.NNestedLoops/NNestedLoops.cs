using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NNestedLoops
{
    static void NestedLoopss(int numberOfLoops, int numberOfIterations, int[] loops, int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            PrintLoops(loops, numberOfLoops);
            return;
        }
        for (int counter = 1; counter <= numberOfIterations; counter++)
        {
            loops[currentLoop] = counter;
            NestedLoopss(numberOfLoops, numberOfIterations, loops, currentLoop + 1);
        }
    }
    static void PrintLoops(int[] loops, int lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("{0} ", loops[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int[] loops = new int[3];
        NestedLoopss(3, 3, loops, 0);
    }
}
