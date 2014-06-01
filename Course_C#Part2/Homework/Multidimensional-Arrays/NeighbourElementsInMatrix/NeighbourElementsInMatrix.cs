namespace NeighbourElementsInMatrix
{
    using System;
    using System.Text;

    public struct EqualElement
    {
        public int Counter;
        public int Element;
    }

    public class NeighbourElementsInMatrix
    {
        private static void Main()
        {
            Console.Title = "Lrgest area of equal neighbour elements in matrix";

            /*// Inputs
            Console.WriteLine("Enter dimensions");
            int rows = new int();
            rows = Input("first dimension N");
            int cols = new int();
            cols = Input("second dimension M");
            Console.WriteLine();*/

            int[,] matrix = 
            {
            { 1, 3, 2, 2, 2, 4 }, 
            { 3, 3, 3, 2, 4, 4 }, 
            { 4, 3, 3, 2, 3, 3 }, 
            { 4, 3, 3, 3, 3, 1 }, 
            { 4, 3, 3, 3, 1, 1 } 
            }; // new int[rows, cols];

            // MtrxInput(matrix);

            // Print
            PrintMatrix(matrix);

            // Solve
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            EqualElement max = FindMaxArea(matrix, visited);
            Console.WriteLine("Maximal area consists of {0} elements of {1}", max.Counter, max.Element);
        }

        private static int Input(string name)
        {
            Console.Write("Enter {0}", name);
            int value = new int();
            int breakCount = 5;

            do
            {
                Console.Write(" -> ");
                string temp = Console.ReadLine();
                bool isCorrect = int.TryParse(temp, out value);

                if (isCorrect)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            } 
            while (true);

            return value;
        }

        private static void MtrxInput(int[,] matrix)
        {
            Console.WriteLine("Enter matrix elements.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = Input(string.Format("[{0}, {1}]", row, col));
                }
            }
        }

        private static EqualElement FindMaxArea(int[,] matrix, bool[,] visited)
        {
            int maxCounter = int.MinValue;
            int element = new int();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // Recursive method to find equal elements
                    int counter = new int();
                    FindEquals(visited, matrix, row, col, matrix[row, col], ref counter);

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        element = matrix[row, col];
                    }
                }
            }

            EqualElement max = new EqualElement();
            {
                max.Counter = maxCounter;
                max.Element = element;
            }

            return max;
        }

        private static void FindEquals(bool[,] visited, int[,] matrix, int row, int col, int comparator, ref int counter)
        {
            // Check if outside of the boundaries
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            // Check if equal
            if (matrix[row, col] != comparator)
            {
                return;
            }

            // Check if element is visited
            if (visited[row, col])
            {
                return;
            }

            // Mark as visited
            visited[row, col] = true;
            counter++;

            // Call recursive this method for each direction
            FindEquals(visited, matrix, row - 1, col, comparator, ref counter); // Up
            FindEquals(visited, matrix, row, col - 1, comparator, ref counter); // Left
            FindEquals(visited, matrix, row + 1, col, comparator, ref counter); // Down
            FindEquals(visited, matrix, row, col + 1, comparator, ref counter); // Right

            return;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("\nMatrix");
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string temp = matrix[row, col].ToString();
                    result.Append(temp.PadLeft(4)).Append(" ");
                }

                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
