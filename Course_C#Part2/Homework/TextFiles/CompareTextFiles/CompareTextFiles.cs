namespace CompareTextFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Program that compares two text files line by line and prints the number of lines that are the same and 
    /// the number of lines that are different. Assume the files have equal number of lines.
    /// </summary>
    public class CompareTextFiles
    {
        /// <summary>
        /// Path for first text file.
        /// </summary>
        private const string Path1 = @"..\..\TestFile1.tst";

        /// <summary>
        /// Content of first text file.
        /// </summary>
        private const string Content1 = @"Line breaks are also white space characters. Note that 
although &#x2028; and &#x2029; are defined in [ISO10646] to unambiguously separate lines and paragraphs, 
respectively, these do not constitute line breaks in HTML, nor does this specification include them in 
the more general category of white space characters.";

        /// <summary>
        /// Path to second text file
        /// </summary>
        private const string Path2 = @"..\..\TestFile2.tst";

        /// <summary>
        /// Content of second text file.
        /// </summary>
        private const string Content2 = @"Line breaks are also white space characters. Note that 
although &#x2028; and &#x2029; are defined in [ISO10646] to unambiguously separate lines and paragraphs, 
respectively, these do not constitute line breaks in HTML, nor does this specification include them in 
the more general category of white space characters.";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            List<string> fileLines1 = new List<string>();
            List<string> fileLines2 = new List<string>();

            ManageTestFile(Path1, Content1);
            ManageTestFile(Path2, Content2);

            fileLines1 = ReadFileLinesToStringList(Path1);
            fileLines2 = ReadFileLinesToStringList(Path2);

            int equalsCount = CompareFileLines(fileLines1, fileLines2);

            PrintResult(equalsCount, fileLines1.Count);

            RemoveUnneccessaryFiles(Path1);
            RemoveUnneccessaryFiles(Path1);
        }

        /// <summary>
        /// Deletes specified file
        /// </summary>
        /// <param name="path">Path to file</param>
        private static void RemoveUnneccessaryFiles(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Prints result on console.
        /// </summary>
        /// <param name="equalsCount">Number of equal elements.</param>
        /// <param name="allLinesCount">Number of all elements.</param>
        private static void PrintResult(int equalsCount, int allLinesCount)
        {
            Console.WriteLine("There are {0} number of lines that are the same", equalsCount);
            Console.WriteLine("There sre {0} number of lines that are different", allLinesCount - equalsCount);
        }

        /// <summary>
        /// Compares two files line by line.
        /// </summary>
        /// <param name="fileLines1">First file lines to be compared.</param>
        /// <param name="fileLines2">Second file lines to be compared.</param>
        /// <returns>Number of equal lines.</returns>
        private static int CompareFileLines(List<string> fileLines1, List<string> fileLines2)
        {
            int length1 = fileLines1.Count;
            int length2 = fileLines2.Count;
            int equalsCount = 0;
            for (int index = 0; index < ((length1 < length2) ? length1 : length2); index++)
            {
                if (fileLines1[index].CompareTo(fileLines2[index]) == 0)
                {
                    equalsCount++;
                }
            }

            return equalsCount;
        }

        /// <summary>
        /// Read file lines to List of strings.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>List of strings to contain lines.</returns>
        private static List<string> ReadFileLinesToStringList(string path)
        {
            List<string> fileLines = new List<string>();
            fileLines = File.ReadAllLines(path).ToList();
            return fileLines;
        }

        /// <summary>
        /// If test file do not exists creates it.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="content">Content to be written to file.</param>
        private static void ManageTestFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);
            }
        }
    }
}
