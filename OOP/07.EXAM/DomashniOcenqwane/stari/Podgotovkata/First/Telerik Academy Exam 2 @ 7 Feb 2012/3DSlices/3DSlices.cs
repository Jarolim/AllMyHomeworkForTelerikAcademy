using System;
using System.Linq;

class Slices
{
    static int[, ,] cube;
    static long cubeWorth = 0;
    static int[] rows;
    static int[] cols;
    static int[] layers;
    static int inputWidth;
    static int inputHeight;
    static int inputDepth;
    static int finalResult = 0;


    static void Main()
    {
        string inputString = Console.ReadLine();
        string[] input = inputString.Split(' ');

        inputWidth = int.Parse(input[0]);
        inputHeight = int.Parse(input[1]);
        inputDepth = int.Parse(input[2]);

        rows = new int[inputWidth];
        cols = new int[inputHeight];
        layers = new int[inputDepth];

        cube = new int[inputWidth, inputHeight, inputDepth];


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
                    cubeWorth += cube[width, height, depth];
                    rows[width] += cube[width, height, depth];
                    cols[height] += cube[width, height, depth];
                    layers[depth] += cube[width, height, depth];
                }
            }
        }

        cubeWorth /= 2;

        for (int startRow = 1; startRow < rows.Length; startRow++)
        {
            long currentRow = 0;
            for (int row = startRow; row < rows.Length; row++)
            {
                currentRow += rows[row];
            }
            if (currentRow == cubeWorth)
            {
                finalResult++;
            }
        }

        for (int startCol = 1; startCol < cols.Length; startCol++)
        {
            long currentCol = 0;
            for (int col = startCol; col < cols.Length; col++)
            {
                currentCol += cols[col];
            }
            if (currentCol == cubeWorth)
            {
                finalResult++;
            }
        }

        for (int startLayer = 1; startLayer < layers.Length; startLayer++)
        {
            long currentLayer = 0;
            for (int layer = startLayer; layer < layers.Length; layer++)
            {
                currentLayer += layers[layer];
            }
            if (currentLayer == cubeWorth)
            {
                finalResult++;
            }
        }

        Console.WriteLine(finalResult);

    }
}

