namespace ExtractTextFromXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program that extracts from given XML file all the text without the tags.
    /// </summary>
    public class ExtractTextFromXml
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string Content = @"<breakfast_menu><food><name>Belgian Waffles</name><price>$5.95</price><description>Two of our famous Belgian Waffles with plenty of real maple syrup</description><calories>650</calories></food><food><name>Strawberry Belgian Waffles</name><price>$7.95</price><description>Light Belgian waffles covered with strawberries and whipped cream</description><calories>900</calories></food><food><name>Berry-Berry Belgian Waffles</name><price>$8.95</price><description>Light Belgian waffles covered with an assortment of fresh berries and whipped cream</description><calories>900</calories></food><food><name>French Toast</name><price>$4.50</price><description>Thick slices made from our homemade sourdough bread</description><calories>600</calories></food><food><name>Homestyle Breakfast</name><price>$6.95</price><description>Two eggs, bacon or sausage, toast, and our ever-popular hash browns</description><calories>950</calories></food></breakfast_menu>";

        private static void Main()
        {
            ManageTestFile();

            string fileContent = ReadFileToString();

            List<string> result = new List<string>();

            ProcessString(fileContent, result);

            PrintResult(result);
        }

        private static void ProcessString(string fileContent, List<string> result)
        {
            string pattern = @"(<.*?>)|(.+?(?=<|$))";
            string[] words = Regex.Split(fileContent, pattern);
            ExtractElementsInsideTags(words, result);
        }

        private static void PrintResult(List<string> result)
        {
            Console.WriteLine("Elements inside tags");
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void ExtractElementsInsideTags(string[] words, List<string> result)
        {
            foreach (string item in words)
            {
                if (!(item.Contains('<') || item.Contains('>') || item.Equals(string.Empty)))
                {
                    result.Add(item);
                }
            }
        }

        /// <summary>
        /// Returns file content to string.
        /// </summary>
        /// <returns>File content.</returns>
        private static string ReadFileToString()
        { 
            return File.ReadAllText(Path);
        }

        /// <summary>
        /// If test file exists deletes it and creates it again.
        /// </summary>
        /// <param name="content">Content of file to be written.</param>
        private static void ManageTestFile()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            File.WriteAllText(Path, Content);
        }
    }
}
