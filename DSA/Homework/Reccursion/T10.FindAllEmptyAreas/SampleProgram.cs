namespace T10.FindAllEmptyAreas
{
    using System;
    using System.Collections.Generic;

    internal struct Coordinate
    {
        public int X, Y;

        public Coordinate(int p1, int p2)
        {
            this.X = p1;
            this.Y = p2;
        }

        public static Coordinate operator +(Coordinate first, Coordinate second)
        {
            return new Coordinate(first.X + second.X, first.Y + second.Y);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }

    internal class SampleProgram
    {
        private static readonly Coordinate[] Directions =
        {
            new Coordinate(0, 1), // R
            new Coordinate(1, 0), // D
            new Coordinate(-1, 0), // U
            new Coordinate(0, -1), // L
            //new Coordinate(1, 1), // DR
            //new Coordinate(1, -1), // DL
            //new Coordinate(-1, 1), // UR
            //new Coordinate(-1, -1), // UL
        };

        private static IList<Coordinate> area = new List<Coordinate>();
        private static IList<IList<Coordinate>> areas = new List<IList<Coordinate>>();
        private static bool[,] matrix;
        private static Random randomGenerator = new Random();

        public static void Main(string[] args)
        {
            matrix = GenerateMatrix(10, 10);
            PrintMatrix(matrix);

            // Look for next empty cell
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c])
                    {
                        FindLargestEmptyArea(new Coordinate(r, c));
                        
                        // Copy current area
                        var currentArea = new List<Coordinate>();
                        foreach (Coordinate coord in area)
                        {
                            currentArea.Add(coord);
                        }

                        areas.Add(currentArea);
                        area = new List<Coordinate>();
                    }
                }
            }

            foreach (var currentArea in areas)
            {
                foreach (var item in currentArea)
                {
                    Console.Write("|{0}, {1}|", item.X, item.Y);
                }

                Console.WriteLine();
            }
        }

        private static void FindLargestEmptyArea(Coordinate direction)
        {
            if (direction.X >= matrix.GetLength(0) ||
                direction.X < 0 ||
                direction.Y >= matrix.GetLength(1) ||
                direction.Y < 0 ||
                !matrix[direction.X, direction.Y])
            {
                return;
            }

            // Append current direction in the area
            area.Add(direction);
            matrix[direction.X, direction.Y] = false;

            // Recursively explore all possible directions
            for (int i = 0; i < Directions.Length; i++)
            {
                FindLargestEmptyArea(direction + Directions[i]);
            }

            return;
        }

        private static Coordinate GetFirstEmptyCell(bool[,] matrix, Coordinate startCoordinate)
        {
            for (int i = startCoordinate.X; i < matrix.GetLength(0); i++)
            {
                for (int k = startCoordinate.Y; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k])
                    {
                        return new Coordinate(i, k);
                    }
                }
            }

            throw new ApplicationException("No empty cell found");
        }

        private static bool[,] GenerateMatrix(byte rows, byte columns)
        {
            bool[,] matrix = new bool[rows, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    bool cell = randomGenerator.Next(0, 3) == 0;
                    matrix[i, k] = cell;
                }
            }

            return matrix;
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
    }
}
