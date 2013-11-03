using System;
using System.Linq;

class Lines
{
    static char[, ,] cube;
    static int maxResult = 0;
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


        for (int height = 0; height < inputHeight; height++)
        {
            for (int width = 0; width < inputWidth; width++)
            {
                for (int depth = 0; depth < inputDepth; depth++)
                {
                    CallCounter(width, height, depth);
                }
            }
        }

        if (maxResult > 1)
        {
            Console.WriteLine("{0} {1}", maxResult, resultCount);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    static void CallCounter(int width, int height, int depth)
    {
        CountCubes(width, 0, height, 1, depth, 0);
        CountCubes(width, 0, height, 1, depth, +1);
        CountCubes(width, 0, height, 1, depth, -1);

        CountCubes(width, +1, height, 1, depth, 0);
        CountCubes(width, +1, height, 1, depth, +1);
        CountCubes(width, +1, height, 1, depth, -1);

        CountCubes(width, -1, height, 1, depth, 0);
        CountCubes(width, -1, height, 1, depth, +1);
        CountCubes(width, -1, height, 1, depth, -1);

        //CountCubes(width, 0, height,  0, depth, 0);
        CountCubes(width, 0, height,  0, depth, +1);
        //CountCubes(width, 0, height,  0, depth, -1);
                                      
        CountCubes(width, +1, height, 0, depth, 0);
        CountCubes(width, +1, height, 0, depth, +1);
        //CountCubes(width, +1, height, 0, depth, -1);
                                      
        //CountCubes(width, -1, height, 0, depth, 0);
        //CountCubes(width, -1, height, 0, depth, +1);
        //CountCubes(width, -1, height, 0, depth, -1);
    }

    static void CountCubes(int width, int wOffset, int height, int hOffset, int depth, int dOffset)
    {
        char letter = cube[width, height, depth];
        int currentLenght = 1;
        width += wOffset;
        height += hOffset;
        depth += dOffset;

        while (!OutOfBounds(width, height, depth) && cube[width, height, depth] == letter)
        {
            width += wOffset;
            height += hOffset;
            depth += dOffset;
            currentLenght++;
        }

        if (currentLenght > maxResult)
        {
            maxResult = currentLenght;
            resultCount = 1;
        }
        else if (currentLenght == maxResult)
        {
            resultCount++;
        }
    }

    static bool OutOfBounds(int width, int height, int depth)
    {
        if (width >= inputWidth || width < 0 || height >= inputHeight || height < 0 || depth >= inputDepth || depth < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}