namespace SortWordsFromText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.*/

    public class SortWordsFromText
    {
        private const string SampleText = "Upon the outbreak of World War II the government of the Kingdom of Bulgaria under " +
            "Bogdan Filov declared a position of neutrality being determined to observe it until the end of the war but " +
            "hoping for bloodless territorial gains especially in the lands with a significant Bulgarian population occupied " +
            "by neighbouring countries after the Second Balkan War and World War I But it was clear that the central ";

        private static void Main()
        {
            string inputText = SampleText;
            List<string> result = new List<string>();
            result = inputText.Split(new[] { ' ' }).ToList();
            result.Sort();
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
