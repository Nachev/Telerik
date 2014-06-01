namespace BiggerNumberWithoutIf
{
    using System;

    /* Write a program that gets two numbers from the console and prints the greater of them. 
    //Don’t use if statements */

    public class BiggerNumberWithoutIf
    {
        private static void Main()
        {
            double firstNumber = new double();
            byte checkpoint = 10;

            // Input cycle for first number
            do
            {
                Console.Write("Enter first number:");
                if (double.TryParse(Console.ReadLine(), out firstNumber))
                {
                    Console.WriteLine("Correct input :{0}", firstNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input try again");
                }

                checkpoint--;
            }
            while (checkpoint > 0);
            double secondNumber = new double();
            checkpoint = 10;

            // Input cycle for second number
            do
            {
                Console.Write("Enter first number:");
                if (double.TryParse(Console.ReadLine(), out secondNumber))
                {
                    Console.WriteLine("Correct input :{0}", secondNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input try again");
                }

                checkpoint--;
            }
            while (checkpoint > 0);
            double max = new double();

            // If firstNumber + secondNumber + absolute (firstNumber - secondNumber) divided by 2 gives greater number;
            max = (firstNumber + secondNumber + Math.Abs(firstNumber - secondNumber)) / 2;
            Console.WriteLine("Number {0} is bigger", max);

            // Variant 2 math method
            max = Math.Max(firstNumber, secondNumber);
            Console.WriteLine("Number {0} is bigger", max);
        }
    }
}
