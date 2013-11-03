using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08GenClassMatrix
{
    class MatrixT<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        const int baseCapacity = 3;
        private int row;
        private int column;
        private T[,] numMatrix;

        public int Row
        {
            get { return this.row; }
            set 
            {
                if (value < 0) throw new IndexOutOfRangeException(String.Format(
                    "Row has to be a positive number!"));
                else this.row = value;
            }
        }

        public int Column
        {
            get { return this.column; }
            set
            {
                if (value < 0) throw new IndexOutOfRangeException(String.Format(
                    "Column has to be a positive number!"));
                else this.column = value;
            }
        }

        public MatrixT(T[,] numMatrix)                 // Base capacity constructor
        {
            this.Row = numMatrix.GetLength(baseCapacity);
            this.Column = numMatrix.GetLength(baseCapacity);
        }

        public MatrixT(int row, int column)            // Constuctor with row and column by user
        {
            this.Row = row;
            this.Column = column;
            this.numMatrix = new T [row, column];
        }

        public T this[int row, int column]          // problem 9: get the element by index
        {
            get                                                     // get the element from the matrix
            {
                if ((row < 0) || (column < 0))
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index has to be positive: row:{0} or column:{1}.", row, column));
                }
                else if ((row > this.Row) || (column > this.Column))
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index is out of range of the array: max index, index given:{0},{1};{2},{3} ",
                        this.Row, row, this.Column, column));
                }
                else
                {
                    return this.numMatrix[row, column];
                }                
            }
            set                                                      // assign elements to the matrix
            {
                if ((row < 0) || (column < 0))
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index has to be positive: row:{0} or column:{1}.", row, column));
                }
                else if ((row > this.Row) || (column > this.Column))
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index is out of range of the array: max index, index given:{0},{1};{2},{3} ",
                        this.Row, row, this.Column, column));
                }
                else
                {
                    numMatrix[row, column] = value;
                }              
            }
        }
        // problem 10, addition, substraction, multiplication

        public static MatrixT<T> operator +(MatrixT<T> matrixOne, MatrixT<T> matrixTwo) // add matrices
        {
            if ((matrixOne.Row != matrixTwo.Row) || (matrixOne.Column != matrixTwo.Column))
            {
                throw new ArgumentException(String.Format(
                    "The matrices must have equal number of rows and columns"));
            }
            else
            {
                MatrixT<T> sum = new MatrixT<T>(matrixOne.Row, matrixTwo.Column);
                for (int row = 0; row < matrixOne.Row; row++)
                {
                    for (int column = 0; column < matrixOne.Column; column++)
                    {
                        sum[row, column] = (dynamic)matrixOne[row, column] + (dynamic)matrixTwo[row, column];
                    }
                }
                return sum;
            }
        }

        public static MatrixT<T> operator -(MatrixT<T> matrixOne, MatrixT<T> matrixTwo) //substract matrices
        {
            if ((matrixOne.Row != matrixTwo.Row) || (matrixOne.Column != matrixTwo.Column))
            {
                throw new ArgumentException(String.Format(
                    "The matrices must have equal number of rows and columns"));
            }
            else
            {
                MatrixT<T> sum = new MatrixT<T>(matrixOne.Row, matrixTwo.Column);
                for (int row = 0; row < matrixOne.Row; row++)
                {
                    for (int column = 0; column < matrixOne.Column; column++)
                    {
                        sum[row, column] = (dynamic)matrixOne[row, column] - (dynamic)matrixTwo[row, column];
                    }
                }
                return sum;
            }
        }
      
        public static MatrixT<T> operator *(MatrixT<T> matrixOne, MatrixT<T> matrixTwo) //multyply matrices
        {
            if (matrixOne.Column != matrixTwo.Row)
            {
                throw new ArgumentException(String.Format(
                    "The first matrix must have equal number of columns with the rows of the second matrix!"));
            }
            else
            {
                MatrixT<T> product = new MatrixT<T>(matrixOne.Row, matrixTwo.Column);
                for (int row = 0; row < product.Row; row++)
                {
                    for (int column = 0; column < product.Column; column++)
                    {
                        for (int k = 0; k < matrixOne.Column; k++)
                        {
                            product[row, column] += (dynamic)matrixOne[row, k] * (dynamic)matrixTwo[k, column];
                        }
                    }
                }
                return product;
            }
        }

        // implement the true operator

        public static bool operator true(MatrixT<T> numMatrix) 
        {
            bool isNonZero = true;
            for (int row = 0; row < numMatrix.Row; row++)
            {
                for (int column = 0; column < numMatrix.Column; column++)
                {
                    if ((dynamic)numMatrix[row, column] == 0)
                    {
                        isNonZero = false;
                    }
                }
            }
            return isNonZero;
        }

        public static bool operator false(MatrixT<T> numMatrix)
        {
            bool isNonZero = true;
            for (int row = 0; row < numMatrix.Row; row++)
            {
                for (int column = 0; column < numMatrix.Column; column++)
                {
                    if ((dynamic)numMatrix[row, column] == 0)
                    {
                        isNonZero = false;
                    }
                }
            }
            return isNonZero;
        }
    }
}
