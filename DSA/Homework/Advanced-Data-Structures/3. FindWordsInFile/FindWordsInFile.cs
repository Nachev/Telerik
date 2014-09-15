namespace FindWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FindWordsInFile
    {
        public static void Main(string[] args)
        {
            Trie<char, int> trie = new Trie<char, int>();

            string wordsFileName = "words.txt";
            List<string> wordsList = new List<string>();
            using (var sr = new StreamReader(wordsFileName))
            {
                do
                {
                    string line = sr.ReadLine();
                    if (!trie.ContainsKey(line))
                    {
                        trie.Add(line, 0);
                    }

                    wordsList.Add(line);
                } 
                while (!sr.EndOfStream);
            }

            string textFileName = "text.txt";
            char[] delims = { ' ', '.', '?', ',', '!' };
            using (var sr = new StreamReader(textFileName))
            {
                string text = sr.ReadToEnd();
                string[] words = text.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (trie.ContainsKey(word))
                    {
                        trie[word]++;
                    }
                }
            }

            foreach (var word in wordsList)
            {
                Console.WriteLine("{0} => {1} times", word, trie[word]);
            }
        }
    }
}
