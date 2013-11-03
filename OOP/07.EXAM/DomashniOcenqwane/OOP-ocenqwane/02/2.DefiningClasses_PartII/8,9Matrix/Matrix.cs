using System;
using System.Linq;

namespace Matrix
{    
    [VersionAttribute.Version(1,9)]
    public class Matrix<T>
        where T : struct,IComparable,IFormattable,IComparable<T>,IEquatable<T>
    {
        private readonly T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        #region constructors
        public Matrix()
        {            
        }

        /// <summary>
        /// Creates an instance of the class Matrix with given rows and columns count
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            this.matrix = new T[rows, columns];
            this.rows = rows;
            this.cols = columns;
        }

        /// <summary>
        /// Creates an instance of Matrix<T> out of an array T[,]
        /// </summary>
        /// <param name="array">2D array T[,]</param>
        public Matrix(T[,] array)
            :this(array.GetLength(0),array.GetLength(1))
        {
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    this.matrix[row, col] = array[row, col];
                }
            }
        }
        #endregion

        
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public T this[int row, int col]
        {
            get
            {
                if (!IsInside(row, col))
                {
                    this.ExceptionMethod();
                }
                return this.matrix[row, col];
            }
            set
            {
                if (!IsInside(row, col))
                {
                    this.ExceptionMethod();
                }
                this.matrix[row, col] = value;
            }
        }

        #region Methods
        /// <summary>
        /// Check if index is inside matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsInside(int row, int col)
        {
            bool isInside = true;
            if (row < 0 || row >= this.rows || col < 0 || col >= this.cols)
            {
                isInside = false;
            }
            return isInside;
        }

        /// <summary>
        /// Throws exception when argument is outside boundaries of collection
        /// </summary>
        private void ExceptionMethod()
        {
            throw new ArgumentOutOfRangeException(string.Format("Index is outside of boundaries of Matrix."));
        }

        /// <summary>
        /// For testing purposes
        /// </summary>
        /// <returns>Two dimensional Array of T</returns>
        public T[,] PullMatrix()
        {
            T[,] result = new T[this.rows, this.cols];
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    result[row, col] = this.matrix[row, col];
                }
            }
            return result;
        }
        #endregion

        #region Operators
        /// <summary>
        /// Sums two matrices of the same size
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.rows != second.rows || first.cols != second.cols)
            {
                throw new MatrixException("Index is outside of boundaries of Matrix.");
            }           
            Matrix<T> resultMatrix = new Matrix<T>(first.rows, first.cols);

            for (int row = 0; row < resultMatrix.rows; row++)
            {
                for (int col = 0; col < resultMatrix.cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)first[row, col] + (dynamic)second[row, col];                   
                }
            }
            
            return resultMatrix;
        }

        /// <summary>
        /// Substracts two matrices of the same size
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.rows != second.rows || first.cols != second.cols)
            {
                throw new MatrixException("Index is outside of boundaries of Matrix.");
            }           
            Matrix<T> resultMatrix = new Matrix<T>(first.rows, first.cols);

            for (int row = 0; row < resultMatrix.rows; row++)
            {
                for (int col = 0; col < resultMatrix.cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)first[row, col] - (dynamic)second[row, col];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Multiplies two instances of Matrix<T>. Cols of one shoul == rows of other 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            
            if (second.cols == first.rows)
            {
                return second * first;
            }
            if (first.cols == second.rows)
            {
                Matrix<T> multipliedMatrix = new Matrix<T>(first.rows, second.cols);
                for (int row = 0; row < multipliedMatrix.rows; row++)
                {
                    for (int col = 0; col < multipliedMatrix.cols; col++)
                    {
                        T sum = default(T);
                        for (int common = 0; common < multipliedMatrix.cols; common++)
                        {
                            sum += (dynamic)first[row, common] * (dynamic)second[common, col];
                        }
                        multipliedMatrix[row, col] = sum;
                    }
                }
                return multipliedMatrix;
            }
            else
            {
                throw new MatrixException("Theese two matrices can't be multiplied. The number of columns of one should be equal to the number of rows of the other ");
            }
        }

        /// <summary>
        /// Is the matrix defined?
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>True if there is at least one element differente than the default value for the type</returns>
        public static bool operator true(Matrix<T> matrix)
        {
            if (matrix == null || matrix.rows == 0 || matrix.cols == 0)
            {
                return false;
            }
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.cols; col++)
                {
                    if (matrix[row, col].CompareTo(default(T)) != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Is the matrix defined?
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>True if there is at least one element differente than the default value for the type</returns>
        public static bool operator false(Matrix<T> matrix)
        {
            if (matrix == null || matrix.rows == 0 || matrix.cols == 0)
            {
                return true;
            }
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.cols; col++)
                {
                    if (matrix[row, col] != (dynamic)default(T))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

    }
}
