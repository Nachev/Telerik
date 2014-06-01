namespace FindAndReplaceSubstringInFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
    /// Ensure it will work with large files (e.g. 100 MB).
    /// </summary>
    public class FindAndReplaceSubstringInFile
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string Content = @"start(Strategic Arms Reduction Treaty) was a bilateral treaty between the United States of America and the Union of Soviet Socialist Republics (USSR) 
on the Reduction and Limitation of Strategic Offensive Arms. The treaty was signed on 31 July 1991 and entered into force on 5 December 1994.[1] The treaty barred its signatories from deploying 
more than 6,000 nuclear warheads atop a total of 1,600 ICBMs, submarine-launched ballistic missiles, and bombers. startnegotiated the largest and most complex arms control treaty in history, 
and its final implementation in late 2001 resulted in the removal of about 80 percent of all strategic nuclear weapons then in existence. Proposed by United States President Ronald Reagan, it 
was renamed START I after negotiations began on the second START treaty.
The START I treaty expired 5 December 2009. On 8 April 2010, the replacement New START treaty was signed in Prague by U.S. President Obama and Russian President Medvedev. Following ratification 
by the U.S. Senate and the Federal Assembly of Russia, it went into force on 26 January 2011. starting fast firestarter";

        /// <summary>
        /// Substring to be replaced.
        /// </summary>
        private const string Wanted = "START";

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
                string searchString = @"\b(start|\w+start\w+|\w+start|start\w+)\b";
                List<string> someLines = new List<string>();
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        File.AppendAllLines(tempPath, someLines);
                        break;
                    }
                    else if (Regex.IsMatch(line, searchString, RegexOptions.IgnoreCase))
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
            int lineIndex = 0;
            while (lineIndex < line.Length)
            {
                int count = CheckForWantedSubstring(line, lineIndex);

                AppendNext(line, newLine, lineIndex, count);

                if (count == Wanted.Length)
                {
                    lineIndex += count;
                }
                else
                {
                    lineIndex++;
                }
            }

            return newLine.ToString();
        }

        /// <summary>
        /// Append next substring to line string.
        /// </summary>
        /// <param name="line">Content of line of file.</param>
        /// <param name="newLine">Content of new line.</param>
        /// <param name="lineIndex">Current index of line string/.</param>
        /// <param name="count">Counted equal chars.</param>
        private static void AppendNext(string line, StringBuilder newLine, int lineIndex, int count)
        {
            if (count == Wanted.Length)
            {
                newLine.Append(Replace);
            }
            else
            {
                newLine.Append(line[lineIndex]);
            }
        }

        /// <summary>
        /// Check for wanted substring.
        /// </summary>
        /// <param name="line">Content of line of file.</param>
        /// <param name="lineIndex">Current reached index.</param>
        /// <returns>Count of equal chars.</returns>
        private static int CheckForWantedSubstring(string line, int lineIndex)
        {
            int count = new int();
            while (line[lineIndex + count] == char.ToLowerInvariant(Wanted[count]) || 
                line[lineIndex + count] == char.ToUpperInvariant(Wanted[count]))
            {
                count++;
                if (lineIndex + count >= line.Length || count >= Wanted.Length)
                {
                    break;
                }
            }

            return count;
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
