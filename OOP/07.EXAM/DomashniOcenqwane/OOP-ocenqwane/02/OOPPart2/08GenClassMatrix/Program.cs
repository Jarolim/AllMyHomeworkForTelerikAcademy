//HW problems 8,9 and 10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08GenClassMatrix
{
    class Program
    {
        static void Main()
        {
            MatrixT<int> testMatrix = new MatrixT<int>(2, 2);
            testMatrix[0,0] = 11;                          // assign values and /problem 9/ test the indexer
            testMatrix[0,1] = 12;
            testMatrix[1,0] = 21;
            testMatrix[1,1] = 22;
            Console.WriteLine(testMatrix[0,1]);  //test the input data and indexer /must print 12/

            MatrixT<int> testMatrixTwo = new MatrixT<int>(2, 2);
            testMatrixTwo[0, 0] = 11;                          
            testMatrixTwo[0, 1] = 12;
            testMatrixTwo[1, 0] = 21;
            testMatrixTwo[1, 1] = 22;

            MatrixT<int> addition = testMatrix + testMatrixTwo;              // test +
            Console.WriteLine("Addition:\n");
            PrintResult(addition);

            MatrixT<int> substraction = testMatrix - testMatrixTwo;      // test -
            Console.WriteLine("Substraction:\n");
            PrintResult(substraction);

            MatrixT<int> product = testMatrix * testMatrixTwo;             // test *
            Console.WriteLine("Multiplication:\n");
            PrintResult(product);

            if (testMatrix)                                                 // test without a zero elements
            {
                Console.WriteLine("There in no zero element!");
            }
            else
            {
                Console.WriteLine("There is a zero element!");
            }

            if (substraction)                                               // test with zero elements
            {
                Console.WriteLine("There in no zero element!");
            }
            else
            {
                Console.WriteLine("There is a zero element!");
            }
        }

        static void PrintResult(MatrixT<int> input)                       // print results
        {
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    Console.Write(input[row, column] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
