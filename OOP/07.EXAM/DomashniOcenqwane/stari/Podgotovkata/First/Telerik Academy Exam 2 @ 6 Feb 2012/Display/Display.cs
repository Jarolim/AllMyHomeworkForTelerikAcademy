using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Display
{
    static readonly int[] displayDigits = new int[10];
    static readonly List<int[]> output = new List<int[]>();
    static int[] input;

    static void Main()
    {
        StringBuilder sbResult = new StringBuilder();
        displayDigits[0] = Convert.ToInt32("1111110", 2);
        displayDigits[1] = Convert.ToInt32("0110000", 2);
        displayDigits[2] = Convert.ToInt32("1101101", 2);
        displayDigits[3] = Convert.ToInt32("1111001", 2);
        displayDigits[4] = Convert.ToInt32("0110011", 2);
        displayDigits[5] = Convert.ToInt32("1011011", 2);
        displayDigits[6] = Convert.ToInt32("1011111", 2);
        displayDigits[7] = Convert.ToInt32("1110000", 2);
        displayDigits[8] = Convert.ToInt32("1111111", 2);
        displayDigits[9] = Convert.ToInt32("1111011", 2);

        int lines = int.Parse(Console.ReadLine());
        int[] result = new int[lines];
        input = new int[lines];

        for (int line = 0; line < lines; line++)
        {
            input[line] = Convert.ToByte(Console.ReadLine(), 2);
        }

        Calculator(0, result);
        Console.WriteLine(output.Count);
        for (int i = 0; i < output.Count; i++)
        {
            for (int j = 0; j < output[i].Length; j++)
            {
                sbResult.Append(output[i][j]);
            }
            sbResult.Append(Environment.NewLine);
        }
        Console.Write(sbResult.ToString());
    }

    static void Calculator(int level, int[] result)
    {
        if (level == input.Length)
        {
            output.Add(result);
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            if ((displayDigits[i] | input[level]) == displayDigits[i])
            {
                int[] inputCopy = (int[])result.Clone();
                inputCopy[level] = i;
                Calculator(level + 1, inputCopy);
            }
        }
    }
}
