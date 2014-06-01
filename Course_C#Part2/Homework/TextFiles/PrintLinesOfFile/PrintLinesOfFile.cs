namespace PrintLinesOfFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Program that reads a text file and inserts line numbers in front of each of its lines. 
    /// The result should be written to another text file.
    /// </summary>
    public class PrintLinesOfFile
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Path to result file.
        /// </summary>
        private const string ResultPath = @"..\..\ResultTestFile.tst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string Content = @"Line breaks are also white space characters. Note that although &#x2028; 
and &#x2029; are defined in [ISO10646] to unambiguously separate lines and paragraphs, respectively, these do not
constitute line breaks in HTML, nor does this specification include them in the more general category of white space
characters.

This specification does not indicate the behavior, rendering or otherwise, of space characters other than those 
explicitly identified here as white space characters. For this reason, authors should use appropriate elements and 
styles to achieve visual formatting effects that involve white space, rather than space characters.

For all HTML elements except PRE, sequences of white space separate ""words"" (we use the term ""word"" here to mean
""sequences of non-white space characters""). When formatting text, user agents should identify these words and lay 
them out according to the conventions of the particular written language (script) and target medium.";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            List<string> fileLines = new List<string>();
            string result = string.Empty;

            ManageTestFile();

            ReadFileLinesToStringList(ref fileLines);

            result = AppendLineNumberToAllLines(fileLines);

            WriteStringToFile(result);

            PrintTextFile();
        }

        /// <summary>
        /// Prints text file to Console
        /// </summary>
        private static void PrintTextFile()
        {
            Console.WriteLine(File.ReadAllText(ResultPath));
        }

        /// <summary>
        /// Writes string to file
        /// </summary>
        /// <param name="content">Content to be written</param>
        private static void WriteStringToFile(string content)
        {
            File.WriteAllText(ResultPath, content);
        }

        /// <summary>
        /// Append index to each string in List of strings
        /// </summary>
        /// <param name="fileLines">List of strings containing all lines</param>
        /// <returns>String containing all strings form List</returns>
        private static string AppendLineNumberToAllLines(List<string> fileLines)
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < fileLines.Count; index++)
            {
                result.AppendFormat("Line {0} : {1}", index, fileLines[index]);
                result.AppendLine();
            }

            fileLines.Clear();
            return result.ToString();
        }

        /// <summary>
        /// Read file lines to List of strings
        /// </summary>
        /// <param name="fileLines">List of strings</param>
        private static void ReadFileLinesToStringList(ref List<string> fileLines)
        {
            fileLines = File.ReadAllLines(Path).ToList();
        }

        /// <summary>
        /// If test file do not exists creates it
        /// </summary>
        private static void ManageTestFile()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, Content);
            }
        }
    }
}
