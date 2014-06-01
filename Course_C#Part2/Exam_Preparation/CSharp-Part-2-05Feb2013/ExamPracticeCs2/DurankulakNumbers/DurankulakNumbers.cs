using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] letterDigits = CorrectionInput(input);
            Dictionary<char, int> capitals = new Dictionary<char, int>();
            List<int> resultValue = new List<int>();
            foreach (var number in letterDigits)
            {
                int numberValue = new int();
                for (int index = number.Length - 1; index >= 0; index--)
                {
                    numberValue += EvaluateLetter(number[index]);
                }

                resultValue.Add(numberValue);
            }

            long result = ConvertToBase(resultValue, 168);
            Console.WriteLine(result);
        }

        private static int EvaluateLetter(char letter)
        {
            if (letter.Equals(char.ToUpper(letter)))
            {
            return letter - 'A';
            }
            else
            {
                return (letter - 'a' + 1) * 26;
            }
        }

        private static string[] CorrectionInput(string input)
        {
            input = input.Trim();
            StringBuilder number = new StringBuilder();
            foreach (var element in input)
            {
                if (element != ' ' && element.Equals(char.ToUpper(element)))
                {
                    number.Append(element).Append(' ');
                }
                else
                {
                    number.Append(element);
                }
            }

            return number.ToString().TrimEnd().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private static long ConvertToBase(List<int> inputNumber, int numberBase)
        {
            long numberDecimal = new long();
            for (int index = inputNumber.Count - 1, power = 0; index >= 0; index--, power++)
            {
                int temp = inputNumber[index];
                numberDecimal += temp * Power(numberBase, power);
            }

            return numberDecimal;
        }

        private static long Power(int number, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }
            else if (exponent == 1)
            {
                return number;
            }

            long result = number;
            for (int count = 1; count < exponent; count++)
            {
                // Try-catch block for integer overflow
                try
                {
                    checked
                    {
                        result *= (long)number;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow in Power method!!");
                    Environment.Exit(0);
                }
            }

            return result;
        }
    }
}
