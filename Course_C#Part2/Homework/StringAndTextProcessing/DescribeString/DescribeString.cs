namespace DescribeString
{
    using System;

    /*Describe the strings in C#. What is typical for the string data type? 
     * Describe the most important methods of the String class.*/

    public class DescribeString
    {
        private static void Main()
        {
            Console.WriteLine("String is collection of characters. One of the base C# data types.");
            Console.WriteLine("In search, for example, string can be called like char array.\n");

            Console.WriteLine("String.Concat - mostly used as '+' operand. Concatenates two strings in one.");
            Console.WriteLine("String.Split - splits string on certain criteria");
            Console.WriteLine();

            // Get lenght of the string
            string text = "Some string";
            Console.WriteLine("{0}.Lenght = {1}", text, text.Length);

            // Convert to uppercase.
            text = text.ToUpper();
            Console.WriteLine("ToUpper -> " + text);

            // Convert to lowercase.
            text = text.ToLower();
            Console.WriteLine("ToLower -> " + text);
            Console.WriteLine();

            // Substring -  get sequence of characters from string
            Console.WriteLine("Substring - get sequence of characters from string:");
            string substring = text.Substring(5, 3);
            Console.WriteLine("Substring: {0}", substring);
            Console.WriteLine();

            // Trim() - removes leading or trailing whitespace
            string removeSpace = "  test text in here  ";
            Console.WriteLine("Remove leading or trailing whitespace of /" + removeSpace + "/ -> /" + removeSpace.Trim() + "/");
            Console.WriteLine();

            // Split string
            string stringSample = "This is an example for string.Split";
            Console.WriteLine("Split string by spaces.");
            string[] words = stringSample.Split(' ');
            Console.WriteLine(string.Join("/", words));
            Console.WriteLine();

            // IndexOf - returns index of searched element
            Console.WriteLine("IndexOf method:");
            if (stringSample.IndexOf("example") != -1)
            {
                Console.Write("string contains 'example'");
            }

            Console.WriteLine();

            // Concat 
            string sample = "Sample string";
            Console.WriteLine("Concatenation of strings:");
            sample = string.Concat(sample, " and ", sample);
            Console.WriteLine(sample);
            Console.WriteLine();

            // Replace
            Console.WriteLine("Replace text in string:");
            string replace = stringSample.Replace("This", "That");
            Console.WriteLine(replace);
            Console.WriteLine();

            // Append
            Console.WriteLine("Append the word \"NEW\" to the previous string.");
            sample += " NEW";
            Console.WriteLine(sample);
            Console.WriteLine();

            // Compare
            string first = "First string";
            string second = "Second string";
            Console.WriteLine("Compare strings:");

            // Compare - returns an integer that indicates their relative position in the sort order
            int compare = string.Compare(first, second);
            Console.WriteLine("string.Compare(first, second) - results: " + compare);

            // CompareOrdinal - compares char by char evaluating their int value
            compare = string.CompareOrdinal(second, first);
            Console.WriteLine("string.CompareOrdinal(second, first) - results: " + compare);

            compare = first.CompareTo(second);
            Console.WriteLine("first.CompareTo(second) - results: " + compare);

            compare = second.CompareTo(first);
            Console.WriteLine("second.CompareTo(first) - results: " + compare);
        }
    }
}