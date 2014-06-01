namespace SentenceReverse
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Text.RegularExpressions;

    /*Write a program that reverses the words in given sentence.*/

    public class SentenceReverse
    {
        private const string SampleSentence = "C# is not C++, not PHP and not Delphi!";

        private static void Main()
        {
            string inputSentence = SampleSentence;
            string splitPattern = @"(\s+|\s*\,\s*|\s*\-\s*|\s*\!|\s*\.)";
            string[] elements = Regex.Split(inputSentence, splitPattern);

            Stack words = new Stack();
            Queue separators = new Queue();
            StringBuilder result = new StringBuilder();

            foreach (var element in elements)
            {
                if (Regex.IsMatch(element, splitPattern))
                {
                    separators.Enqueue(element);
                }
                else if (Regex.IsMatch(element, @"\S"))
                {
                    words.Push(element);
                }
            }

            while (words.Count > 0)
            {
                result.Append(words.Pop());
                result.Append(separators.Dequeue());
            }

            Console.WriteLine(result);
        }
    }
}
