namespace SaluteYou
{
    using System;

    /*Write a method that asks the user for his name and prints “Hello, <name>” 
     * (for example, “Hello, Peter!”). Write a program to test this method*/
    
    public class Greeting
    {
        private static void Main()
        {
            Console.Title = "Greetign program";

            AskNameAndSalute();
        }

        private static void AskNameAndSalute()
        {
            // Ask for name input
            Console.Write("Enter your name: ");

            // Name input
            string name = Console.ReadLine();

            // Capitalize first letter
            name = CapitalizeFirstLetter(name);

            // Print greeting
            Console.WriteLine("Hello {0}!", name);
        }

        private static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Next time enter something!");
            }

            char[] chArr = input.ToCharArray();
            chArr[0] = char.ToUpperInvariant(chArr[0]);

            return new string(chArr);
        }
    }
}
