namespace MatrixClass
{
    /*Define a class Matrix<T> to hold a matrix of numbers */

    using System;
    using System.Text;

    public class Matrix<T>
        where T : IComparable
    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.matrix[row, col] = default(T);
                }
            }
        }

        public Matrix(T[,] input) : this(input.GetLength(0), input.GetLength(1))
        {
            for (int row = 0; row < input.GetLength(0); row++)
            {
                for (int col = 0; col < input.GetLength(1); col++)
                {
                    this.matrix[row, col] = input[row, col];
                }
            }
        }

        /*Implement an indexer this[row, col] to access the inner matrix cells.*/
        public T this[int rows, int cols]
        {
            get
            {
                return this.matrix[rows, cols];
            }

            set
            {
                this.matrix[rows, cols] = value;
            }
        }

        /*Implement the operators + and - (addition and subtraction of matrices of 
         * the same size) and * for matrix multiplication. Throw an exception when 
         * the operation cannot be performed. Implement the true operator 
         * (check for non-zero elements).*/
        public static bool operator true(Matrix<T> mtrx)
        {
            for (int row = 0; row < mtrx.GetLength(0); row++)
            {
                for (int col = 0; col < mtrx.GetLength(1); col++)
                {
                    if (mtrx[row, col].CompareTo(default(T)) != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Addition(matrix1, matrix2);
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Subtraction(matrix1, matrix2);
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Multiplication(matrix1, matrix2);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int padding = this.MaxElementLength();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.Append(Convert.ToString(this.matrix[row, col]).PadLeft(padding)).Append(" ");
                }

                result.AppendLine();
            }

            result.Length -= 2;
            return result.ToString();
        }

        private static Matrix<T> Addition(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int firstMatrixCols = matrix1.GetLength(1);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrixRows, firstMatrixCols);

            // Check if matrix dimensions are equal
            if (firstMatrixRows == matrix2.GetLength(0) && firstMatrixCols == matrix2.GetLength(1))
            {
                for (int row = 0; row < firstMatrixRows; row++)
                {
                    for (int col = 0; col < firstMatrixCols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)matrix1[row, col] + (dynamic)matrix2[row, col];
                    }
                }
            }
            else
            {
                throw new ArgumentException("Entered matrixes are different in size. Adding impossible");
            }

            return resultMatrix;
        }

        private static Matrix<T> Subtraction(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int firstMatrixCols = matrix1.GetLength(1);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrixRows, firstMatrixCols);

            // Check if matrix dimensions are equal
            if (firstMatrixRows == matrix2.GetLength(0) && firstMatrixCols == matrix2.GetLength(1))
            {
                for (int row = 0; row < firstMatrixRows; row++)
                {
                    for (int col = 0; col < firstMatrixCols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)matrix1[row, col] - (dynamic)matrix2[row, col];
                    }
                }
            }
            else
            {
                throw new ArgumentException("Entered matrixes are different in size. SUbtracting impossible");
            }

            return resultMatrix;
        }

        private static Matrix<T> Multiplication(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int secondMatrixCols = matrix2.GetLength(1);

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrixRows, secondMatrixCols);

            // Check dimensions if multiply is possible
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                for (int firstRow = 0; firstRow < firstMatrixRows; firstRow++)
                {
                    for (int secondCol = 0; secondCol < secondMatrixCols; secondCol++)
                    {
                        for (int count = 0; count < firstMatrixRows; count++)
                        {
                            dynamic temp;
                            temp = (dynamic)matrix1[firstRow, count] * (dynamic)matrix2[count, secondCol];
                            resultMatrix[firstRow, secondCol] = resultMatrix[firstRow, secondCol] + temp;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Entered matrixes are incompatible in dimensions. First matrix columns have to be equal to second matrix rows");
            }

            return resultMatrix;
        }

        private int GetLength(int dimension)
        {
            return this.matrix.GetLength(dimension);
        }

        private int MaxElementLength()
        {
            int maxLength = new int();
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    int length = this.matrix[row, col].ToString().Length;

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            return maxLength;
        }
    }
}
