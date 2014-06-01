namespace SolveQuadraticEquasion
{
    using System;

/* Write a program that reads the coefficients a, b and c of a quadratic equation 
 * ax2+bx+c=0 and solves it (prints its real roots). */

    public class SolveQuadraticEquation
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For correct print of superscript two

            // Input cycle with error check
            int insaneCounter = 10;
            double coefficientA = new double();
            do
            {
                Console.Write("Enter a = ");
                if (double.TryParse(Console.ReadLine(), out coefficientA))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                insaneCounter--;
            } 
            while (insaneCounter > 0);

            // Input cycle with error check
            insaneCounter = 10;
            double coefficientB = new double();
            do
            {
                Console.Write("Enter b = ");
                if (double.TryParse(Console.ReadLine(), out coefficientB))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                insaneCounter--;
            } 
            while (insaneCounter > 0);

            // Input cycle with error check
            insaneCounter = 10;
            double coefficientC = new double();
            do
            {
                Console.Write("Enter c = ");
                if (double.TryParse(Console.ReadLine(), out coefficientC))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                insaneCounter--;
            } 
            while (insaneCounter > 0);

            // Print the equasion
            /*double posValue = 1234;
            double negValue = -1234;
            double zeroValue = 0;

            string fmt = "+ ##; - ##; + 0";

            Console.WriteLine("value is positive : " + posValue.ToString(fmt));
            Console.WriteLine();

            Console.WriteLine("value is negative : " + negValue.ToString(fmt));
            Console.WriteLine();

            Console.WriteLine("value is Zero : " + zeroValue.ToString(fmt));
            Console.WriteLine();*/

            string format = "+ ##;- ##;+ 0";
            Console.WriteLine("{0}x{3} {1}x {2} = 0", coefficientA, coefficientB.ToString(format), coefficientC.ToString(format), '\u00B2');
            double discriminant = (coefficientB * coefficientB) - (4 * coefficientA * coefficientC);
            if (discriminant < 0)
            {
                Console.WriteLine("There are no real roots");
            }
            else
            {
                double x1 = ((-1 * coefficientB) - Math.Sqrt(discriminant)) / (2 * coefficientA);
                double x2 = ((-1 * coefficientB) + Math.Sqrt(discriminant)) / (2 * coefficientA);
                Console.WriteLine("x1 = {0:0.00}, x2 = {1:0.00}", x1, x2);
            }
        }
    }
}
