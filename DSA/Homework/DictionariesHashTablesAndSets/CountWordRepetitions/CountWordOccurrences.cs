namespace CountWordRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    /*Write a program that counts how many times each 
    word from given text file words.txt appears in it. 
    The character casing differences should be ignored. 
    The result words should be ordered by their number 
    of occurrences in the text. Example:
    is  2
    the  2
    this  3
    text  6*/
    internal class CountWordOccurrences
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter comma separated array: ");
            string input = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?"; // Console.ReadLine();
            string splitString = @"\s*[\,\-\–\!\?\:\;\.]\s*|\s+";
            var splittedInput = Regex.Split(input, splitString);
            var orderedElements = new OrderedMultiDictionary<int, string>(true);
            var elementsCount = new Dictionary<string, int>(splittedInput.Length);
            for (int index = 0; index < splittedInput.Length; index++)
            {
                string arrayElement = splittedInput[index].ToLowerInvariant();
                if (string.IsNullOrEmpty(arrayElement))
                {
                    continue;
                }

                if (elementsCount.ContainsKey(arrayElement))
                {
                    elementsCount[arrayElement]++;

                }
                else
                {
                    elementsCount.Add(arrayElement, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Input: {0}", string.Join(", ", splittedInput));
            Console.WriteLine(new string('-', 48));
            
            foreach (var pair in elementsCount)
            {
                Console.WriteLine("Value: {0}, count: {1}", pair.Key, pair.Value);
            }
        }
    }
}