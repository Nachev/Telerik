namespace PrintNumbersInRow
{
    using System;

    /* Write a program that reads an integer number n from the console and prints 
    //all the numbers in the interval [1..n], each on a single line. */

    public class PrintNumbersInRow
    {
        private static void Main()
        {
            int insaneCounter = 10;
            int lenght = new int();

            // Input cycle with error check
            do
            {
                Console.Write("Enter n(positive integer): ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out lenght) && lenght > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCounter--;
            }
            while (insaneCounter > 0);

            // Print cycle for 1 to n numbers
            for (int count = 1; count <= lenght; count++)
            {
                Console.WriteLine(count);
            }
        }
    }
}
