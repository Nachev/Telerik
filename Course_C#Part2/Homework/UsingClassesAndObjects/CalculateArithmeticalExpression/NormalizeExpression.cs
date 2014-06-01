namespace CalculateArithmeticalExpression
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class NormalizeExpression
    {
        public static void Main()
        {
            var test = new NormalizeExpression();
            var testString = test.Process("3 + (5-4)*1");
            Console.WriteLine(testString);
        }

        public string Process(string inputExpression)
        {
            string convertedExpression = RemoveAllEmptySpaces(inputExpression);
            convertedExpression = AddSpacesBetweenElements(convertedExpression);
            return convertedExpression;
        }

        private static string RemoveAllEmptySpaces(string inputExpression)
        {
            var result = new StringBuilder();
            foreach (char element in inputExpression)
            {
                if (element != ' ')
                {
                    result.Append(element);
                }
            }
            return result.ToString();
        }

        private static string AddSpacesBetweenElements(string inputExpression)
        {
            var result = new StringBuilder();
            var element = new StringBuilder();
            int length = inputExpression.Length;
            for (int index = 0; index < length; index++)
            {
                while (index < length && (char.IsDigit(inputExpression[index]) || inputExpression[index] == '.'))
                {
                    element.Append(inputExpression[index]);
                    index++;
                }

                if (element.Length > 0 && Regex.IsMatch(element.ToString(), @"\d+|\d+\.\d+"))
                {
                    result.Append(element).Append(' ');
                    element.Clear();
                    index -= 1;
                }

                while (index < length && char.IsLetter(inputExpression[index]))
                {
                    element.Append(inputExpression[index]);
                    index++;
                }

                if (element.Length > 0 && Regex.IsMatch(element.ToString(), @"\d+|\d+\.\d+"))
                {
                    result.Append(element).Append(' ');
                    element.Clear();
                    index -= 1;
                }

                if (index < length)
                {
                    result.Append(inputExpression[index]).Append(' ');
                }
            }

            AppendElementToResult(result, element);
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        private static void AppendElementToResult(StringBuilder result, StringBuilder element)
        {
            if (element.Length > 0 && Regex.IsMatch(element.ToString(), @"\d+|\d+\.\d+"))
            {
                result.Append(element).Append(' ');
                element.Clear();
            }
        }
    }
}
