namespace MatrixSpiralPrint
{
    using System;

    /* Write a program that reads a positive integer number N (N < 20) from 
    console and outputs in the console the numbers 1 ... N numbers arranged as a spiral */

    public class MatrixSpiralPrint
    {
        public static void Main()
        {
            int coefficentN = new int();
            int breakCount = 10;
            do
            {
                Console.Write("Enter N:");
                if (int.TryParse(Console.ReadLine(), out coefficentN) && coefficentN > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }
            }
            while (breakCount > 0);

            int rowLength = coefficentN - 1;
            int columnLength = coefficentN - 1;
            int spiralLenght = coefficentN * coefficentN;
            int counter = 1;
            int rowIndex = 0;
            int row = 0;
            int column = 0;
            int columnIndex = 0;

            // Double array to store values of the spiral. Could be avoided if the program prints on position
            int[,] spiralArray = new int[coefficentN, coefficentN];

            // Claculate cell values
            while (true)
            {
                // Right 
                for (columnIndex = column; columnIndex <= rowLength; columnIndex++)
                {
                    spiralArray[row, columnIndex] = counter;
                    counter++;
                }

                // End condition
                if (counter > spiralLenght)
                {
                    break;
                }

                row++;

                // Down
                for (rowIndex = row; rowIndex <= columnLength; rowIndex++)
                {
                    spiralArray[rowIndex, rowLength] = counter;
                    counter++;
                }

                // End condition
                if (counter > spiralLenght)
                {
                    break;
                }

                rowLength--;

                // Left
                for (columnIndex = rowLength; columnIndex >= column; columnIndex--)
                {
                    spiralArray[columnLength, columnIndex] = counter;
                    counter++;
                }

                // End condition
                if (counter > spiralLenght)
                {
                    break;
                }

                columnLength--;

                // Up
                for (rowIndex = columnLength; rowIndex >= row; rowIndex--)
                {
                    spiralArray[rowIndex, column] = counter;
                    counter++;
                }

                // End condition
                if (counter > spiralLenght)
                {
                    break;
                }

                column++;
            }

            // Print the result
            for (rowIndex = 0; rowIndex < coefficentN; rowIndex++)
            {
                for (columnIndex = 0; columnIndex < coefficentN; columnIndex++)
                {
                    Console.Write("{0,4}", spiralArray[rowIndex, columnIndex]);
                }

                Console.WriteLine();
            }
        }
    }
}
