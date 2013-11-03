using System;
using System.Linq;

class TicTacToe
{
    static int xResult = 0;
    static int oResult = 0;
    static int drawResult = 0;

    static void Main()
    {

        sbyte[,] field = new sbyte[3, 3];

        string[] lines = new string[3];
        lines[0] = Console.ReadLine();
        lines[1] = Console.ReadLine();
        lines[2] = Console.ReadLine();
        sbyte xCount = 0;
        sbyte oCount = 0;

        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        for (sbyte row = 0; row < 3; row++)
        {
            for (sbyte col = 0; col < 3; col++)
            {
                if (lines[row][col] == 'O')
                {
                    field[row, col] = 0;
                    oCount++;
                }
                else if (lines[row][col] == 'X')
                {
                    field[row, col] = 1;
                    xCount++;
                }
                else
                {
                    field[row, col] = -1;
                }
            }

        }

        if (xCount > oCount)
        {
            Play(field, false);
        }
        else
        {
            Play(field, true);
        }

        Console.WriteLine(xResult);
        Console.WriteLine(drawResult);
        Console.WriteLine(oResult);
        //sw.Stop();
        //Console.WriteLine(sw.Elapsed);
    }


    static void Play(sbyte[,] field, bool playX)
    {
        sbyte result = CheckWinner(field);
        if (result == 1)
        {
            xResult++;
            return;
        }
        if (result == 0)
        {
            oResult++;
            return;
        }

        bool noEmptyElement = true;

        for (sbyte row = 0; row < 3; row++)
        {
            for (sbyte col = 0; col < 3; col++)
            {
                if (field[row, col] < 0)
                {
                    noEmptyElement = false;
                    sbyte[,] copy = (sbyte[,])field.Clone();

                    if (playX)
                    {
                        copy[row, col] = 1;
                    }
                    else
                    {
                        copy[row, col] = 0;
                    }
                    Play(copy, !playX);
                }
            }
        }
        if (noEmptyElement)
        {
            drawResult++;
            return;
        }
    }

    static sbyte CheckWinner(sbyte[,] field)
    {
        sbyte result;

        if (field[0, 1] >= 0)
        {
            result = CheckLine(field, 0, 1, 1);
            if (result >= 0)
            {
                return result;
            }
        }

        if (field[1, 0] >= 0)
        {
            result = CheckLine(field, 1, 0, 0);
            if (result >= 0)
            {
                return result;
            }
        }


        if (field[2, 0] >= 0)
        {
            result = CheckLine(field, 2, 0, 0);
            if (result >= 0)
            {
                return result;
            }
        }

        if (field[0, 2] >= 0)
        {
            result = CheckLine(field, 0, 2, 1);
            if (result >= 0)
            {
                return result;
            }

            result = CheckLine(field, 0, 2, 3);
            if (result >= 0)
            {
                return result;
            }
        }

        if (field[0, 0] >= 0)
        {
            result = CheckLine(field, 0, 0, 0);
            if (result >= 0)
            {
                return result;
            }

            result = CheckLine(field, 0, 0, 1);
            if (result >= 0)
            {
                return result;
            }

            result = CheckLine(field, 0, 0, 2);
            if (result >= 0)
            {
                return result;
            }
        }
        return -1;
    }


    static sbyte CheckLine(sbyte[,] field, sbyte startRow, sbyte startCol, sbyte direction)
    {
        switch (direction)
        {
            case 0:
                if (field[startRow, startCol] == field[startRow, startCol + 1] && field[startRow, startCol] == field[startRow, startCol + 2])
                {
                    return field[startRow, startCol];
                }
                break;
            case 1:
                if (field[startRow, startCol] == field[startRow + 1, startCol] && field[startRow, startCol] == field[startRow + 2, startCol])
                {
                    return field[startRow, startCol];
                }
                break;
            case 2:
                if (field[startRow, startCol] == field[startRow + 1, startCol + 1] && field[startRow, startCol] == field[startRow + 2, startCol + 2])
                {
                    return field[startRow, startCol];
                }
                break;
            case 3:
                if (field[startRow, startCol] == field[startRow + 1, startCol - 1] && field[startRow, startCol] == field[startRow + 2, startCol - 2])
                {
                    return field[startRow, startCol];
                }
                break;
        }
        return -1;
    }
}