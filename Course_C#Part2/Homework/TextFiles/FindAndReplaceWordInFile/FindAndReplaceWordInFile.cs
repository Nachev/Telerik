namespace FindAndReplaceWordInFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Program that replaces all occurrences of the word "start" with the word "finish" in a text file.
    /// </summary>
    public class FindAndReplaceWordInFile
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string Content = @"START (Strategic Arms Reduction Treaty) was a bilateral treaty between the United States of America and the Union of Soviet Socialist Republics (USSR) 
on the Reduction and Limitation of Strategic Offensive Arms. The treaty was signed on 31 July 1991 and entered into force on 5 December 1994.[1] The treaty barred its signatories from deploying 
more than 6,000 nuclear warheads atop a total of 1,600 ICBMs, submarine-launched ballistic missiles, and bombers. start negotiated the largest and most complex arms control treaty in history, 
and its final implementation in late 2001 resulted in the removal of about 80 percent of all strategic nuclear weapons then in existence. Proposed by United States President Ronald Reagan, it 
was renamed START I after negotiations began on the second START treaty.
The START I treaty expired 5 December 2009. On 8 April 2010, the replacement New START treaty was signed in Prague by U.S. President Obama and Russian President Medvedev. Following ratification 
by the U.S. Senate and the Federal Assembly of Russia, it went into force on 26 January 2011. starting fast firestarter";

        /// <summary>
        /// Substring to be replaced.
        /// </summary>
        private const string Wanted = "start";

        /// <summary>
        /// Substring to replace with.
        /// </summary>
        private const string Replace = "finish";

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
            foreach (var word in words)
            {
                if (word.Equals(Wanted.ToLowerInvariant()) || word.Equals(Wanted.ToUpperInvariant()))
                {
                    newLine.Append(Replace).Append(' ');
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
