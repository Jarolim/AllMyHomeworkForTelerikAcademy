using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sudoku
{
    class Program
    {
        static int[,] sudoku = new int[9, 9];

        static void Solver(int row, int col)
        {
            if (row == 9 && col == 0)
            {
                
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == '-')
                    {
                        sudoku[i, j] = 0;
                    }
                    else
                    {
                        sudoku[i, j] = line[j] - '0';
                    }
                }

            }

        }
    }
}
