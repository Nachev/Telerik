namespace Palindromes
{
    using System;
    using System.Text.RegularExpressions;

    /*Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".*/

    public class Palindromes
    {
        private const string SampleText = " Palindrome 1: civic, Palindrome 2: Dewed, Palindrome 3: deified, Palindrome 4: dad " +
            "Palindrome 5: mom, Palindrome 6: devoved, Palindrome 7: Hannah, Palindrome 8: peeweep, Palindrome 9: repaper, " +
            "Palindrome 10: kayak, Palindrome 11: minim, Palindrome 12: radar, Palindrome 13: murdrum," +
            " Palindrome 14: Malayalam, Palindrome 15: madam";

        private static void Main()
        {
            string inputText = SampleText;
            string regex = @"\s+|\,\s*|""\s*|'\s*|\;\s*|\:\s*|\-\s*|!\s*|\?\s*|\.\s*|\(\s*|\)\s*|\<\s*|\>\s*";
            string[] splittedText = Regex.Split(inputText, regex);
            int count = 1;
            foreach(string match in splittedText)
            {
                if (match.Length > 2 && match.ToLower() == ReverseString(match).ToLower())
                {
                    Console.WriteLine("Palindrome {0}: {1}", count, match);
                    count++;
                }
            }
        }

        private static string ReverseString(string input)
        {
            char[] reversed = new char[input.Length];
            for (int i = 0, j = reversed.Length - 1; i <= j; i++, j--)
            {
                reversed[i] = input[j];
                reversed[j] = input[i];
            }

            return new string(reversed);
        }
    }
}
