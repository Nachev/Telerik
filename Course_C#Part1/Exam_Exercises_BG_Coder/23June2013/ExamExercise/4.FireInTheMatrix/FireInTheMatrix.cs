namespace FireInTheMatrix
{
    using System;

    private class FireInTheMatrix
    {
        private static void Main()
        {
            // N will be a positive integer in the range [4…76] and will always be divisible by 4.
            int columns = int.Parse(Console.ReadLine());
            int coefficent = (columns / 4) * 3;
            int halfColumn = columns / 2;

            // Upper part of Fire
            for (int row = 1, index = halfColumn; row <= halfColumn; row++, index--)
            {
                // Left half
                for (int column = 1; column <= halfColumn; column++)
                {
                    if (column == index)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                // Right half
                for (int column = 1; column <= halfColumn; column++)
                {
                    if (column == row)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                Console.WriteLine();
            }

            // Lower part of fire
            for (int row = halfColumn, index = 1; row < coefficent; row++, index++)
            {
                for (int column = 1; column <= halfColumn; column++)
                {
                    if (column == index)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                for (int column = 1; column <= halfColumn; column++)
                {
                    if (column == (halfColumn - (index - 1)))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                Console.WriteLine();
            }

            // Dashes between fire and torch
            for (int columnDash = 0; columnDash < columns; columnDash++)
            {
                Console.Write('-');
            }

            Console.WriteLine();

            // Torch
            for (int row = 1, index = halfColumn; row <= halfColumn; row++, index--)
            {
                // Left part of torch
                for (int emptyColumn = 1; emptyColumn < row; emptyColumn++)
                {
                    Console.Write('.');
                }

                for (int column = row; column <= halfColumn; column++)
                {
                    Console.Write('\\');
                }

                // Right part of torch
                for (int column = 1; column <= index; column++)
                {
                    Console.Write('/');
                }

                for (int emptyColumn = index; emptyColumn < halfColumn; emptyColumn++)
                {
                    Console.Write('.');
                }

                Console.WriteLine();
            }
        }
    }
}