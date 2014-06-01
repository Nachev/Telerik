namespace CalculateArithmeticalExpression
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ShuntingYardAlgorithm
    {
        #region Fields
        private static Stack<string> _pendingTokens;
        private static List<string> _outputTokens;
        private static string[] _tokens;
        #endregion

        //public static void Main()
        //{
        //    var test = new ShuntingYardAlgorithm();
        //    string result = test.Transform("f ( 3 )");
        //    Console.WriteLine(result);
        //}

        public string Transform(string expression)
        {
            Initialize(expression);

            ProcessExpression();

            AppendAllPreviousTokens();

            return ProductResult();
        }

        private string ProductResult()
        {
            StringBuilder result = new StringBuilder();
            foreach (string token in _outputTokens)
            {
                if (result.Length > 0)
                {
                    result.Append(' ');
                }

                result.Append(token);
            }
            
            return result.ToString();
        }

        private static void AppendAllPreviousTokens()
        {
            while (ThereArePreviousTokens())
            {
                AppendPreviousToken();
            }
        }

        private static bool ThereArePreviousTokens()
        {
            return _pendingTokens.Count > 0;
        }

        private static void AppendPreviousToken()
        {
            if (ThereArePreviousTokens())
            {
                AppendToken(_pendingTokens.Pop());
            }
        }

        private static void Initialize(string expression)
        {
            _pendingTokens = new Stack<string>();
            _outputTokens = new List<string>();
            _tokens = (expression ?? string.Empty).Split(' ');
        }

        private void ProcessExpression()
        {
            foreach (string currentToken in _tokens)
            {
                if (IsNumber(currentToken))
                {
                    AppendToken(currentToken);
                }
                else if (IsOpenParenthesis(currentToken))
                {
                    HandleOpenParenthesis(currentToken);
                }
                else if (IsCloseParenthesis(currentToken))
                {
                    HandleCloseParenthesis(currentToken);
                }
                else if(IsParameterSeparator(currentToken))
                {
                    HandleParameterSeparator(currentToken);
                }
                else
                {
                    HandleOperators(currentToken);
                }
            }
        }

        private void HandleParameterSeparator(string currentToken)
        {
            HandleOperatorsInParenthesis();
        }

        private bool IsParameterSeparator(string currentToken)
        {
            return ",".Equals(currentToken);
        }

        private bool IsOpenParenthesis(string currentToken)
        {
            return "(".Equals(currentToken);
        }

        private void HandleOpenParenthesis(string currentToken)
        {
            _pendingTokens.Push("(");
        }

        private bool PreviousTokenIsFunctionName()
        {
            return _pendingTokens.Count > 0 && Regex.IsMatch(_pendingTokens.Peek(), @"\w+");
        }

        private bool IsCloseParenthesis(string currentToken)
        {
            return ")".Equals(currentToken);
        }

        private void HandleCloseParenthesis(string currentToken)
        {
            HandleOperatorsInParenthesis();
            RemoveOpenParenthesis();
            if (PreviousTokenIsFunctionName())
            {
                AppendToken(_pendingTokens.Pop() + "()");
            }
        }

        private static void HandleOperatorsInParenthesis()
        {
            while (!_pendingTokens.Peek().Equals("("))
            {
                AppendPreviousToken();
            }
        }

        private static void RemoveOpenParenthesis()
        {
            _pendingTokens.Pop();
        }

        private static void HandleOperators(string operatorToken)
        {
            while (PreviousExecutedBeforeCurrent(operatorToken))
            {
                AppendPreviousToken();
            }

            _pendingTokens.Push(operatorToken);
        }

        private static bool PreviousExecutedBeforeCurrent(string currentToken)
        {
            if (ThereArePreviousTokens())
            {
                int previousPrecedence = CalcPrecedence(_pendingTokens.Peek());
                int currentPrecedence = CalcPrecedence(currentToken);

                return previousPrecedence >= currentPrecedence;
            }

            return false;
        }

        private static int CalcPrecedence(string token)
        {
            switch (token)
            {
                case "*":
                case "/":
                    return 5;
                case "+":
                case "-":
                    return 4;
                case "=":
                    return 2;
                case "(":
                case ")":
                    return -1;
                default:
                    return 1;
            }
        }

        private static void AppendToken(string token)
        {
            _outputTokens.Add(token);
        }

        private bool IsNumber(string token)
        {
            bool isNumber = new bool();
            isNumber = Regex.IsMatch(token, @"(\d+|\d+\.\d+)");
            return isNumber;
        }
    }
}

