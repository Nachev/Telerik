namespace IntSquareRoot
{
    using System;

    /// <summary>
    /// Program that reads an integer number and calculates and prints its square root. 
    /// If the number is invalid or negative, print "Invalid number". 
    /// In all cases finally prints "Good bye".
    /// </summary>
    public class IntSquareRoot
    {
        /// <summary>
        /// Main method managing exceptions.
        /// </summary>
        private static void Main()
        {
            Console.Title = "Square root calculator.";

            int inputNumber = IntInput();
            try
            {
                SquareRoot(inputNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Entered number is negative");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Entered number is not valid! Not anumber or infinite.");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        /// <summary>
        /// Calculates square root of a specified integer.
        /// </summary>
        /// <param name="inputNumber">Integer number input.</param>
        private static void SquareRoot(int inputNumber)
        {
            double squaredNumber = new double();
            if (inputNumber < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            squaredNumber = Math.Sqrt(inputNumber);
            if (double.IsNaN(squaredNumber) || double.IsPositiveInfinity(squaredNumber))
            {
                throw new ArithmeticException();
            }

            Console.WriteLine("Square root of this number is : {0}", squaredNumber);
        }

        /// <summary>
        /// Input method for integers with correctness check.
        /// </summary>
        /// <returns>Entered via console integer number.</returns>
        private static int IntInput()
        {
            int output = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter integer number : ");
                string tempIn = Console.ReadLine();
                try
                {
                    output = int.Parse(tempIn);
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Wrong input! Number is not in a correct format!");
                }
                catch (OverflowException)
                {
                    Console.Write("Wrong input! Input is too big!");
                }

                if (breakCount > 0)
                {
                    Console.WriteLine(" Try again.");
                }
                else
                {
                    Console.WriteLine(" Error limit reached! Exiting");
                    Environment.Exit(0);
                }

                breakCount--;
            } 
            while (true);

            return output;
        }
    }
}
