namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// Program for rotating traverse of a square matrix.
    /// </summary>
    public static class RotatingMatrixTraversal
    {
        /// <summary>Number of possible directions of traverse.</summary>
        private const int DirectionsCount = 8;

        /// <summary>Traverse value step.</summary>
        private const int Step = 1;

        /// <summary>Minimal size of the matrix by requirements.</summary>
        private const int MinimalDimensionSize = 1;

        /// <summary>Maximal size of the matrix by requirements.</summary>
        private const int MaximalDimensionSize = 100;

        /// <summary>Clockwise list of directions.</summary>
        private static readonly IList<CoordinatesCouple> Directions = new ReadOnlyCollection<CoordinatesCouple>(
            new[]
            {
                new CoordinatesCouple(1, 1), // DownRight - 0
                new CoordinatesCouple(1, 0), // Down - 1
                new CoordinatesCouple(1, -1), // DownLeft - 2
                new CoordinatesCouple(0, -1), // Left - 3
                new CoordinatesCouple(-1, -1), // UpLeft - 4
                new CoordinatesCouple(-1, 0), // Up - 5
                new CoordinatesCouple(-1, 1), // UpRight - 6
                new CoordinatesCouple(0, 1), // Right - 7
            });

        /// <summary>
        /// Program entry point.
        /// </summary>
        public static void Main()
        {
            string message = string.Format(
                "Enter integer number for dimensions of a square matrix (n x n),\n" +
                              "in range ({0} <= n <= {1})\n",
                MinimalDimensionSize,
                MaximalDimensionSize);
            try
            {
                int matrixSize = ConsoleManager.DimensionsInput(message, MinimalDimensionSize, MaximalDimensionSize);
                int[,] matrix = ProcessTraverse(matrixSize);
                string outputString = MatrixToString(matrix, matrixSize);
                ConsoleManager.Print(outputString);
            }
            catch(ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns the index of next direction of traversal from list of possible directions.
        /// </summary>
        /// <param name="currentDirectionIndex">Current direction index of traverse.</param>
        /// <returns>Next direction index couple.</returns>
        private static int NextDirectionIndex(int currentDirectionIndex)
        {
            int nextDirectionIndex = currentDirectionIndex + 1;

            if (nextDirectionIndex >= DirectionsCount)
            {
                nextDirectionIndex = 0;
            }

            return nextDirectionIndex;
        }

        /// <summary>
        /// Checks is there empty neighbor cell in all directions.
        /// </summary>
        /// <param name="matrix">Target matrix.</param>
        /// <param name="rowIndex">Current row index.</param>
        /// <param name="colIndex">Current column index.</param>
        /// <returns>True or false.</returns>
        private static bool IsThereEmptyNeighbourCell(int[,] matrix, int rowIndex, int colIndex)
        {
            for (int i = 0; i < DirectionsCount; i++)
            {
                int nextRowIndex = rowIndex + Directions[i].Row;
                int nextColIndex = colIndex + Directions[i].Col;

                // Checks if next target cell is in the matrix range by row.
                bool rowsInRange = nextRowIndex < matrix.GetLength(0) && nextRowIndex >= 0;

                // Checks if next target cell is in the matrix range by column.
                bool colsInRange = nextColIndex < matrix.GetLength(1) && nextColIndex >= 0;
                if (rowsInRange && colsInRange)
                {
                    if (matrix[nextRowIndex, nextColIndex] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Finds next empty cell in the matrix.
        /// </summary>
        /// <param name="matrix">Target matrix.</param>
        /// <returns>Coordinates couple.</returns>
        private static CoordinatesCouple FindEmptyCell(int[,] matrix)
        {
            // First row and first column are filled.
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new CoordinatesCouple(row, col);
                    }
                }
            }

            return new CoordinatesCouple(0, 0);
        }

        /// <summary>
        /// Handles matrix rotating traversal.
        /// </summary>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <returns>Filled matrix.</returns>
        private static int[,] ProcessTraverse(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            int nextValue = 1;
            int row = 0;
            int col = 0;
            int nextDirectionIndex = 0;
            int endValue = matrixSize * matrixSize;

            while (nextValue <= endValue)
            {
                matrix[row, col] = nextValue;
                nextValue += Step;

                if (IsThereEmptyNeighbourCell(matrix, row, col))
                {
                    while (ShouldChangeDirection(row, col, nextDirectionIndex, matrix))
                    {
                        nextDirectionIndex = NextDirectionIndex(nextDirectionIndex);
                    }

                    row += Directions[nextDirectionIndex].Row;
                    col += Directions[nextDirectionIndex].Col;
                }
                else
                {
                    nextDirectionIndex = 0; // Resets direction.
                    var emptyCellCoordinates = FindEmptyCell(matrix);

                    row = emptyCellCoordinates.Row;
                    col = emptyCellCoordinates.Col;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Checks if direction should be changed, when next index is out of range or next element is not zero.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        /// <param name="nextDirectionIndex">Next direction index from list of possible directions.</param>
        /// <param name="matrix">Checked matrix.</param>
        /// <returns>Direction should be changed or not.</returns>
        private static bool ShouldChangeDirection(int row, int col, int nextDirectionIndex, int[,] matrix)
        {
            int nextRowIndex = row + Directions[nextDirectionIndex].Row;
            int nextColIndex = col + Directions[nextDirectionIndex].Col;
            bool isOutOfMatrixRange = IsOutOfMatrixRange(nextRowIndex, nextColIndex, matrix);

            return isOutOfMatrixRange || matrix[nextRowIndex, nextColIndex] != 0;
        }

        /// <summary>
        /// Checks if next indexes are out of range.
        /// </summary>
        /// <param name="nextRowIndex">Next index in matrix for row.</param>
        /// <param name="nextColIndex">Next index in matrix for column.</param>
        /// <param name="matrix">Checked matrix.</param>
        /// <returns>Are next indexes out of range.</returns>
        private static bool IsOutOfMatrixRange(int nextRowIndex, int nextColIndex, int[,] matrix)
        {
            bool isOutOfRange = nextRowIndex >= matrix.GetLength(0) ||
                                nextRowIndex < 0 ||
                                nextColIndex >= matrix.GetLength(1) ||
                                nextColIndex < 0;
            return isOutOfRange;
        }

        /// <summary>
        /// Converts entered matrix to string.
        /// </summary>
        /// <param name="matrix">Two dimensional array to be printed as matrix.</param>
        /// <param name="matrixSize">Size of the matrix entered.</param>
        /// <returns>Entered matrix to string.</returns>
        private static string MatrixToString(int[,] matrix, int matrixSize)
        {
            int maximalElementSize = (matrixSize * matrixSize).ToString().Length;
            string outputFormat = "{0," + (maximalElementSize + 1) + "}";
            var result = new StringBuilder();
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    result.AppendFormat(outputFormat, matrix[rows, cols]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}