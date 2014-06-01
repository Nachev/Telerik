namespace ExtractSentencesContainingWord
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /*Write a program that extracts from a given text all sentences containing given word.*/

    public class ExtractSentencesContainingWord
    {
        private const string SampleText = "We are living in a yellow submarine. I.D. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        private const string WantedWord = "In";

        private static void Main()
        {
            string inputText = SampleText;
            string inputKey = WantedWord;
            string regex = @"(\b[^\s][^\.]{3,}\.)";
            string splitPatttern = @"[\W]";
            MatchCollection match = Regex.Matches(inputText, regex);
            foreach (Match sentence in match)
            {
                string[] words = Regex.Split(sentence.Value, splitPatttern);
                if (words.Contains(inputKey, StringComparer.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
