using System;
class IsBiggerThanNeigbors
{
    static void Main()
    {
        int[] exampleArr = { 1, 1, 2, 6, 4, 11, 6, 16, 8, 21, 1 };
        int i = 0;
        Console.Write("Please insert number from 0 to {0}:", exampleArr.Length - 1);
        i = int.Parse(Console.ReadLine());
        Console.WriteLine("The {0} is {1} than neigbors", exampleArr[i], IsBigLowEqual(i, exampleArr));
    }

    public static string IsBigLowEqual(int i, int[] exampleArr)
    {
        string equalLowBig = "equal";
        string lowerComparison = "equal";
        string higherComparison = "equal";
        if ((i - 1) < 0)
        {
            if (exampleArr[i + 1] > exampleArr[i])
            {
                higherComparison = "lower";
            }
            else if (exampleArr[i + 1] < exampleArr[i])
            {
                higherComparison = "bigger";
            }
        }
        if ((i + 1) > (exampleArr.Length - 1))
        {
            if (exampleArr[i - 1] > exampleArr[i])
            {
                lowerComparison = "lower";
            }
            else if (exampleArr[i - 1] < exampleArr[i])
            {
                lowerComparison = "bigger";
            }
        }
        if (((i - 1) >= 0) && (i + 1 <= (exampleArr.Length - 1)))
        {
            if (exampleArr[i - 1] > exampleArr[i])
            {
                lowerComparison = "bigger";
            }
            if (exampleArr[i + 1] > exampleArr[i])
            {
                //higherComparison = "lower";
                return "-1";
            }
        }
        if ((lowerComparison == "bigger") || (higherComparison == "Bigger"))
        {
            equalLowBig = "bigger";
        }
        else if ((lowerComparison == "lower") || (higherComparison == "lower"))
        {
            // equalLowBig = "lower";
            return "-1";
        }
        else
        {
            //  equalLowBig = "equal";
            return "-1";
        }
        return equalLowBig;
    }
}

