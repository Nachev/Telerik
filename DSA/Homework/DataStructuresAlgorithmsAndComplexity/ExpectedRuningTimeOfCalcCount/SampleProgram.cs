namespace ExpectedRuningTimeOfCalcCount
{
    using System;
    using System.Linq;

    /* What is the expected running time of the following C# code? Explain why. 
     * Assume the input matrix has size of n * m.
     * 
     * Answer: Worst case - O(n * m), when all values are positive and even.
     Best case - O(n), when all values are odd, internal loop will never be executed.
     Average case - O(n * m / 4), when half of the values are even and half of them positive*/

    internal class SampleProgram
    {
        private const int DefaultMatrixSizeN = 100;
        private const int DefaultMatrixSizeM = 70;
        private const int MaximalValueInMatrix = 100;
        private const int MinimalValueInMatrix = -100;

        private static readonly Random rng = new Random();

        private static void Main(string[] args)
        {
            int[,] sampleMatrix = GenerateRandomMatrix();
            var result = CalcCount(sampleMatrix);
            Console.WriteLine(result);
        }

        private static long CalcCount(int[,] matrix)
        {
            long count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0) // If value is even.
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0) // If value is positive
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
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