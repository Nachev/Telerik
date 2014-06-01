namespace SumOfFractions
{
    using System;

    /* Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ... */

    public class SumOfFractions
    {
        private static void Main()
        {
            int insaneCounter = 10;
            int numberN = new int();

            // Input cycle with check for correct number
            do
            {
                Console.Write("Enter n(positive integer): ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out numberN) && numberN > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                // Ensures the loop is not endless
                insaneCounter--;
            }
            while (insaneCounter > 0);
            double result = new double();
            for (double count = 1.00; count <= numberN; count++)
            {
                if (((count % 2) == 0) || (count == 1))
                {
                    result = result + (1 / count);
                }
                else
                {
                    result = result - (1 / count);
                }
            }

            Console.WriteLine("{0:0.000}", result);
        }
    }
}
