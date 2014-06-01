namespace DeleteWordFromFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program that deletes from a text file all words that start with the prefix "test". 
    /// Words contain only the symbols 0...9, a...z, A…Z, _.
    /// </summary>
    public class DeleteWordFromFile
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string Content = @"This is some testText. To test deletion of word with prefix testSomeword from text file.";

        /// <summary>
        /// Substring to be replaced.
        /// </summary>
        private const string Wanted = "test";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            string tempPath = @"..\..\TemporaryTxtFile.tst";
            string backupFile = @"..\..\BackUpFile.tst";
            ManageTestFile(Content);

            ProcessFile(tempPath);

            ReplaceTestFile(tempPath, backupFile);
        }

        /// <summary>
        /// Replaces temporary file with test file.
        /// </summary>
        /// <param name="tempPath">Temporary file path.</param>
        /// <param name="backupFile">BackUp file path.</param>
        private static void ReplaceTestFile(string tempPath, string backupFile)
        {
            File.Replace(tempPath, Path, backupFile);
        }

        /// <summary>
        /// Process files.
        /// </summary>
        /// <param name="tempPath">Temporary file path.</param>
        private static void ProcessFile(string tempPath)
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                List<string> someLines = new List<string>();
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        File.AppendAllLines(tempPath, someLines);
                        break;
                    }
                    else if (line.Contains(Wanted.ToLowerInvariant()) || line.Contains(Wanted.ToUpperInvariant()))
                    {
                        line = CreateNewLine(line);
                    }

                    someLines.Add(line);

                    if (someLines.Count >= 100)
                    {
                        File.AppendAllLines(tempPath, someLines);
                        someLines.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Creates new line with replaced substring
        /// </summary>
        /// <param name="line">Line content to be replaced.</param>
        /// <returns>Content of new line.</returns>
        private static string CreateNewLine(string line)
        {
            StringBuilder newLine = new StringBuilder();
            string[] words = line.Split(' ');
            string pattern = @"\b(test\w+)\b";
            foreach (var word in words)
            {
                if (Regex.IsMatch(word, pattern))
                {
                    newLine.Append(' ');
                }
                else
                {
                    newLine.Append(word).Append(' ');
                }
            }

            return newLine.ToString();
        }

        /// <summary>
        /// If test file exists deletes it and creates it again.
        /// </summary>
        /// <param name="content">Content of file to be written.</param>
        private static void ManageTestFile(string content)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            File.WriteAllText(Path, content);
        }
    }
}
