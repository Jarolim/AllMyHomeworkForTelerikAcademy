using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MultiArrays1
    {
        static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

       static void MatrixD(int start, int ending, int[,] matrix)
       {
           int counter = 1;
           int i;
           do
           {
               for (i = start; i < ending; i++)
               {
                   matrix[i, start] = counter;
                   counter++;
               }
               for (i = start + 1; i < ending; i++)
               {
                   matrix[ending - 1, i] = counter;
                   counter++;
               }
               for (i = ending - 2; i >= start; i--)
               {
                   matrix[i, ending - 1] = counter;
                   counter++;
               }
               for (i = ending - 2; i >= start + 1; i--)
               {
                   matrix[start, i] = counter;
                   counter++;
               }
               start++;
               ending--;
           }
           while (ending - start > 0);
           PrintMatrix(matrix);
       }

       static void MatrixA(int start, int ending, int[,] matrix)
       {
           int counter = 1;
           for (int i = 0; i < ending; i++)
           {
               for (start = 0; start < ending; start++)
               {
                   matrix[start, i] = counter;
                   counter++;
               }
           }
           PrintMatrix(matrix);
       }

       static void MatrixB(int start, int ending, int[,] matrix)
       {
           int counter = 1;
           for (int i = 0; i < ending; i++)
           {
               for (start = 0; start < ending; start++)
               {
                   if (i % 2 == 1)
                   {
                       matrix[ending - start - 1, i] = counter;
                       counter++;

                   }
                   else
                   {
                       matrix[start, i] = counter;
                       counter++;
                   }
               }

           }
           PrintMatrix(matrix);
       }

       static void MatrixC(int start, int ending, int[,] matrix) // some error could find them - will be gratefull for any help
       {
           int counter = 1;
           int iteration = 0;
           int newcounter = 1;
           int row = ending-1;
           int col = ending-1;
           bool checking = true;
           int index = ending*ending;
           while (index > 0)

           {
               if (col < 0)
               { col = ending - 1; }
               if (row < 0)
               { row = ending - 1; }

               matrix[row, col] = index;
               index--;
               iteration++;
               if (iteration == counter)
               {
                   if (checking)
                   {
                       row -= counter;
                       col -= counter - 1;
                      
                       
                   }
                   else
                   {
                       row -= counter - 1;
                       col -= counter - 2;
                     
                   }

                   counter =counter+newcounter;
                   if (counter == ending)
                   {
                       newcounter = -1;
                       checking = false;
                   }
                   iteration = 0;
               }
               else
               {
                   row--;
                   col--;
               }
           }
           
                                    
                    
                     
           
           PrintMatrix(matrix);
       }

    static void Main()
    {
        Console.WriteLine("Input number (integer)");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        int ending = size;
        int start = 0;
        MatrixA(start, ending, matrix);
        Console.WriteLine();
        MatrixB(start, ending, matrix);
        Console.WriteLine();
        MatrixC(start, ending, matrix);
        Console.WriteLine();
        MatrixD(start, ending, matrix);
       
    }
}
    
    }

