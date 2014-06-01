namespace AnyToAnyNumeralSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Program to convert from any numeral system of given base s to 
    /// any other numeral system of base d (2 ≤ s, d ≤  16).
    /// </summary>
    public class AnyToAnyNumeralSystem
    {
        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            Console.Title = "Numeral system converter";
            while (true)
            {
                PrintMenu();
                int selection = IntInput("selection", 1, 6);
                switch (selection)
                {
                    case 1: DecToBin();
                        break;
                    case 2: BinToDec();
                        break;
                    case 3: DecToHex();
                        break;
                    case 4: HexToDec();
                        break;
                    case 5: AnyToAny();
                        break;
                    case 6: Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Error!!!");
                        break;
                }
            }
        }

        /// <summary>
        /// Prints menu on screen
        /// </summary>
        private static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChoose converter");
            Console.WriteLine("MENU");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Decimal numbers to their binary representation.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2. Binary numbers to their decimal representation.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Decimal numbers to their hexadecimal representation.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("4. Hexadecimal numbers to their decimal representation.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Any numeral system of given base s to any numeral system of base d (2<=s,d<=16).");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("6. Exit.");
            Console.ResetColor();
        }

        /// <summary>
        /// Converts decimal number to binary
        /// </summary>
        private static void DecToBin()
        {
            Console.Title = "Numeral system converter /Decimal to binary/";
            const int ResultBase = 2;
            int inputNumber = IntInput("number for conversion", 0);
            string result = ConvertFromDecimal(inputNumber, ResultBase);
            Console.WriteLine("Converted number is {0}", result);
        }

        /// <summary>
        /// Converts binary number to decimal
        /// </summary>
        private static void BinToDec()
        {
            Console.Title = "Numeral system converter /Binary to decimal/";
            const int NumberBase = 2;
            string inputNumber = NumberAsStringInput(NumberBase);
            int result = ConvertToDecimal(inputNumber, NumberBase);
            Console.WriteLine("Converted number is {0}", result);
        }

        /// <summary>
        /// Converts decimal number to hexadecimal
        /// </summary>
        private static void DecToHex()
        {
            Console.Title = "Numeral system converter /Decimal to hexadecimal/";
            const int ResultBase = 16;
            int inputNumber = IntInput("number for conversion", 0);
            string result = ConvertFromDecimal(inputNumber, ResultBase);
            Console.WriteLine("Converted number is {0}", result);
        }

        /// <summary>
        /// Converts hexadecimal number to decimal
        /// </summary>
        private static void HexToDec()
        {
            Console.Title = "Numeral system converter /Hexadecimal to decimal/";
            const int NumberBase = 16;
            string inputNumber = NumberAsStringInput(NumberBase);
            int result = ConvertToDecimal(inputNumber, NumberBase);
            Console.WriteLine("Converted number is {0}", result);
        }

        /// <summary>
        /// Convert from any numeral system of given base s to 
        /// any other numeral system of base d (2 ≤ s, d ≤  16).
        /// </summary>
        private static void AnyToAny()
        {
            Console.Title = "Numeral system converter /Any to any/";
            int numberBase = IntInput("input number's base", 2, 16);
            string inputNumber = NumberAsStringInput(numberBase);
            int resultBase = IntInput("result base", 2, 16);
            if (numberBase == resultBase)
            {
                Console.WriteLine("Result number is -> {0}", inputNumber);
            }
            else
            {
                int numberDec = ConvertToDecimal(inputNumber, numberBase);
                if (numberBase == 10)
                {
                    Console.WriteLine("Result number is -> {0}", numberDec);
                }
                else
                {
                    string result = ConvertFromDecimal(numberDec, resultBase);
                    Console.WriteLine("Result number is -> {0}", result);
                }
            }
        }

        /// <summary>
        /// Returns string number converted from decimal number to desired base.
        /// </summary>
        /// <param name="numberDec">Integer decimal number</param>
        /// <param name="resultBase">Integer number for desired base</param>
        /// <returns>String number</returns>
        private static string ConvertFromDecimal(int numberDec, int resultBase)
        {
            StringBuilder result = new StringBuilder();
            char[] elements =  
            { 
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 
            };

            while (numberDec > 0)
            {
                int temp = numberDec % resultBase;
                numberDec /= resultBase;
                result.Append(elements[temp]);
            } 
            
            string output = ReverseCharsOrder(result.ToString());
            
            return output;
        }

        /// <summary>
        /// Reverses chars order in string
        /// </summary>
        /// <param name="input">Input string to be reversed</param>
        /// <returns>Reversed output string</returns>
        private static string ReverseCharsOrder(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < input.Length; index++)
            {
                result.Append(input[input.Length - 1 - index]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns integer decimal number converted from specified string number in specified base.
        /// </summary>
        /// <param name="inputNumber">String number</param>
        /// <param name="numberBase">Integer number for base</param>
        /// <returns>Integer decimal number</returns>
        private static int ConvertToDecimal(string inputNumber, int numberBase)
        {
            Dictionary<char, int> elements = new Dictionary<char, int>() 
            { 
                { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, 
                { '8', 8 }, { '9', 9 }, { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 } 
            };
            int numberDecimal = new int();
            for (int index = inputNumber.Length - 1, power = 0; index >= 0; index--, power++)
            {
                int temp = elements[inputNumber[index]];
                numberDecimal += temp * Power(numberBase, power);
            }

            return numberDecimal;
        }

        /// <summary>
        /// Returns entered string number validated in certain base.
        /// </summary>
        /// <param name="numberBase">Integer number for specified base</param>
        /// <returns>String number</returns>
        private static string NumberAsStringInput(int numberBase)
        {
            string input;
            int breakCount = 5;
            do
            {
                Console.Write("Enter number for conversion : ");
                input = Console.ReadLine();
                bool checkBase = numberBase <= 10 ? IsCorrectNumber(input, numberBase) : IsDecToHex(input, numberBase);
                if (checkBase)
                {
                    break;
                }
                else
                {
                    if (breakCount <= 0)
                    {
                        Console.WriteLine("Error limit reached! Exiting.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Try again");
                    }
                }

                breakCount--;
            }
            while (true);

            return input;
        }

        /// <summary>
        /// Returns boolean value true if certain number as string is valid in base up to 16.
        /// </summary>
        /// <param name="input">String number</param>
        /// <param name="numberBase">Integer number for specified base</param>
        /// <returns>Boolean value</returns>
        private static bool IsDecToHex(string input, int numberBase)
        {
            bool isDecToHex = true;
            char[] overDec = { 'A', 'B', 'C', 'D', 'E', 'F' };
            char endChar = overDec[numberBase - 11];
            foreach (var element in input)
            {
                if (!(char.IsDigit(element) || (element >= 'A' && element <= endChar)))
                {
                    isDecToHex = false;
                }
            }

            return isDecToHex;
        }

        /// <summary>
        /// Returns boolean value true if string input is correct number in certain base.
        /// </summary>
        /// <param name="input">String number</param>
        /// <param name="numberBase">Integer number for specified base</param>
        /// <returns>Boolean value</returns>
        private static bool IsCorrectNumber(string input, int numberBase)
        {
            bool isCorrectNumber = true;
            foreach (var digit in input)
            {
                if (!char.IsDigit(digit))
                {
                    isCorrectNumber = false;
                }
                else if (digit - '0' >= numberBase)
                {
                    isCorrectNumber = false;
                }
            }

            return isCorrectNumber;
        }

        /// <summary>
        /// Returns an integer number raised to the specified power.
        /// </summary>
        /// <param name="number">Integer number to be raised to a power.</param>
        /// <param name="exponent">Integer number that specifies a power.</param>
        /// <returns>The number <paramref name="number" /> raised to the power </returns>
        private static int Power(int number, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }
            else if (exponent == 1)
            {
                return number;
            }

            int result = number;
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
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow in Power method!!");
                    Environment.Exit(0);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns entered integer number validated in specified range.
        /// </summary>
        /// <param name="name">The name of entered number.</param>
        /// <param name="bottomBoundary">Bottom boundary of specified range.</param>
        /// <param name="topBoundary">Top boundary of specified range.</param>
        /// <returns>Validated integer number</returns>
        private static int IntInput(string name, int bottomBoundary = int.MinValue, int topBoundary = int.MaxValue)
        {
            int input = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out input);
                if (check && input >= bottomBoundary && input <= topBoundary)
                {
                    break;
                }
                else
                {
                    if (breakCount > 0)
                    {
                        Console.WriteLine("Wrong input! Try again");
                    }
                    else
                    {
                        Console.WriteLine("Error limit reached! Exiting.");
                        Environment.Exit(0);
                    }
                }

                breakCount--;
            }
            while (true);

            return input;
        }

        /// <summary>
        /// Returns boolean value true if specified string binary number is negative
        /// </summary>
        /// <param name="input">String number</param>
        /// <returns>Boolean value</returns>
        private static bool IsBinaryNegative(string input)
        {
            const int BITS = 8;
            bool isNegative = new bool();
            if (input.Length % BITS == 0)
            {
                if (input[0] == '1')
                {
                    isNegative = true;
                }
            }

            return isNegative;
        }
    }
}
