namespace WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /*Write a program that reads a string from the console and lists all different words 
     * in the string along with information how many times each word is found.*/

    public class WordsCounter
    {
        private static void Main()
        {
            string inputText = StringInput();
            Dictionary<string, int> diffWords = new Dictionary<string, int>();
            string regex = @"\s+|\,\s*|""\s*|'\s*|\;\s*|\:\s*|\-\s*|\!\s*|\?\s*|\.\s*|\(\s*|\)\s*|\<\s*|\>\s*";
            string[] allWords = Regex.Split(inputText, regex);
            diffWords = CountDifferentLetters(allWords);
            PrintResult(diffWords);
        }

        private static Dictionary<string, int> CountDifferentLetters(string[] words)
        {
            Dictionary<string, int> diffWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (IsItWord(word) && word != string.Empty)
                {
                    if (diffWords.ContainsKey(word))
                    {
                        diffWords[word]++;
                    }
                    else
                    {
                        diffWords.Add(word, 1);
                    }
                }
            }

            return diffWords;
        }

        private static string StringInput()
        {
            Console.Write("Enter string to be traversed\n-> ");
            string inputText = Console.ReadLine();
            return inputText;
        }

        private static void PrintResult(Dictionary<string, int> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine("Word {0} - found {1} time{2}", word.Key, word.Value, word.Value > 1 ? "s" : string.Empty);
            }
        }

        private static bool IsItWord(string input)
        {
            foreach (char element in input)
            {
                if (!char.IsLetter(element) || char.IsWhiteSpace(element))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
