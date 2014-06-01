namespace ReverseDigits
{
    using System;

    /*Write a method that reverses the digits of given decimal number. Example: 256  652*/

    public class ReverseDigits
    {
        private static void Main()
        {
            Console.Title = "Reverse digits in decimal number";
            Console.Write("Enter number to be reversed: ");
            string input = Console.ReadLine();
            Console.Write("Number {0} ", input);
            input = ReverseDig(input);
            Console.WriteLine("- reversed: {0}", input);
        }

        private static string ReverseDig(string input)
        {
            char[] digits = input.ToCharArray();
            Array.Reverse(digits);
            input = new string(digits);
            return input;
        }
    }
}
