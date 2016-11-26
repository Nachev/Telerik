namespace T07.PathInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class SampleProgram
    {
        private static IList<char> path = new List<char>();
        private static bool[,] labyrinth;

        private static void Main(string[] args)
        {
            labyrinth = new bool[,]
            {
                { false, true, false, true, true },
                { true, true, true, true, false },
                { true, false, false, true, true },
                { true, true, true, true, false },
                { false, false, false, true, true }
            };

            PrintMatrix(labyrinth);

            byte[] firstCellCoordinates = { 0, 1 };
            byte[] secondCellCoordinates = { 3, 3 };

            FindPathToExit(firstCellCoordinates[0],
                firstCellCoordinates[1],
                secondCellCoordinates[0],
                secondCellCoordinates[1],
                'U');
        }

        private static void PrintMatrix(bool[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int k = 0; k < labyrinth.GetLength(1); k++)
                {
                    string cell = ".";
                    if (labyrinth[i, k])
                    {
                        cell = "*";
                    }
                    Console.Write(cell);
                }

                Console.WriteLine();
            }
        }

        private static void FindPathToExit(int row, int col, int endRow, int endCol, char direction)
        {
            if (row >= labyrinth.GetLength(0) || 
                row < 0 || 
                col >= labyrinth.GetLength(1) || 
                col < 0 || 
                !labyrinth[row, col])
            {
                return;
            }

            // Append the current direction to the path
            path.Add(direction);

            if (row == endRow && col == endCol)
            {
                PrintPath(path);
            }

            labyrinth[row, col] = false;

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1, endRow, endCol, 'L'); // left
            FindPathToExit(row - 1, col, endRow, endCol, 'U'); // up
            FindPathToExit(row, col + 1, endRow, endCol, 'R'); // right
            FindPathToExit(row + 1, col, endRow, endCol, 'D'); // down

            labyrinth[row, col] = true;

            // Remove the last direction from the path
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath<T>(ICollection<T> arr)
        {
            bool isFirst = true;
            foreach (var item in arr)
            {
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }

                Console.Write("{0}, ", item);
            }

            Console.WriteLine();
        }
    }
}
