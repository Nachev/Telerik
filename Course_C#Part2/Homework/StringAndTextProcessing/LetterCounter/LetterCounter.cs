namespace LetterCounter
{
    using System;
    using System.Collections.Generic;

    /*Write a program that reads a string from the console and prints all different letters 
     * in the string along with information how many times each letter is found.*/

    public class LetterCounter
    {
        private static void Main()
        {
            string inputText = StringInput();
            Dictionary<char, int> differentCharsContainer = new Dictionary<char, int>();
            differentCharsContainer = CountDifferentLetters(differentCharsContainer, inputText);
            PrintResult(differentCharsContainer);
        }

        private static Dictionary<char, int> CountDifferentLetters(Dictionary<char, int> diffCharsContainer, string inputText)
        {
            foreach (var element in inputText)
            {
                if (char.IsLetter(element))
                {
                    if (diffCharsContainer.ContainsKey(element))
                    {
                        diffCharsContainer[element]++;
                    }
                    else
                    {
                        diffCharsContainer.Add(element, 1);
                    }
                }
            }

            return diffCharsContainer;
        }

        private static string StringInput()
        {
            Console.Write("Enter string to be traversed\n-> ");
            string inputText = Console.ReadLine();
            return inputText;
        }

        private static void PrintResult(Dictionary<char, int> differentCharsContainer)
        {
            foreach (var item in differentCharsContainer)
            {
                Console.WriteLine("Letter {0} - found {1} time{2}", item.Key, item.Value, item.Value > 1 ? "s" : string.Empty);
            }
        }
    }
}
