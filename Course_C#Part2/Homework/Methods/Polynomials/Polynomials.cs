namespace Polynomials
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*11.Write a method that adds two polynomials. Represent them as arrays of their coefficients*/
    /*12.Extend the program to support also subtraction and multiplication of polynomials*/

    public class Polynomials
    {
        private static void Main()
        {
            Console.Title = "Polynomials";
            Console.OutputEncoding = Encoding.Unicode;
            double[] firstPolynomialCoef = PolynomialProcessing("X4-5.23+2x+5.8x4-X2+5"); // Hardcoded input
            PrintPolynomial("First", firstPolynomialCoef);
            double[] secondPolynomialCoef = PolynomialProcessing("-X5-5.23+2.3x+5.8x4-X2-5+3+2x3");
            PrintPolynomial("Second", secondPolynomialCoef);
            double[] addResult = AddPolynomials(firstPolynomialCoef, secondPolynomialCoef);
            PrintPolynomial("Add result", addResult);
            double[] subtractResult = SubtractPolynomials(firstPolynomialCoef, secondPolynomialCoef);
            PrintPolynomial("Subtract result", subtractResult);
            firstPolynomialCoef = PolynomialProcessing("3X2+x+8"); // Hardcoded input
            PrintPolynomial("First", firstPolynomialCoef);
            secondPolynomialCoef = PolynomialProcessing("-2x4-3x3+4x2-x+3");
            PrintPolynomial("Second", secondPolynomialCoef);
            double[] multiplyResult = MultiplyPolynomials(firstPolynomialCoef, secondPolynomialCoef);
            PrintPolynomial("Multiply result", multiplyResult);
        }

        private static double[] AddPolynomials(double[] first, double[] second)
        {
            // Ensures the first is longer
            if (second.Length > first.Length)
            {
                return AddPolynomials(second, first);
            }

            double[] result = new double[first.Length];

            for (int index = 0; index < first.Length; index++)
            {
                if (index < second.Length)
                {
                    result[index] = first[index] + second[index];
                }
                else
                {
                    result[index] = first[index];
                }
            }

            return result;
        }

        private static double[] SubtractPolynomials(double[] first, double[] second, int subtractCoef = 1)
        {
            if (first.Length < second.Length)
            {
                return SubtractPolynomials(second, first, -1);
            }

            double[] result = new double[first.Length];

            for (int index = 0; index < first.Length; index++)
            {
                if (index < second.Length)
                {
                    result[index] = (first[index] - second[index]) * subtractCoef;
                }
                else
                {
                    result[index] = first[index] * subtractCoef;
                }
            }

            return result;
        }

        private static double[] MultiplyPolynomials(double[] firstCoefArr, double[] secondCoefArr)
        {
            if (firstCoefArr.Length < secondCoefArr.Length)
            {
                return MultiplyPolynomials(secondCoefArr, firstCoefArr);
            }

            double[] result = new double[firstCoefArr.Length + secondCoefArr.Length];

            for (int firstIndex = 0; firstIndex < firstCoefArr.Length; firstIndex++)
            {
                for (int secondIndex = 0; secondIndex < secondCoefArr.Length; secondIndex++)
                {
                    result[firstIndex + secondIndex] += firstCoefArr[firstIndex] * secondCoefArr[secondIndex];
                }
            }

            return result;
        }

        private static double[] PolynomialProcessing(string input)
        {
            // string input = PolynomialInput();
            input = ConvertInputString(input);
            List<double> coefficients = new List<double>();
            List<int> exponent = new List<int>();
            ExtractElements(input, coefficients, exponent);
            double[] polynomialCoef = CombineEqualPowers(coefficients, exponent);
            return polynomialCoef;
        }

        private static string PolynomialInput()
        {
            Console.WriteLine("Enter polynomial. Example 5x4-x2+5 for 5x\u2074 - x\u00b2 + 5");
            string input = Console.ReadLine();
            return input;
        }

        // Converts input string adding missing elements
        private static string ConvertInputString(string input)
        {
            input = input.Trim().ToLower();
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < input.Length; index++)
            {
                if (index == 0)
                {
                    if (input[index] == 'x')
                    {
                        result.Append(1);
                    }
                }
                else
                {
                    if ((input[index - 1] == '-' || input[index - 1] == '+') && input[index] == 'x')
                    {
                        result.Append(1);
                    }

                    if (input[index - 1] == 'x' && (input[index] == '+' || input[index] == '-'))
                    {
                        result.Append(1);
                    }

                    if (input[index] == '+' || input[index] == '-' || index == input.Length - 1)
                    {
                        bool isSingleEl = true;
                        isSingleEl = CheckForSingle(input, index, isSingleEl);

                        if (isSingleEl)
                        {
                            if (index == input.Length - 1)
                            {
                                result.Append(input[index]);
                                result.Append("x0");
                                continue;
                            }
                            else
                            {
                                result.Append("x0");
                            }
                        }
                    }
                }

                result.Append(input[index]);
            }

            return result.ToString();
        }

        // Check if current element is free member
        private static bool CheckForSingle(string input, int index, bool isSingleEl)
        {
            for (int count = index - 1; count >= 0; count--)
            {
                if (char.IsDigit(input[count]) || input[count] == '.')
                {
                    continue;
                }
                else if (input[count] == '+' || input[count] == '-')
                {
                    break;
                }
                else
                {
                    isSingleEl = false;
                }
            }

            return isSingleEl;
        }

        // Extracts coefficients and exponents from polynomial string
        private static void ExtractElements(string input, List<double> coefficient, List<int> exponent)
        {
            int length = input.Length;
            bool flagCoef = true;
            for (int count = 0; count < length;)
            {
                if (flagCoef)
                {
                    count = ExtractCoefficient(input, coefficient, length, count);

                    flagCoef = false;
                }
                else
                {
                    count = ExtractExponent(input, exponent, length, count);

                    flagCoef = true;
                }
            }
        }

        private static int ExtractExponent(string input, List<int> exponent, int length, int count)
        {
            StringBuilder element = new StringBuilder();
            while (count < length && (input[count] != '+' && input[count] != '-'))
            {
                element.Append(input[count]);
                count++;
            }

            int temp = int.Parse(element.ToString());
            exponent.Add(temp);
            element.Clear();
            return count;
        }

        private static int ExtractCoefficient(string input, List<double> coefficient, int length, int count)
        {
            StringBuilder element = new StringBuilder();
            while (count < length && input[count] != 'x')
            {
                element.Append(input[count]);
                count++;
            }

            double temp = double.Parse(element.ToString());
            coefficient.Add(temp);
            count++; // To miss the letter X
            return count;
        }

        private static int FindMaxExponent(List<int> exponents)
        {
            int max = int.MinValue;
            foreach (var exponent in exponents)
            {
                if (exponent > max)
                {
                    max = exponent;
                }
            }

            return max;
        }

        // Simplifies the polynomial combining elements with equal exponents 
        private static double[] CombineEqualPowers(List<double> coefficients, List<int> exponent)
        {
            int arrLength = FindMaxExponent(exponent);
            double[] result = new double[arrLength + 1];
            for (int index = 0; index < coefficients.Count; index++)
            {
                double temp = new double();
                temp = coefficients[index];
                result[exponent[index]] += temp;
            }

            return result;
        }

        private static void PrintPolynomial(string name, double[] coefficient)
        {
            string[] superscriptDigits =
            {
    "\u2070", "\u00b9", "\u00b2", "\u00b3", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079"
            }; // Contains supperscript digits 0-9
            StringBuilder result = new StringBuilder();

            for (int index = coefficient.Length - 1; index >= 0; index--)
            {
                if (coefficient[index] != 0)
                {
                    if ((index != coefficient.Length - 1) && coefficient[index] > 0)
                    {
                        result.Append('+');
                    }

                    if (index == 0)
                    {
                        result.Append(coefficient[index]);
                    }
                    else if (index == 1)
                    {
                        result.Append(coefficient[index]).Append('x');
                    }
                    else if (index < 10)
                    {
                        result.Append(coefficient[index]).Append('x').Append(superscriptDigits[index]);
                    }
                    else
                    {
                        result.Append(coefficient[index]).Append('x');
                        int expLength = DigitCount(index);
                        while (expLength > 0)
                        {
                            expLength--;
                            int denumerator = Power(10, expLength);
                            int currentDigit = index / denumerator; // Takes first left digit
                            result.Append(superscriptDigits[currentDigit]);
                            index %= denumerator;
                        }
                    }
                }
            }

            Console.WriteLine("{0} polynomial is {1}", name, result.ToString());
        }

        // Counts digits of integer number
        private static int DigitCount(int number)
        {
            if (number < 0)
            {
                number *= -1;
            }

            int length = 1;
            while ((number /= 10) >= 1)
            {
                length++;
            }

            return length;
        }

        // Power calculator
        private static int Power(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            power -= 1;
            while (power > 0)
            {
                number *= number;
                power--;
            }

            return number;
        }
    }
}
