namespace MergeTextFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// Program that concatenates two text files into another text file.
    /// </summary>
    public class MergeTextFiles
    {
        /// <summary>
        /// Path to first text file.
        /// </summary>
        private const string Path1 = @"..\..\FirstFile.tst";

        /// <summary>
        /// Path to second text file.
        /// </summary>
        private const string Path2 = @"..\..\SecondFile.tst";

        /// <summary>
        /// Path to result file.
        /// </summary>
        private const string ResultPath = @"..\..\ResultFile.zzt";

        /// <summary>
        /// Content of first text file.
        /// </summary>
        private const string Content1 = @"Line breaks are also white space characters. Note that 
although &#x2028; and &#x2029; are defined in [ISO10646] to unambiguously separate lines and paragraphs,
pectively, these do not constitute line breaks in HTML, nor does this specification include them in the
more general category of white space characters.";

        /// <summary>
        /// Content of second text file.
        /// </summary>
        private const string Content2 = @"This specification does not indicate the behavior, rendering 
or otherwise, of space characters other than those explicitly identified here as white space characters.
For this reason, authors should use appropriate elements and styles to achieve visual formatting effects
that involve white space, rather than space characters.
For all HTML elements except PRE, sequences of white space separate ""words"" (we use the term ""word""
here to mean ""sequences of non-white space characters""). When formatting text, user agents should 
identify these words and lay them out according to the conventions of the particular written language 
(script) and target medium.";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            string firstFile = string.Empty;
            string secondFile = string.Empty;
            string resultFile = string.Empty;

            ManageTestFiles(Path1, Content1);
            ManageTestFiles(Path2, Content2);

            firstFile = ReadFileToString(Path2);
            secondFile = ReadFileToString(Path2);

            resultFile = ConcatFilesContent(firstFile, secondFile, resultFile);

            WriteResultToFile(resultFile);

            PrintResultToConsole();
        }

        /// <summary>
        /// Prints text file content to console.
        /// </summary>
        private static void PrintResultToConsole()
        {
            Console.WriteLine(File.ReadAllText(ResultPath));
        }

        /// <summary>
        /// Concatenate two strings.
        /// </summary>
        /// <param name="firstFile">First file content.</param>
        /// <param name="secondFile">Second file content.</param>
        /// <param name="resultFile">Result file content.</param>
        /// <returns>Concatenated result.</returns>
        private static string ConcatFilesContent(string firstFile, string secondFile, string resultFile)
        {
            resultFile = firstFile + secondFile;
            return resultFile;
        }

        /// <summary>
        /// Writes string to file
        /// </summary>
        /// <param name="resultFile">String to be written to file</param>
        private static void WriteResultToFile(string resultFile)
        {
            using (StreamWriter writer = new StreamWriter(ResultPath))
            {
                writer.Write(resultFile);
            }
        }

        /// <summary>
        /// Reads specified file to string.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>String containing text from file.</returns>
        private static string ReadFileToString(string path)
        {
            string fileContent;
            using (StreamReader reader = new StreamReader(path))
            {
                fileContent = reader.ReadToEnd();
            }

            return fileContent;
        }

        /// <summary>
        /// Creates needed text file if do not exists.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="content">Content to be written.</param>
        private static void ManageTestFiles(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);
            }
        }
    }
}
