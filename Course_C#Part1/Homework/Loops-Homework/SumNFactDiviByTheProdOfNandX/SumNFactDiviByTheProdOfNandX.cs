namespace SumNFactDiviByTheProdOfNandX
{
    using System;

    /*Write a program that, for a given two integer numbers N and X, 
     * calculates the sum S = 1 + 1!/X + 2!/X2 + … + N!/XN*/

    public class SumNFactDiviByTheProdOfNandX
    {
        public static void Main()
        {
            Console.Title = "Program that calculates the sum S = 1 + 1!/X + 2!/X2 + … + N!/XN";

            // Input block with error check
            int firstIntegerN = new int();
            do
            {
                Console.Write("Enter integer N: ");
                if (int.TryParse(Console.ReadLine(), out firstIntegerN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }
            }
            while (true);

            int secondIntegerX = new int();
            do
            {
                Console.Write("Enter integer X: ");
                if (int.TryParse(Console.ReadLine(), out secondIntegerX))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }
            }
            while (true);

            double sum = 1.00;
            for (int countN = 1; countN <= firstIntegerN; countN++)
            {
                // Calculate the factorial
                double nFactorial = 1.00;
                for (int countFact = 1; countFact <= countN; countFact++)
                {
                    nFactorial *= countFact;
                }

                // Calculate the sum
                sum += nFactorial / (secondIntegerX * countN);
            }

            // Print the result
            Console.WriteLine("S = 1 + 1!/X + 2!/X2 + … + N!/XN = {0:0.000}", sum);
        }
    }
}
