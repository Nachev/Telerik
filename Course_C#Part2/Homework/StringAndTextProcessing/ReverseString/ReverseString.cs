namespace ReverseString
{
    using System;
    using System.Text;

    /*Write a program that reads a string, reverses it and prints the result at the console.
     * Example: "sample"  "elpmas".*/

    public class ReverseString
    {
        private static void Main()
        {
            string sampleStr = "Something to be reversed";
            string reversedStr = string.Empty;
            StringBuilder tempRev = new StringBuilder();
            int length = sampleStr.Length;
            for (int index = 0; index < length; index++)
            {
                tempRev.Append(sampleStr[length - index - 1]);
            }

            reversedStr = tempRev.ToString();
            Console.WriteLine("Sample string - \"{0}\" -> reversed - \"{1}\"", sampleStr, reversedStr);
        }
    }
}
