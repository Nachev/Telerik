namespace BonusScoresDependOnDigit
{
    using System;

    /* Write a program that applies bonus scores to given scores in the range [1..9]. 
    The program reads a digit as an input. If the digit is between 1 and 3, the program 
    multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 
    7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, the program must report an error.
    Use a switch statement and at the end print the calculated new value in the console.*/

    public class BonusScoresDependsOnDigit
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int digit = new int();

            // Test for error
            bool test = !int.TryParse(input, out digit);
            if (test)
            {
                Console.WriteLine("Error");
                return;
            }
            else if ((digit / 10) != 0 || digit < 1)
            {
                Console.WriteLine("Error");
                return;
            }

            // Switch through cases
            switch (digit)
            {
                case 1:
                case 2:
                case 3:
                    digit *= 10;
                    break;
                case 4:
                case 5:
                case 6:
                    digit *= 100;
                    break;
                case 7:
                case 8:
                case 9:
                    digit *= 1000;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            // Print the result
            Console.WriteLine(digit);
        }
    }
}
