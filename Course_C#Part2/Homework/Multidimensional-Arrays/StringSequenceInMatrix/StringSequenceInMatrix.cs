namespace StringSequenceInMatrix
{
    using System;
    using System.Text;

    /*We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements 
     * located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix*/

    public class StringSequenceInMatrix
    {
        private static void Main()
        {
            /*int width = new int();
            int length = new int();*/
            int maxSeqLength = new int();
            int currentSeqLenght = 1;
            int maxElementLength = 1;

            // Width and length input
            /*width = Input("N");
            length = Input("M");*/

            string[,] strMatrix = 
            {
            { "iu", "iu", "iu", "sdf", "dfg", "ghj" }, 
            { "dgo", "dog", "dog", "gol", "goal", "test" }, 
            { "new", "int", "doubel", "equal", "java", "matrix" }, 
            { "new", "new", "new", "new", "nest", "statement" }, 
            { "bow", "strength", "fly", "word", "word", "word" } 
            }; // new string[width, length];

            // String array input
            // MatrixInput(strMatrix);

            // Calc longest element needed for better print
            maxElementLength = LongestElement(strMatrix);

            // Print the array
            Print(strMatrix, maxElementLength);

            // Traverse the matrix by row
            currentSeqLenght = MaxRowSequence(strMatrix);

            // Check max length
            maxSeqLength = MaxInt(maxSeqLength, currentSeqLenght);

            // Traverse the matrix by column
            currentSeqLenght = MaxColSequence(strMatrix);

            // Check max lenght
            maxSeqLength = MaxInt(maxSeqLength, currentSeqLenght);

            // Traverse the matrix by diagonal Down Left to Up Right
            currentSeqLenght = MaxDiagonalSeqDLtoUR(strMatrix);

            // Check max lenght
            maxSeqLength = MaxInt(maxSeqLength, currentSeqLenght);

            // Traverse the matrix by diagonal Down Up Left to Down Right
            currentSeqLenght = MaxDiagonalSeqULtoDR(strMatrix);

            // Check max lenght
            maxSeqLength = MaxInt(maxSeqLength, currentSeqLenght);

            Console.WriteLine("Greatest sequence length of equal elements is: {0}", maxSeqLength);
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

        private static void MatrixInput(string[,] strMatrix)
        {
            // String array input
            for (int row = 0; row < strMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < strMatrix.GetLength(1); col++)
                {
                    Console.Write("Enter value for element [{0},{1}] - ", row + 1, col + 1);
                    string temp = Console.ReadLine();
                    strMatrix[row, col] = temp;
                }
            }
        }

        private static int LongestElement(string[,] strMatrix)
        {
            // Returns the length of longest element 
            int length = new int();
            int maxLengthElement = new int();

            for (int row = 0; row < strMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < strMatrix.GetLength(1); col++)
                {
                    length = strMatrix[row, col].Length;

                    if (length > maxLengthElement)
                    {
                        maxLengthElement = length;
                    }
                }
            }

            return maxLengthElement;
        }

        private static void Print(string[,] strMatrix, int maxElementLength)
        {
            StringBuilder line = new StringBuilder();

            for (int row = 0; row < strMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < strMatrix.GetLength(1); col++)
                {
                   line.Append(Convert.ToString(strMatrix[row, col]).PadRight(maxElementLength)).Append(" ");
                }

                Console.WriteLine(line.ToString());
                line.Clear();
            }
        }

        private static int MaxInt(int max, int chalenger)
        {
            // Returns greater of two integers
            if (chalenger > max)
            {
                max = chalenger;
            }

            return max;
        }

        private static int MaxRowSequence(string[,] strMatrix)
        {
            // Returns max count of equal elements in row
            int counter = 1;
            int maxSeqLength = new int();

            for (int row = 0; row < strMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < strMatrix.GetLength(1); col++)
                {
                    if (strMatrix[row, col] == strMatrix[row, col - 1])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                    }

                    if (counter > maxSeqLength)
                    {
                        maxSeqLength = counter;
                    }
                }
            }

            return maxSeqLength;
        }

        private static int MaxColSequence(string[,] strMatrix)
        {
            // Returns max count of equal elements in column
            int counter = 1;
            int maxSeqLength = new int();

            for (int col = 0; col < strMatrix.GetLength(1); col++)
            {
                for (int row = 1; row < strMatrix.GetLength(0); row++)
                {
                    if (strMatrix[row, col] == strMatrix[row - 1, col])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                    }

                    if (counter > maxSeqLength)
                    {
                        maxSeqLength = counter;
                    }
                }
            }

            return maxSeqLength;
        }

        /*
        * If the matrix is represented like this
        #  #  0  1  2  3
        #  4  5  6  7  #
        8  9 10 11  #  #
         * traverse will be like usual with some changes
        */
        private static int MaxDiagonalSeqDLtoUR(string[,] strMatrix)
        {
            // Returns max count of equal elements in diagonal down left to up right
            int counter = 1;
            int maxSeqLength = new int();
            int rowLength = strMatrix.GetLength(0);
            int colLength = strMatrix.GetLength(1);

            // To traverse all columns, index have to start form 1 - row
            for (int extIndex = 1 - rowLength; extIndex < colLength; extIndex++)
            {
                // Start from 1 because previous element is compared
                for (int intIndex = 1; intIndex < rowLength; intIndex++) 
                {
                    // Check if current indexes are in matrix index borders
                    if ((extIndex + intIndex) >= 1 && (extIndex + intIndex) < colLength) 
                    {
                        // Console.Write(strMatrix[intIndex, intIndex + extIndex]);

                        // Check if current element is equal to the previous one
                        if (strMatrix[intIndex, intIndex + extIndex] == strMatrix[intIndex - 1, intIndex + extIndex - 1])
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 1;
                        }

                        if (counter > maxSeqLength)
                        {
                            maxSeqLength = counter;
                        }
                    }
                }
            }

            return maxSeqLength;
        }

        /*
        * Opposite to the upper method
        0  1  2  3  #  #
        #  4  5  6  7  #
        #  #  8  9 10 11
        */
        private static int MaxDiagonalSeqULtoDR(string[,] strMatrix)
        {
            // Returns max count of equal elements in diagonal up left to down right
            int counter = 1;
            int maxSeqLength = new int();
            int rowLength = strMatrix.GetLength(0);
            int colLength = strMatrix.GetLength(1);

            // To traverse all columns, index have to end at col + row - 1
            for (int extIndex = 1; extIndex < colLength + rowLength - 1; extIndex++)
            {
                // Start from 1 because previous element is compared
                for (int intIndex = 1; intIndex < rowLength; intIndex++) 
                {
                    // Check if current indexes are in matrix index borders
                    if ((extIndex - intIndex) >= 0 && (extIndex - intIndex + 1) < colLength) 
                    {
                        // Check if current element is equal to the previous one
                        int coef = intIndex - 1;
                        if (strMatrix[intIndex, extIndex - intIndex] == strMatrix[coef, extIndex - coef])
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 1;
                        }

                        if (counter > maxSeqLength)
                        {
                            maxSeqLength = counter;
                        }
                    }
                }
            }

            return maxSeqLength;
        }
    }
}
