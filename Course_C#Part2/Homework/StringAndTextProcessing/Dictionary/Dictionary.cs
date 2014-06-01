namespace Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Dictionary
    {
        private const string SampleDictionary = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";
        private const string SampleSearchWord = ".NET";

        private static void Main()
        {
            string inputDictionary = SampleDictionary;
            string searchedWord = SampleSearchWord;
            string[] lines = inputDictionary.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var textLine in lines)
            {
                string[] parts = Regex.Split(textLine, @"\s*[^\w\s]\s+");
                dict.Add(parts[0], parts[1]);
            }

            try
            {
                Console.WriteLine("Word: {0} -> explanation: {1}", searchedWord, dict[searchedWord]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("There is no definition for this word.");
            }
        }
    }
}
