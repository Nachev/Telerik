namespace MaxSumOfSquareOfElements
{
    using System;
    using System.Text;

    /*Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements*/

    public class MaxSumOfSquareOfElements
    {
        private static void Main()
        {
            /*int row = new int();
            row = Input("N");

            int col = new int();
            col = Input("M");*/

            double[,] realMatrix = 
            { 
            { 1, 3, 2, 2, 2, 4 }, 
            { 3, 3, 3, 2, 4, 4 }, 
            { 4, 3, 1, 2, 3, 3 }, 
            { 4, 3, 1, 3, 3, 1 }, 
            { 4, 3, 3, 3, 1, 1 } 
            }; // new double[row, col];
            // MatrixInput(realMatrix);

            int longestElement = LongestElement(realMatrix);
            MatrixPrint(realMatrix, longestElement);

            Console.WriteLine("Max sum of 3x3 block of elements is: {0}", SearchForMaxSum(realMatrix));
        }

        private static int Input(string name = "input")
        {
            // Int value input
            int value = new int();
            int breakCounter = 5;
            do
            {
                Console.Write("Enter value for {0}: ", name);
                string temp = Console.ReadLine();

                // Error and positive check
                if (int.TryParse(temp, out value) && value > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                breakCounter--;
            }
            while (breakCounter > 0);

            return value;
        }

        private static void MatrixInput(double[,] realMatrix)
        {
            // Double array input
            for (int row = 0; row < realMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < realMatrix.GetLength(1); col++)
                {
                    int breakCount = 5;
                    do
                    {
                        Console.Write("Enter value for element [{0},{1}] - ", row + 1, col + 1);
                        string temp = Console.ReadLine();
                        if (double.TryParse(temp, out realMatrix[row, col]))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try again");
                        }

                        breakCount--;
                    }
                    while (breakCount > 0);
                }
            }
        }

        private static int LongestElement(double[,] realMatrix)
        {
            // Finds element max length for better visual performance
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

        private static void MatrixPrint(double[,] realMatrix, int longestElement)
        {
            StringBuilder line = new StringBuilder();

            for (int row = 0; row < realMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < realMatrix.GetLength(1); col++)
                {
                    line.Append(Convert.ToString(realMatrix[row, col]).PadRight(longestElement)).Append(" ");
                }

                Console.WriteLine(line.ToString());
                line.Clear();
            }
        }

        private static double SearchForMaxSum(double[,] realMatrix)
        {
            // Traverse the matrix to call calculating method with starting position
            double maxSum = new double();
            for (int row = 0; row < realMatrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < realMatrix.GetLength(1) - 2; col++)
                {
                    double currentSum = new double();
                    currentSum = SumSquareOfElement(realMatrix, row, col);

                    maxSum = MaxSum(currentSum, maxSum);
                }
            }

            return maxSum;
        }

        private static double SumSquareOfElement(double[,] realMatrix, int currentRow, int currentCol)
        {
            // Calculating method to sum a square of elements
            double currentSum = new double();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    currentSum += realMatrix[currentRow + row, currentCol + col];
                }
            }

            return currentSum;
        }

        private static double MaxSum(double currentSum, double maxSum)
        {
            // Returns maximal of two integers
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }

            return maxSum;
        }
    }
}
