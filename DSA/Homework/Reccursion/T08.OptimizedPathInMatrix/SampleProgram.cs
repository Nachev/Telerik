namespace MatrixDoggieLike
{
    using System;
    using System.Collections.Generic;

    internal class SampleProgram
    {
        private static IList<char> path = new List<char>();
        private static bool[,] labyrinth;
        private static Random randomGenerator = new Random();
        private static readonly Tuple<sbyte, sbyte, char>[] Directions =
        {
            new Tuple<sbyte, sbyte, char>(0, 1, 'R'),
            new Tuple<sbyte, sbyte, char>(1, 0, 'D'),
            new Tuple<sbyte, sbyte, char>(-1, 0, 'U'),
            new Tuple<sbyte, sbyte, char>(0, -1, 'L')
        };

        private static void Main(string[] args)
        {
            labyrinth = GenerateLabyrinth(100, 100);
            PrintMatrix(labyrinth);
            Console.ReadLine();

            byte startRowCoordinate = (byte)randomGenerator.Next(0, (labyrinth.GetLength(0) / 2));
            byte startColCoordinate = (byte)randomGenerator.Next(0, (labyrinth.GetLength(1) / 2));
            byte[] firstCellCoordinates = GetRandomPassableCell(labyrinth,
                startRowCoordinate,
                startColCoordinate);

            startRowCoordinate = (byte)randomGenerator.Next((labyrinth.GetLength(0) / 2),
                labyrinth.GetLength(0));
            startColCoordinate = (byte)randomGenerator.Next((labyrinth.GetLength(1) / 2),
                labyrinth.GetLength(1));
            byte[] secondCellCoordinates = GetRandomPassableCell(labyrinth,
                startRowCoordinate,
                startColCoordinate);

            Console.WriteLine("First coordinates - row: {0}, col: {1}",
                firstCellCoordinates[0],
                firstCellCoordinates[1]);
            Console.WriteLine("Second coordinates - row: {0}, col: {1}",
                secondCellCoordinates[0],
                secondCellCoordinates[1]);
            Console.ReadLine();

            FindPathToExit(firstCellCoordinates[0],
                firstCellCoordinates[1],
                secondCellCoordinates[0],
                secondCellCoordinates[1],
                '*');
        }

        private static byte[] GetRandomPassableCell(bool[,] labyrinth, byte startRowCoordinate, byte startColCoordinate)
        {
            byte[] cellCoordinates = new byte[2];

            for (byte i = startRowCoordinate; i < labyrinth.GetLength(0); i++)
            {
                for (byte k = startColCoordinate; k < labyrinth.GetLength(1); k++)
                {
                    if (labyrinth[i, k])
                    {
                        return new byte[] { i, k };
                    }
                }
            }

            return cellCoordinates;
        }

        private static bool[,] GenerateLabyrinth(byte rows, byte columns)
        {
            bool[,] labyrinth = new bool[rows, columns];

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int k = 0; k < labyrinth.GetLength(1); k++)
                {
                    bool cell = randomGenerator.Next(0, 3) != 0;
                    labyrinth[i, k] = cell;
                }
            }

            return labyrinth;
        }

        private static void PrintMatrix(bool[,] matrix, int currentRow = -1, int currentCol = -1)
        {
            string borderLine = new string('=', matrix.GetLength(0));
            Console.WriteLine(borderLine);

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    string cell = "#";
                    if (i == currentRow && k == currentCol)
                    {
                        cell = "&";
                    }
                    else if (matrix[i, k])
                    {
                        cell = ".";
                    }
                    Console.Write(cell);
                }

                Console.WriteLine();
            }
            Console.WriteLine(borderLine);
        }

        private static bool FindPathToExit(int row, int col, int endRow, int endCol, char direction)
        {
            if (row >= labyrinth.GetLength(0) ||
                row < 0 ||
                col >= labyrinth.GetLength(1) ||
                col < 0 ||
                !labyrinth[row, col])
            {
                return false;
            }

            // Append the current direction to the path
            path.Add(direction);

            if (row == endRow && col == endCol)
            {
                PrintPath(path);
                return true;
            }

            labyrinth[row, col] = false;

            // Recursively explore all possible directions
            for (int i = 0; i < Directions.GetLength(0); i++)
            {
                sbyte rowDirection = Directions[i].Item1;
                sbyte colDirection = Directions[i].Item2;
                char directionSymbol = Directions[i].Item3;

                bool found = FindPathToExit(row + rowDirection,
                    col + colDirection,
                    endRow,
                    endCol,
                    directionSymbol);

                if (found)
                {
                    path.RemoveAt(path.Count - 1);
                    return found;
                }
            }

            // labyrinth[row, col] = true;

            // Remove the last direction from the path
            path.RemoveAt(path.Count - 1);

            return false;
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
