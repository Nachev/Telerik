namespace T12.EightQueenPuzzle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SampleProgram
    {
        private static bool[,] board = new bool[8,8];

        private static void Main(string[] args)
        {
            int solutionsCount = 0;
            solutionsCount = Check(board, solutionsCount);
            Console.WriteLine(solutionsCount);
        }

        private static int Check(bool[,] board, int solutionsCount, int startRow=0, int startCol=0)
        {
            int count = 0;

            for (int row = startRow; row < board.GetLength(0); row++)
            {
                for (int col = startCol; col < board.GetLength(1); col++)
                {
                    if (!(board[row, col] || CheckCol(board, row)))
                    {
                        board[row, col] = true;
                        count += 1;
                        row += 1;

                        Console.WriteLine(count);

                        break;
                    }
                }

                if (count == 8)
                {
                    return solutionsCount + 1;
                }
            }

            if (count < 8)
            {
                return Check(InitBoard(board.GetLength(0)), solutionsCount, startRow, startCol + 1);
            }

            return solutionsCount + 1;
        }

        private static bool CheckCol(bool[,] board, int rowIndex)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[rowIndex, i])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool[,] InitBoard(int dimensionLength)
        {
            return new bool[dimensionLength, dimensionLength];
        }
    }
}
