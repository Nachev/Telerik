namespace MatrixClass
{
    using System;
    using System.Text;

    public class Matrix
    {
        private int[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.matrix[row, col] = new int();
                }
            }
        }

        public int this[int rows, int cols]
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

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int firstMatrixCols = matrix1.GetLength(1);

            Matrix resultMatrix = new Matrix(firstMatrixRows, firstMatrixCols);

            // Check if matrix dimensions are equal
            if (firstMatrixRows == matrix2.GetLength(0) && firstMatrixCols == matrix2.GetLength(1))
            {
                for (int row = 0; row < firstMatrixRows; row++)
                {
                    for (int col = 0; col < firstMatrixCols; col++)
                    {
                        resultMatrix[row, col] = matrix1[row, col] + matrix2[row, col];
                    }
                }
            }
            else
            {
                Console.WriteLine("Entered matrixes are different in size. Adding impossible");
            }

            return resultMatrix;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int firstMatrixCols = matrix1.GetLength(1);

            Matrix resultMatrix = new Matrix(firstMatrixRows, firstMatrixCols);

            // Check if matrix dimensions are equal
            if (firstMatrixRows == matrix2.GetLength(0) && firstMatrixCols == matrix2.GetLength(1))
            {
                for (int row = 0; row < firstMatrixRows; row++)
                {
                    for (int col = 0; col < firstMatrixCols; col++)
                    {
                        resultMatrix[row, col] = matrix1[row, col] - matrix2[row, col];
                    }
                }
            }
            else
            {
                Console.WriteLine("Entered matrixes are different in size. SUbtracting impossible");
            }

            return resultMatrix;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            int firstMatrixRows = matrix1.GetLength(0);
            int secondMatrixCols = matrix2.GetLength(1);

            Matrix resultMatrix = new Matrix(firstMatrixRows, secondMatrixCols);

            // Check dimensions if multiply is possible
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                for (int firstRow = 0; firstRow < firstMatrixRows; firstRow++)
                {
                    for (int secondCol = 0; secondCol < secondMatrixCols; secondCol++)
                    {
                        for (int count = 0; count < firstMatrixRows; count++)
                        {
                            resultMatrix[firstRow, secondCol] += matrix1[firstRow, count] * matrix2[count, secondCol];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Entered matrixes are incompatible in dimensions. First matrix columns have to be equal to second matrix rows");
            }

            return resultMatrix;
        }

        public int GetLength(int dimension)
        {
            return this.matrix.GetLength(dimension);
        }

        public string ToString()
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

            return result.ToString();
        }

        public int MaxElementLength()
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

        public void Randomize(int from, int to)
        {
            Random randomGenerator = new Random();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    this.matrix[row, col] = randomGenerator.Next(from, to);
                }
            }
        }

        public void Input()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    int breakCount = 5;
                    do
                    {
                        Console.Write("Enter value for element [{0},{1}] - ", row + 1, col + 1);
                        string temp = Console.ReadLine();
                        if (int.TryParse(temp, out this.matrix[row, col]))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try again");
                        }

                        breakCount--;

                        if (breakCount <= 0)
                        {
                            Console.WriteLine("Error limit reached! Exiting.");
                            Environment.Exit(0);
                        }
                    }
                    while (breakCount > 0);
                }
            }
        }
    }
}
