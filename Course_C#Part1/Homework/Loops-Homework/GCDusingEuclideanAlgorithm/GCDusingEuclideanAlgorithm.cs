namespace GCDusingEuclideanAlgorithm
{
    using System;

    /* Write a program that calculates the greatest common divisor (GCD) of given two numbers. 
     * Use the Euclidean algorithm (find it in Internet)*/

    public class GCDusingEuclideanAlgorithm
    {
        public static void Main()
        {
            // Input block with check for correct input
            int firstNumber = new int();
            do
            {
                Console.Write("Enter first number: ");
                bool check = int.TryParse(Console.ReadLine(), out firstNumber);
                if (check && firstNumber != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }
            }
            while (true);

            // Input block with check for correct input
            int secondNumber = new int();
            do
            {
                Console.Write("Enter second number: ");
                bool check = int.TryParse(Console.ReadLine(), out secondNumber);
                if (check && secondNumber != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }
            }
            while (true);

            // Calculate GCD using Eucludean algorythm
            /* function gcd(a, b)
             *   while b ≠ 0
             *     t := b
             *     b := a mod b
             *     a := t
             * return a */
            while (secondNumber != 0)
            {
                int temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }

            Console.WriteLine(firstNumber);
        }
    }
}
