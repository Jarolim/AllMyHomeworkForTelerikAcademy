using System;
using System.Linq;

namespace Matrix
{
    [VersionAttribute.Version(2,3)]
    class TestMatrix
    {
        static void Main()
        {
            try
            {
                Matrix<int> matrix = new Matrix<int>(5, 5);
                matrix[0, 0] = 156;
                matrix[1, 0] = 2;
                Console.WriteLine(matrix[0, 0]);
                Console.WriteLine(matrix[1, 0]);
                Console.WriteLine(matrix[1, 1]);

                //Throw excepption
                //Matrix<int> matrix2 = new Matrix<int>(4, 5);
                //Matrix<int> sum = matrix + matrix2;
                //int[,] arr1 = new {{1, 3, 4},{5, 6, 9},{-5,6,-8}};

                int[,] arr = { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };
                int[,] arr1 = { { 11, -2, 3 }, { -8, 4, 2 }, { -1, -1, -2 } };

                
                Matrix<int> matrix1 = new Matrix<int>(arr);
                Matrix<int> matrix2 = new Matrix<int>(arr1);
                Matrix<int> matrix3 = new Matrix<int>(new int[,] {{1,3,4},{5,6,7},{1,2,3},{-5,4,3}});

                if (matrix1)
                {
                    Console.WriteLine("non - zero");
                }
                else
                {
                    Console.WriteLine("zero");
                }
                                
                if (new Matrix<float>())
                {
                    Console.WriteLine("non - zer");
                }
                else
                {
                    Console.WriteLine("zero");
                }

                if(new Matrix<float>(new float[,]{{0f,0f},{0f,0f}}))
                {
                    Console.WriteLine("non - zer");
                }
                else
                {
                    Console.WriteLine("zero");
                }


            }
            catch (MatrixException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
