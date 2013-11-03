using System;
using System.Linq;

class MaxWalk
{
    static int[, ,] cube;
    static bool[, ,] visited;
    static int inputWidth;
    static int inputHeight;
    static int inputDepth;
    static int currentWidth;
    static int currentHeight;
    static int currentDepth;
    static int finalResult = 0;

    static readonly int[][] offsets =
    {
        new int[] { 1, 0, 0 },
        new int[] { -1, 0, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, -1, 0 },
        new int[] { 0, 0, 1 },
        new int[] { 0, 0, -1 },
    };

    static void Main()
    {
        string inputString = Console.ReadLine();
        string[] input = inputString.Split(' ');

        inputWidth = int.Parse(input[0]);
        inputHeight = int.Parse(input[1]);
        inputDepth = int.Parse(input[2]);

        cube = new int[inputWidth, inputHeight, inputDepth];
        visited = new bool[inputWidth, inputHeight, inputDepth];


        for (int height = 0; height < inputHeight; height++)
        {
            string line = Console.ReadLine();
            string[] lines = line.Split('|');
            for (int depth = 0; depth < lines.Length; depth++)
            {
                string[] numbers = lines[depth].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int width = 0; width < numbers.Length; width++)
                {
                    cube[width, height, depth] = int.Parse(numbers[width]);
                }
            }
        }

        currentWidth = inputWidth / 2;
        currentHeight = inputHeight / 2;
        currentDepth = inputDepth / 2;
        finalResult += cube[currentWidth, currentHeight, currentDepth];
        StartWalking();
        Console.WriteLine(finalResult);
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


    static void StartWalking()
    {
        int lineResult = int.MinValue;
        int result = 0;
        int secondResult = 0;
        int lineWidth = 0;
        int lineHeight = 0;
        int lineDepth = 0;
        int secondWidth = 0;
        int secondHeight = 0;
        int secondDepth = 0;

        while (true)
        {
            foreach (var offset in offsets)
            {
                lineResult = int.MinValue;
                int width = currentWidth;
                int height = currentHeight;
                int depth = currentDepth;

                while (true)
                {
                    width += offset[0];
                    height += offset[1];
                    depth += offset[2];
                    if (!OutOfBounds(width, height, depth))
                    {
                        if (cube[width, height, depth] > lineResult)
                        {
                            lineResult = cube[width, height, depth];
                            lineWidth = width;
                            lineHeight = height;
                            lineDepth = depth;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (lineResult > result)
                {
                    result = lineResult;
                    secondWidth = lineWidth;
                    secondHeight = lineHeight;
                    secondDepth = lineDepth;
                }
                else if (lineResult == result)
                {
                    secondResult = lineResult;
                }
            }

            if (visited[secondWidth, secondHeight, secondDepth] || result == secondResult)
            {
                return;
            }
            else
            {
                finalResult += cube[secondWidth, secondHeight, secondDepth];
                currentWidth = secondWidth;
                currentHeight = secondHeight;
                currentDepth = secondDepth;
                visited[secondWidth, secondHeight, secondDepth] = true;
                result = int.MinValue;
                secondResult = -3000;
            }
        }
    }
}

