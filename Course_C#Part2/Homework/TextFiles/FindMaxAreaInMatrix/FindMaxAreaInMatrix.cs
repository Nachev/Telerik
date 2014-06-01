namespace FindMaxAreaInMatrix
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Program that reads a text file containing a square matrix of numbers and finds in the matrix 
    /// an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file 
    /// contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
    /// The output should be a single number in a separate text file.
    /// </summary>
    public class FindMaxAreaInMatrix
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestTextFile.txt";

        /// <summary>
        /// Path to result file.
        /// </summary>
        private const string ResultPath = @"..\..\ResultTextFile.txt";

        /// <summary>
        /// Size of the matrix.
        /// </summary>
        private const int Size = 5;

        /// <summary>
        /// Size of the block of elements to be calculated.
        /// </summary>
        private const int BlockSize = 2;

        /// <summary>
        /// The matrix.
        /// </summary>
        private static double[][] constMatrix = 
            { 
            new double[] { 1, 3, 2, 2, 2 }, 
            new double[] { 3, 3, 3, 2, 4 }, 
            new double[] { 4, 3, 1, 2, 3 }, 
            new double[] { 4, 3, 1, 3, 3 }, 
            new double[] { 4, 3, 3, 3, 1 } 
            }; 

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            string testContent = GenerateTestFileContent();

            CreateTestFileIfNeccessary(testContent);

            string[] inputArr = ReadFileToStringArray();

            int matrixSize = TakeSize(inputArr);

            double[,] realMatrix = TakeMatrix(inputArr, matrixSize);

            int longestElement = LongestElement(realMatrix);

            MatrixPrint(realMatrix, longestElement);

            double maxSum = SearchForMaxSum(realMatrix);

            WriteResultToFile(maxSum);

            PrintResultFromFile();
        }

        /// <summary>
        /// Prints result to console.
        /// </summary>
        private static void PrintResultFromFile()
        {
            Console.WriteLine("Maximal sum of block of elements in size {0}x{0} is : {1}", BlockSize, File.ReadAllText(ResultPath));
        }

        /// <summary>
        /// Writes result to file.
        /// </summary>
        /// <param name="maxSum">Max sum of block of elements in matrix.</param>
        private static void WriteResultToFile(double maxSum)
        {
            File.WriteAllText(ResultPath, maxSum.ToString());
        }

        /// <summary>
        /// Returns matrix from array of strings containing each line.
        /// </summary>
        /// <param name="array">Array of strings containing each line.</param>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <returns>Two dimensional array - matrix.</returns>
        private static double[,] TakeMatrix(string[] array, int matrixSize)
        {
            double[,] realMatrix = new double[matrixSize, matrixSize];
            for (int index = 1; index < array.Length; index++)
            {
                string[] line = array[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int lineIndex = 0; lineIndex < line.Length; lineIndex++)
                {
                    realMatrix[index - 1, lineIndex] = int.Parse(line[lineIndex]);
                }
            }

            return realMatrix;
        }

        /// <summary>
        /// Returns the size of a matrix from array of strings containing lines of text file.
        /// </summary>
        /// <param name="array">Array of strings containing lines of text file.</param>
        /// <returns>Integer number size of matrix.</returns>
        private static int TakeSize(string[] array)
        {
            return int.Parse(array[0].Trim());
        }

        /// <summary>
        /// Reads file lines to string array.
        /// </summary>
        /// <returns>Array of strings containing lines of text file.</returns>
        private static string[] ReadFileToStringArray()
        {
            return File.ReadAllLines(Path);
        }

        /// <summary>
        /// Creates test text file if such do not exists.
        /// </summary>
        /// <param name="testContent">Content of test file.</param>
        private static void CreateTestFileIfNeccessary(string testContent)
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, testContent);
            }
        }

        /// <summary>
        /// Generates test file content.
        /// </summary>
        /// <returns>String containing needed text file.</returns>
        private static string GenerateTestFileContent()
        {
            StringBuilder testFileContent = new StringBuilder();
            testFileContent.Append(Size).AppendLine();
            for (int index = 0; index < constMatrix.GetLength(0); index++)
            {
                testFileContent.Append(string.Join(" ", constMatrix[index])).AppendLine();
            }

            return testFileContent.ToString();
        }

        /// <summary>
        /// Finds element max length for better visual performance.
        /// </summary>
        /// <param name="realMatrix">Two dimensional array</param>
        /// <returns>The length of longest number by chars</returns>
        private static int LongestElement(double[,] realMatrix)
        {
            int maxLength = int.MinValue;

            for (int row = 0; row < realMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < realMatrix.GetLength(1); col++)
                {
                    int length = realMatrix[row, col].ToString().Length;

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            return maxLength;
        }

        /// <summary>
        /// Prints matrix on console.
        /// </summary>
        /// <param name="matrix">Two dimensional array to be printed.</param>
        /// <param name="longestElement">The length of longest element of array.</param>
        private static void MatrixPrint(double[,] matrix, int longestElement)
        {
            StringBuilder line = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    line.Append(Convert.ToString(matrix[row, col]).PadRight(longestElement)).Append(" ");
                }

                Console.WriteLine(line.ToString());
                line.Clear();
            }
        }

        /// <summary>
        /// Traverse the matrix to call calculating method with starting position.
        /// </summary>
        /// <param name="matirx">Two dimensional array</param>
        /// <returns>Max sum of square of elements</returns>
        private static double SearchForMaxSum(double[,] matirx)
        {
            double maxSum = new double();
            for (int row = 0; row < matirx.GetLength(0) - BlockSize; row++)
            {
                for (int col = 0; col < matirx.GetLength(1) - BlockSize; col++)
                {
                    double currentSum = new double();
                    currentSum = SumSquareOfElement(matirx, row, col);
                    maxSum = MaxSum(currentSum, maxSum);
                }
            }

            return maxSum;
        }

        /// <summary>
        /// Returns sum of square block of elements.
        /// </summary>
        /// <param name="matrix">The matrix to be traversed.</param>
        /// <param name="currentRow">Starting row.</param>
        /// <param name="currentCol">Starting column.</param>
        /// <returns>Sum of elements.</returns>
        private static double SumSquareOfElement(double[,] matrix, int currentRow, int currentCol)
        {
            double currentSum = new double();
            for (int row = 0; row < BlockSize; row++)
            {
                for (int col = 0; col < BlockSize; col++)
                {
                    currentSum += matrix[currentRow + row, currentCol + col];
                }
            }

            return currentSum;
        }

        /// <summary>
        /// Returns maximal of two numbers.
        /// </summary>
        /// <param name="currentSum">First number.</param>
        /// <param name="maxSum">Second number.r</param>
        /// <returns>Greater number.</returns>
        private static double MaxSum(double currentSum, double maxSum)
        {
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }

            return maxSum;
        }
    }
}