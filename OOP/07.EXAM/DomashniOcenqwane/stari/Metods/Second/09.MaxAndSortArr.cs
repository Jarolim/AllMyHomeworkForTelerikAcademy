using System;
using System.Collections.Generic;
class MaxAndSortArr
{
    static void Main()
    {
        int[] exampleArr = { 1, 55, 2, 33, 4, 11, 6, 16, 8, 21, 81 };
        int[] posAndVal =new int[2];
        for (int i = 0; i < exampleArr.Length; i++)
        {
            posAndVal = maxMember(i, exampleArr);
            exampleArr = sort(i, posAndVal, exampleArr);
        }
        printArr(exampleArr);
        for (int i = 0; i < exampleArr.Length; i++)
        {
            posAndVal = minMember(i, exampleArr);
            exampleArr = sort(i, posAndVal, exampleArr);
        }
        printArr(exampleArr);        
    }
    public static void printArr(int[] exampleArr)
    {
        foreach (var item in exampleArr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    public static int[] maxMember(int number, int[] exampleArr)
    {        
        int[] posAndVal= new int[2];
        for (int i = number; i < exampleArr.Length; i++)
        {
            if (posAndVal[1]<exampleArr[i])
            {
                posAndVal[0] = i;
                posAndVal[1] = exampleArr[i]; 
            }
        }
        return posAndVal;
    }
    public static int[] minMember(int number, int[] exampleArr)
    {
        int[] posAndVal = new int[2];
        posAndVal[0] = number;
        posAndVal[1] = exampleArr[number];
        for (int i = number; i < exampleArr.Length; i++)
        {            
            if (posAndVal[1] > exampleArr[i])
            {
                posAndVal[0] = i;
                posAndVal[1] = exampleArr[i];
            }
        }
        return posAndVal;
    }
    public static int[] sort(int member, int[] maxPosAndVal, int[] exampleArr)
    {
        int temp = exampleArr[member];
        exampleArr[member] = exampleArr[maxPosAndVal[0]];
        exampleArr[maxPosAndVal[0]] = temp;
        return exampleArr;
    }
}

