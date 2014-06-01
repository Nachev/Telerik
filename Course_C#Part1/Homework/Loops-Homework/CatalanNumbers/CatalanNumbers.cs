namespace CatalanNumbers
{
    using System;

    /*In the combinatorial mathematics, the Catalan numbers are calculated by the following 
     * formula:Cn = (2n)! / (n+1)!*n!
     * Write a program to calculate the Nth Catalan number by given N*/

    public class CatalanNumbers
    {
        // Method for factorial calculation
        public static double Factorial(int nFact)
        {
            if (nFact == 0)
            {
                return 1;
            }
            else
            {
                return nFact * Factorial(nFact - 1);
            }
        }

        public static void Main()
        {
            // Input loop for correct value check
            int numberN = new int();
            int breakCount = 10;
            do
            {
                Console.Write("Enter N: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out numberN))
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

            int counter = numberN;
            numberN = 0;

            // Loop that counts all Catalan numbers to entered  number
            while (counter != numberN)
            {
                // Formula: Cn = (2n)! / (n+1)!*n!
                double tempResult = Factorial(2 * numberN) / (Factorial(numberN + 1) * Factorial(numberN));
                Console.WriteLine(tempResult);
                numberN++;
            }
        }
    }
}
