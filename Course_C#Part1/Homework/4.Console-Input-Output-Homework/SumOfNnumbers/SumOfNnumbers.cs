namespace SumOfNnumbers
{
    using System;

    /* Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum */

    public class SumOfNnumbers
    {
        private static void Main()
        {
            int insaneCounter = 10;
            int numberN = new int();
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

                insaneCounter--;
            }
            while (insaneCounter > 0);
            double sum = new double();
            for (int count = 1; count <= numberN; count++)
            {
                double tmpIn = new double();
                insaneCounter = 10;
                do
                {
                    Console.Write("Enter number({0} of {1}):", count, numberN);
                    string temp = Console.ReadLine();
                    if (double.TryParse(temp, out tmpIn))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input for number({0})! Try again", count);
                    }

                    insaneCounter--;
                }
                while (insaneCounter > 0);
                sum += tmpIn;
            }

            Console.WriteLine("The sum of all entered elements is {0}", sum);
        }
    }
}
