namespace CheckExpressionParenthesis
{
    using System;

    /*Write a program to check if in a given expression the brackets are put correctly.
     * Example of correct expression: ((a+b)/5-d).
     * Example of incorrect expression: )(a+b)). */
    public class CheckExpressionParenthesis
    {
        private const char OpeningBracket = '(';
        private const char ClosingBracket = ')';

        private static void Main()
        {
            string sample = "((a+b)/5-d)";
            // string sample = ")(a+b))";
            bool isEqual = new bool();

            isEqual = EvaluateBracketsInExpression(sample, isEqual);

            PrintResult(sample, isEqual);
        }

        private static void PrintResult(string sample, bool isEqual)
        {
            if (isEqual)
            {
                Console.WriteLine("In the expression {0} all brackets are placed correctly.", sample);
            }
            else
            {
                Console.WriteLine("In the expression {0} brackets are not placed correctly.", sample);
            }
        }

        private static bool EvaluateBracketsInExpression(string sample, bool isEqual)
        {
            // Check orientation of the first bracket.
            if (sample.IndexOf(ClosingBracket) < sample.IndexOf(OpeningBracket))
            {
                isEqual = false;
            }
            else
            {
                isEqual = CheckEqualityOfBrackets(sample);
            }

            return isEqual;
        }

        private static bool CheckEqualityOfBrackets(string sample)
        {
            int equalCount = 0;

            // Check if opening brackets are equl to closing ones.
            foreach (var element in sample)
            {
                if (element == OpeningBracket)
                {
                    equalCount++;
                }
                else if (element == ClosingBracket)
                {
                    equalCount--;
                }
            }

            if (equalCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
