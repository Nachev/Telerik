namespace MatrixNxN
{
    using System;
    using System.Collections;
    using System.Text;

    /*Write a program that fills and prints a matrix of size (n, n)*/

    public class MatrixNxN
    {
        public static void Main()
        {
            // Input 
            int length = new int();
            length = LengthInput(length);

            int[,] multiArr = new int[length, length];

            Console.WriteLine("A:");
            StraigthColByCol(multiArr);
            Console.WriteLine("\nB:");
            SnakeFill(multiArr);
            Console.WriteLine("\nC:");
            DiagonalFill(multiArr);
            Console.WriteLine("\nD*:");
            SpiralFill(multiArr, length);
        }

        private static int LengthInput(int length)
        {
            do
            {
                Console.Write("Enter matrix size: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out length) && length > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
            }
            while (true);

            return length;
        }

        private static void StraigthColByCol(int[,] mulitArr)
        {
            // A
            int length = mulitArr.GetLength(1);
            int counter = 1;

            for (int col = 0; col < length; col++)
            {
                for (int row = 0; row < length; row++)
                {
                    mulitArr[col, row] = counter;
                    counter++;
                }
            }
            
            Print(mulitArr);
        }

        private static void SnakeFill(int[,] multiArr)
        {
            // B
            int length = multiArr.GetLength(1);
            int counter = new int();

            for (int col = 0; col < length; col++)
            {
                if (col % 2 == 0)
                {
                    // Even columns are traversed descending
                    for (int rowDown = 0; rowDown < length; rowDown++)
                    {
                        counter++;
                        multiArr[col, rowDown] = counter;
                    }
                }
                else
                {
                    // Odd coumns are traversed ascending
                    for (int rowUp = length - 1; rowUp >= 0; rowUp--)
                    {
                        counter++;
                        multiArr[col, rowUp] = counter;
                    }
                }
            }

            Print(multiArr);
        }

        private static void DiagonalFill(int[,] multiArr)
        {
            // C
            int length = multiArr.GetLength(1);
            int col = new int();
            int row = new int();
            int counter = new int();

            // Left half fill
            int currentInd = length;
            do
            {
                currentInd--;

                for (row = currentInd, col = 0; row < length; row++, col++)
                {
                    counter++;
                    multiArr[col, row] = counter;
                }
            }
            while (currentInd > 0);

            // Rigth half fill
            while (currentInd < length)
            {
                currentInd++;

                for (col = currentInd, row = 0; col < length; col++, row++)
                {
                    counter++;
                    multiArr[col, row] = counter;
                }
            }

            Print(multiArr);
        }

        private static void SpiralFill(int[,] multiArr, int length)
        {
            // D*
            int elementCount = multiArr.Length;
            string direction = "Down";
            int counter = new int();
            int row = new int();
            int col = new int();
            int maxRow = length - 1;
            int maxCol = length - 1;
            int minRow = 0;
            int minCol = 1;

            while (counter < elementCount)
            {
                if (direction == "Down")
                {
                    counter++;
                    multiArr[col, row] = counter;

                    // End of column condition
                    if (row < maxRow)
                    {
                        row++;
                    }
                    else
                    {
                        direction = "Right";
                        maxRow--;
                        col++;
                    }
                }
                else if (direction == "Right")
                {
                    counter++;
                    multiArr[col, row] = counter;

                    if (col < maxCol)
                    {
                        col++;
                    }
                    else
                    {
                        direction = "Up";
                        maxCol--;
                        row--;
                    }
                }
                else if (direction == "Up")
                {
                    counter++;
                    multiArr[col, row] = counter;

                    if (row > minRow)
                    {
                        row--;
                    }
                    else
                    {
                        direction = "Left";
                        minRow++;
                        col--;
                    }
                }
                else if (direction == "Left")
                {
                    counter++;
                    multiArr[col, row] = counter;

                    if (col > minCol)
                    {
                        col--;
                    }
                    else
                    {
                        direction = "Down";
                        minCol++;
                        row++;
                    }
                }
            }

            Print(multiArr);
        }

        private static void Print(int[,] multiArr)
        {
            int length = multiArr.GetLength(1);

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    Console.Write("{0,3} ", multiArr[col, row]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
