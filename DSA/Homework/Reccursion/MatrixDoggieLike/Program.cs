namespace MatrixDoggieLike
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class SampleProgram
    {
        private static IList<char> path = new List<char>();
        private static bool[,] lab;

        private static void Main(string[] args)
        {
            lab = new bool[,] 
            {
                { false, true, false, true, true }, 
                { true, true, true, true, false }, 
                { true, false, false, true, true }, 
                { true, true, true, true, false }, 
                { false, false, false, true, true }
            };


            FindPathToExit(0, 1, 3, 3, 'U');
        }

        private static void FindPathToExit(int row, int col, int endRow, int endCol, char direction)
        {

            if (row >= lab.GetLength(0) || row < 0 || col >= lab.GetLength(1) || col < 0 || !lab[row, col])
            {
                return;
            }

            // Append the current direction to the path
            path.Add(direction);

            if (row == endRow && col == endCol)
            {
                PrintPath(path);
            }

            lab[row, col] = false;

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1, endRow, endCol, 'L'); // left
            FindPathToExit(row - 1, col, endRow, endCol, 'U'); // up
            FindPathToExit(row, col + 1, endRow, endCol, 'R'); // right
            FindPathToExit(row + 1, col, endRow, endCol, 'D'); // down

            lab[row, col] = true;

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
