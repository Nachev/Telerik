namespace ExpectedRunningTimeOfCalcSum
{
    using System;
    using System.Linq;

    /* * What is the expected running time of the following C# code? Explain why.
     * Assume the input matrix has size of n * m.
    * 
    * Answer: O(n * m), because the recursion simulates nested loops for the two 
     * dimensions of the matrix.*/
    internal class SampleProgram
    {
        private static readonly Random rng = new Random();

        private const int DefaultMatrixSizeN = 100;
        private const int DefaultMatrixSizeM = 70;
        private const int MaximalValueInMatrix = 100;
        private const int MinimalValueInMatrix = -50;

        private static void Main(string[] args)
        {
            int[,] sampleMatrix = GenerateRandomMatrix();

            Console.WriteLine(CalcSum(sampleMatrix, 0));
        }

        private static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++) 
            {
                sum += matrix[row, col]; // N
            }

            if (row + 1 < matrix.GetLength(1)) // M
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }

        private static int[,] GenerateRandomMatrix(int sizeN = DefaultMatrixSizeN, int sizeM = DefaultMatrixSizeM)
        {
            int[,] randomMatrix = new int[sizeN, sizeM];

            for (int row = 0; row < sizeN; row++)
            {
                for (int col = 0; col < sizeM; col++)
                {
                    randomMatrix[row, col] = rng.Next(MinimalValueInMatrix, MaximalValueInMatrix);
                }
            }

            return randomMatrix;
        }
    }
}