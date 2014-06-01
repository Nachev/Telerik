namespace RemoveOddLinesOfFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class RemoveOddLinesOfFile
    {
        private const string Path = @"..\..\TestFile.tst";
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
            ManageTestFile();

            ReadFileLinesToStringList(ref fileLines);

            AppendEvenLinesToFile(ref fileLines);
        }

        /// <summary>
        /// Append even lines to file.
        /// </summary>
        /// <param name="fileLines">List of strings containing all lines</param>
        private static void AppendEvenLinesToFile(ref List<string> fileLines)
        {             
            using (StreamWriter writer = new StreamWriter(Path))
            {
                for (int index = 0; index < fileLines.Count; index++)
                {
                    if ((index & 1) == 0)
                    {
                        writer.WriteLine(fileLines[index]);
                    }
                }

                writer.Flush();
            }
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
