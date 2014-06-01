namespace QuadraticEquation
{
    using System;

    /* Write a program that enters the coefficients a, b and c of a quadratic equation
     * a*x2 + b*x + c = 0
     * and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots */

    public class QuadraticEquation
    {
        public static void Main()
        {
            Console.WriteLine("Enter coefficients");
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            double firstCoef = new double();
            int insaneCount = 10;

            // Input cycle for the first double with error check
            do
            {
                Console.Write("Enter first coefficent: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out firstCoef))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            double secondCoef = new double();
            insaneCount = 10;

            // Input cycle for the second double with error check
            do
            {
                Console.Write("Enter second coefficent: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out secondCoef))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            double thirdCoef = new double();
            insaneCount = 10;

            // Input cycle for the third double with error check
            do
            {
                Console.Write("Enter third coefficent: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out thirdCoef))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            // Print the equation
            string firstString = firstCoef.ToString("+ #;- #;0");
            string secondString = secondCoef.ToString("+ #;- #;0");
            string thirdString = thirdCoef.ToString("+ #;- #;0");
            Console.WriteLine("{0}x{1} {2}x {3} = 0", firstString, "\u00B2", secondString, thirdString);

            // Calculate the roots if any
            double discriminant = (secondCoef * secondCoef) - (4 * firstCoef * thirdCoef); // b^2-4*a*c
            if (discriminant == 0)
            {
                Console.WriteLine("x1 = x2 = {0}", (-1 * secondCoef) / (2 * firstCoef)); // -b/2*a
            }
            else if (discriminant > 0)
            {
                Console.Write("x1 = {0}, ", ((-1 * secondCoef) + Math.Sqrt(discriminant)) / (2 * firstCoef)); // -b + D / 2a
                Console.WriteLine(" x2 = {0}", ((-1 * secondCoef) - Math.Sqrt(discriminant)) / (2 * firstCoef)); // -b - D / 2a
            }
            else
            {
                Console.WriteLine("There are no real roots!");
            }
        }
    }
}
