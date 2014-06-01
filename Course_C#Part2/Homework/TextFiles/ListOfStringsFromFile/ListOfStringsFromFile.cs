namespace ListOfStringsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Program that reads a text file containing a list of strings, sorts them and saves them to another text file.
    /// </summary>
    public class ListOfStringsFromFile
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
        private const string Content = "Ivan\nPeter\nMaria\nGeorge";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            List<string> fileLines = new List<string>();

            ManageTestFile();

            ReadFileLinesToStringList(ref fileLines);

            fileLines = TrimListOfStrings(fileLines);

            fileLines = SortElementsOfList(fileLines);

            File.WriteAllLines(ResultPath, fileLines);

            Console.WriteLine(File.ReadAllText(ResultPath));
        }

        /// <summary>
        /// Removes white spaces from the beginning and end of string in List.
        /// </summary>
        /// <param name="fileLines">List of strings to be processed.</param>
        /// <returns>Trimmed list of strings.</returns>
        private static List<string> TrimListOfStrings(List<string> fileLines)
        {
            for (int index = 0; index < fileLines.Count; index++)
            {
                fileLines[index] = fileLines[index].Trim();
            }

            return fileLines;
        }

        /// <summary>
        /// Sorts List of strings.
        /// </summary>
        /// <param name="fileLines">List of strings to be sorted.</param>
        /// <returns>Sorted list.</returns>
        private static List<string> SortElementsOfList(List<string> fileLines)
        {
            bool isSorted = new bool();
            while (!isSorted)
            {
                isSorted = true;
                for (int index = 1; index < fileLines.Count; index++)
                {
                    if (fileLines[index - 1].CompareTo(fileLines[index]) > 0)
                    {
                        SwapListElements(ref fileLines, index);
                        isSorted = false;
                    }
                }
            }

            return fileLines;
        }

        /// <summary>
        /// Swaps consequent elements of List of strings.
        /// </summary>
        /// <param name="fileLines">List of strings.</param>
        /// <param name="index">Index of element to be swapped with previous one.</param>
        private static void SwapListElements(ref List<string> fileLines, int index)
        {
            var swap = fileLines[index];
            fileLines[index] = fileLines[index - 1];
            fileLines[index - 1] = swap;
        }

        /// <summary>
        /// If test file do not exists creates it
        /// </summary>
        private static void ManageTestFile()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            
            File.WriteAllText(Path, Content);            
        }

        /// <summary>
        /// Read file lines to List of strings
        /// </summary>
        /// <param name="fileLines">List of strings</param>
        private static void ReadFileLinesToStringList(ref List<string> fileLines)
        {
            fileLines = File.ReadAllLines(Path).ToList();
        }
    }
}
