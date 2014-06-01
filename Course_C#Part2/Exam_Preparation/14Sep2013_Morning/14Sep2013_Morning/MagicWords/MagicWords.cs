namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MagicWords
    {
        private static void Main()
        {
            List<string> words = new List<string>();
            Input(words);
            Reorder(words);
            Print(words);
        }

        private static void Print(List<string> words)
        {
            StringBuilder result = new StringBuilder();
            bool more = true;
            int counter = new int();
            while (more)
            {
                more = false;
                foreach (var word in words)
                {
                    int length = word.Length;
                    if (counter < length)
                    {
                        result.Append(word[counter]);
                        more = true;
                    }
                }

                counter++;
            }

            Console.Write(result.ToString());
        }

        private static void Reorder(List<string> words)
        {
            int length = words.Count;
            for (int count = 0; count < length; count++)
            {
                string temp = words[count];
                int insertIndex = temp.Length % (length + 1);
                words.Insert(insertIndex, temp);
                if (insertIndex < count)
                {
                    words.RemoveAt(count + 1);
                }
                else
                {
                    words.RemoveAt(count);
                }
            }
        }

        private static void Input(List<string> words)
        {
            int wordsCount = int.Parse(Console.ReadLine());
            for (int count = 0; count < wordsCount; count++)
            {
                words.Add(Console.ReadLine());
            }
        }
    }
}
