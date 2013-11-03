using System;
using System.Linq;

class Stars3D
{
    static char[, ,] cube;
    static int[] result = new int[200];
    static int resultCount = 0;
    static int inputWidth;
    static int inputHeight;
    static int inputDepth;

    static void Main()
    {
        string inputString = Console.ReadLine();
        string[] input = inputString.Split(' ');

        inputWidth = int.Parse(input[0]);
        inputHeight = int.Parse(input[1]);
        inputDepth = int.Parse(input[2]);

        cube = new char[inputWidth, inputHeight, inputDepth];


        for (int height = 0; height < inputHeight; height++)
        {
            string line = Console.ReadLine();
            string[] lines = line.Split(' ');
            for (int depth = 0; depth < lines.Length; depth++)
            {
                for (int width = 0; width < lines[depth].Length; width++)
                {
                    cube[width, height, depth] = lines[depth][width];
                }
            }
        }
        CountCubes();

        Console.WriteLine(resultCount);
        for (int res = 0; res < result.Length; res++)
        {
            if (result[res] > 0)
            {
                Console.WriteLine("{0} {1}", (char)res, result[res]);
            }
        }
    }

    static void CountCubes()
    {
        for (int depth = 1; depth < inputDepth - 1; depth++)
        {
            for (int height = 1; height < inputHeight - 1; height++)
            {
                for (int width = 1; width < inputWidth - 1; width++)
                {
                    if (CountCubes(width, height, depth))
                    {
                        result[cube[width, height, depth]]++;
                        resultCount++;
                    }
                }
            }
        }
    }

    static bool CountCubes(int width, int height, int depth)
    {
        char letter = cube[width, height, depth];
        return (cube[width + 1, height, depth] == letter) && (cube[width - 1, height, depth] == letter) && (cube[width, height + 1, depth] == letter) && (cube[width, height - 1, depth] == letter) && (cube[width, height, depth + 1] == letter) && (cube[width, height, depth - 1] == letter);
    }
}