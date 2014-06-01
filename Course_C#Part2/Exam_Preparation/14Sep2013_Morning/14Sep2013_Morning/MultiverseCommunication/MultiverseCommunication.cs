namespace MultiverseCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MultiverseCommunication
    {
        private static Dictionary<string, char> dict = new Dictionary<string, char>() 
        { 
        { "CHU", '0' },
        { "TEL", '1' },
        { "OFT", '2' },
        { "IVA", '3' },
        { "EMY", '4' },
        { "VNB", '5' },
        { "POQ", '6' },
        { "ERI", '7' },
        { "CAD", '8' },
        { "K-A", '9' },
        { "IIA", 'A' },
        { "YLO", 'B' },
        { "PLA", 'C' },
        };

        private static void Main()
        {
            Console.WriteLine(NumeralBaseConverter());            
        }

        private static string Input()
        {
            // IF THIS IS SLOW USE REGEX
            string temp = Console.ReadLine();            
            StringBuilder result = new StringBuilder();
            for (int count = 0; count < temp.Length; count += 3)
            {
                result.Append(dict[temp.Substring(count, 3)]);
            }

            return result.ToString();
        }

        private static long NumeralBaseConverter()
        {
            int numberBase = 13;
            string inputNumber = Input();
            long numberDec = ConvertToDecimal(inputNumber, numberBase);
            return numberDec;
        }

        /// <summary>
        /// Returns integer decimal number converted from specified string number in specified base.
        /// </summary>
        /// <param name="inputNumber">String number</param>
        /// <param name="numberBase">Integer number for base</param>
        /// <returns>Integer decimal number</returns>
        private static long ConvertToDecimal(string inputNumber, int numberBase)
        {
            Dictionary<char, int> elements = new Dictionary<char, int>() 
            { 
                { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, 
                { '8', 8 }, { '9', 9 }, { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 } 
            };
            long numberDecimal = new long();
            for (int index = inputNumber.Length - 1, power = 0; index >= 0; index--, power++)
            {
                int temp = elements[inputNumber[index]];
                numberDecimal += temp * Power(numberBase, power);
            }

            return numberDecimal;
        }

        /// <summary>
        /// Returns an integer number raised to the specified power.
        /// </summary>
        /// <param name="number">Integer number to be raised to a power.</param>
        /// <param name="exponent">Integer number that specifies a power.</param>
        /// <returns>The number <paramref name="number" /> raised to the power </returns>
        private static long Power(long number, int exponent)
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
    }
}