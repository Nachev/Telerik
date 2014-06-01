namespace ReplaceEqualLetters
{
    using System;
    using System.Text;

    /*Write a program that reads a string from the console and replaces all series of 
     * consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".*/

    public class ReplaceEqualLetters
    {
        private static void Main()
        {
            string inputText = StringInput();
            StringBuilder result = new StringBuilder();
            char previousLetter = char.MinValue;
            foreach (char letter in inputText)
            {
                if (letter != previousLetter)
                {
                    previousLetter = letter;
                    result.Append(letter);
                }
            }

            Console.WriteLine("Result is: " + result.ToString());
        }

        private static string StringInput()
        {
            Console.Write("Enter string to be traversed\n-> ");
            string inputText = Console.ReadLine();
            return inputText;
        }
    }
}
