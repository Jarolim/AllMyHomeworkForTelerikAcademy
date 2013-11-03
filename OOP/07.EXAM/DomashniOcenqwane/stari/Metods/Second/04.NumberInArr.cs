using System;
class NumberInArr
{
    static void Main()
    {
        int[] exampleArr = { 1, 1, 2, 6, 4, 11, 6, 16, 8, 21, 1 };
        for (int i = 0; i < exampleArr.Length; i++)
        {
            int memCountedInArr = CountMemberInArr(exampleArr[i], exampleArr);
            int oneCounInArr = 3;
            Console.WriteLine("{0} elements in array are {1}", memCountedInArr, exampleArr[i]);
            if (exampleArr[i] == 1)
            {
                if (memCountedInArr == oneCounInArr)
                {
                    Console.WriteLine("It's working");
                }
                else
                {
                    Console.WriteLine("Bugs,Bugs,Bugs in CountMemberInArr");
                }
            }
        }
    }
    public static int CountMemberInArr(int i, int[] exampleArr)
    {
        int count = 0;
        for (int j = 0; j < exampleArr.Length; j++)
        {
            if (i == exampleArr[j])
            {
                count++;
            }
        }
        return count;
    }
}

