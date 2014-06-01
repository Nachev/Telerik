namespace Censor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /*We are given a string containing a list of forbidden words and a text containing some of 
     * these words. Write a program that replaces the forbidden words with asterisks.*/

    public class Censor
    {
        private const string SampleText = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        private const string ForbiddenWord = "PHP, CLR, Microsoft";

        private static void Main()
        {
            string inputText = SampleText;
            string inputWords = ForbiddenWord;
            string splitPattern = @"( |\.|\,)";
            string[] sentenceElements = Regex.Split(inputText, splitPattern);
            string[] forbiddenWords = inputWords.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach (var element in sentenceElements)
            {
                if (forbiddenWords.Contains(element))
                {
                    result.Append(new string('*', element.Length));
                }
                else
                {
                    result.Append(element);
                }
            }

            Console.WriteLine(result);
        }
    }
}
