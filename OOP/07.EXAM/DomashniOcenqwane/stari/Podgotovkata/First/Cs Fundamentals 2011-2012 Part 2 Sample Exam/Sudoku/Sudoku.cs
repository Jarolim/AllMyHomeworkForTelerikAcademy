using System;
using System.Linq;

class Sudoku
{
    static void Main()
    {
        int sudokuSize = 9;
        int[,] field = new int[sudokuSize, sudokuSize];

        string[] lines = new string[sudokuSize];
        for (int lineNumber = 0; lineNumber < sudokuSize; lineNumber++)
        {
            lines[lineNumber] = Console.ReadLine();
        }

        for (int row = 0; row < sudokuSize; row++)
        {
            for (int col = 0; col < sudokuSize; col++)
            {
                if (lines[row][col] == '-')
                {
                    field[row, col] = 0;
                }
                else
                {
                    field[row, col] = lines[row][col] - '0';
                }
            }
        }

        PlaySudoku(field);
    }


    static bool ValidNumber(int[,] field, int row, int col)
    {
        int number = field[row, col];
        for (int currentCol = 0; currentCol < field.GetLength(0); currentCol++)
        {
            if (col != currentCol)
            {
                if (number == field[row, currentCol])
                {
                    return false;
                }
            }
        }

        for (int currentRow = 0; currentRow < field.GetLength(0); currentRow++)
        {
            if (row != currentRow)
            {
                if (number == field[currentRow, col])
                {
                    return false;
                }
            }
        }

        int maxRow = MaxDimension(row);
        int maxCol = MaxDimension(col);

        for (int currentRow = maxRow - 3; currentRow < maxRow; currentRow++)
        {
            for (int currentCol = maxCol - 3; currentCol < maxCol; currentCol++)
            {
                if (row != currentRow || col != currentCol)
                {
                    if (number == field[currentRow, currentCol])
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    static int MaxDimension(int dimension)
    {
        if (dimension < 3)
        {
            dimension = 3;
        }
        else if (dimension < 6)
        {
            dimension = 6;
        }
        else
        {
            dimension = 9;
        }
        return dimension;
    }

    static void PlaySudoku(int[,] field)
    {
        bool resultFound = true;
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] == 0)
                {
                    resultFound = false;
                    for (int number = 1; number < 10; number++)
                    {
                        field[row, col] = number;
                        if (ValidNumber(field, row, col))
                        {
                            PlaySudoku((int[,])field.Clone());
                        }
                    }
                    field[row, col] = 0;
                    return;
                }
            }
        }

        if (resultFound)
        {
            PrintField(field);
        }
    }

    static void PrintField(int[,] field)
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                Console.Write(field[row, col]);
            }
            Console.WriteLine();
        }

    }
}