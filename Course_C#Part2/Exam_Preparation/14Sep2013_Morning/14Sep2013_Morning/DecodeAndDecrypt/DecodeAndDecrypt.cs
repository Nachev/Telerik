namespace DecodeAndDecrypt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DecodeAndDecrypt
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            int lengthOfCypher = ExtractNumber(ref input);
            input = Decode(input);
            string cypher = ExtractCypher(input, lengthOfCypher);
            input = input.Substring(0, input.Length - lengthOfCypher);
            string result = Encrypt(input, cypher);
            Console.WriteLine(result);
        }

        private static string Decode(string input)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder number = new StringBuilder();
            for (int index = 0; index < input.Length; index++)
            {
                while (char.IsDigit(input[index]))
                {
                    number.Append(input[index]);
                    index++;
                }

                if (number.Length > 0)
                {
                    result.Append(new string(input[index], int.Parse(number.ToString())));
                    number.Clear();
                }
                else
                {
                    result.Append(input[index]);
                }
            }

            return result.ToString();
        }

        private static string ExtractCypher(string input, int lengthOfCypher)
        {
            StringBuilder result = new StringBuilder();
            int length = input.Length;
            for (int index = length - lengthOfCypher; index < length; index++)
            {
                result.Append(input[index]);
            }

            return result.ToString();
        }

        private static int ExtractNumber(ref string input)
        {
            int result = new int();
            int index = input.Length - 1;
            int power = new int();
            while (char.IsDigit(input[index]))
            {
                result += (input[index] - '0') * (int)Power(10, power++);
                index--;
            }

            input = input.Substring(0, index + 1);
            return result;
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
                        result *= number;
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Overflow in Power method!!" + ex.Message);
                    throw ex;
                }
            }

            return result;
        }

        private static string Encrypt(string input, string cypher)
        {
            int inputLength = input.Length;
            int cypherLenght = cypher.Length;
            StringBuilder result = new StringBuilder(input);
            int length = inputLength > cypherLenght ? inputLength : cypherLenght;
            for (int index = 0; index < length; index++)
            {
                int inputInt = result[index % inputLength] - 'A';
                int cypherInt = cypher[index % cypherLenght] - 'A';
                char nextChar = (char)((inputInt ^ cypherInt) + 'A');
                result[index % inputLength] = nextChar;
            }

            return result.ToString();
        }
    }
}
