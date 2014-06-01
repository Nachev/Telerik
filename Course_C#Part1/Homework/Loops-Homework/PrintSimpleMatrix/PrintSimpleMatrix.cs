namespace PrintSimpleMatrix
{
    using System;

    /*Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix
     1 2 3
     2 3 4
     3 4 5*/

    public class PrintSimpleMatrix
    {
        public static void Main()
        {
            // Input loop with correct value check
            int matrixSize = new int();
            int breakCount = 10;
            do
            {
                Console.Write("Enter N(Best visual performance with values up to 30): ");
                if (int.TryParse(Console.ReadLine(), out matrixSize) && matrixSize > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                breakCount--;
            }
            while (breakCount > 0);

            // Print the matrix
            for (int countColumns = 0; countColumns < matrixSize; countColumns++)
            {
                for (int countRows = 1; countRows <= matrixSize; countRows++)
                {
                    Console.Write("{0,3}", countRows + countColumns);
                }

                Console.WriteLine();
            }
        }
    }
}
