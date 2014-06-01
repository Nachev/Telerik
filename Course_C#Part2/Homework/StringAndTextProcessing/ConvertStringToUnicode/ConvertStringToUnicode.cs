namespace ConvertStringToUnicode
{
    using System;
    using System.Text;

    /*Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.*/

    public class ConvertStringToUnicode
    {
        private const string SampleString = "Hi!";

        private static void Main()
        {
            string inputString = SampleString;
            StringBuilder result = new StringBuilder();
            foreach (char element in inputString)
            {
                result.AppendFormat("\\u{0:X4}", (int)element);
            }

            Console.WriteLine(result);
        }
    }
}
