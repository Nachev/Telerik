namespace TrailingZeroesInFactorial
{
    using System;
    using System.Numerics;

    /*Write a program that calculates for given N how many trailing zeros present at the end of the number N!*/

    public class TrailingZeroesInFactorial
    {
        public static void Main()
        {
            Console.Title = "Calculates trailing zeroes in factorial";

            // Input block with error check
            int factArg = new int();
            int breakCount = 10;
            do
            {
                Console.Write("Enter N: ");
                if (int.TryParse(Console.ReadLine(), out factArg))
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

            int counter = new int();

            // BigInteger could be removed, if there is no need to print the final factorial
            BigInteger factorial = 1;

            // External loop calculates the factorial
            while (factArg > 0)
            {
                // For the purpouses of the exercise there is no need to calculate the factorial
                factorial *= factArg;

                // Counts factorial elements divisible by five
                if (factArg % 5 == 0)
                {
                    int temp = factArg;

                    // Checks if current element is divisible by five more than once
                    while (temp > 0)
                    {
                        if (temp % 5 == 0)
                        {
                            counter++;
                        }

                        temp /= 5;
                    }
                }

                factArg--;
            }

            if (factorial.ToString().Length > Console.WindowWidth - 45)
            {
                Console.WriteLine("There are {0} trailing zeroes", counter);
            }
            else
            {
                Console.WriteLine("Factorial result is {0}, with {1} trailing zeroes", factorial, counter);
            }
        }
    }
}
