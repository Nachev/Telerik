namespace BinaryToHex
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*Write a program to convert binary numbers to hexadecimal numbers (directly)*/

    /// <summary>
    /// Program to convert binary numbers to hexadecimal numbers (directly).
    /// </summary>
    public class BinaryToHexDirect
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            Console.Title = "Direct binary to hex converter";
            string inputNumber = NumberAsStringInput();
            bool isNegative = IsBinaryNegative(inputNumber);
            if (isNegative)
            {
                Console.WriteLine("Entered number is negative");
            }

            string result = ConvertToHex(inputNumber);
            Console.WriteLine("{0} -> {1}", inputNumber, result);
        }

        /// <summary>
        /// Returns string as hexadecimal number converted from binary
        /// </summary>
        /// <param name="inputNumber">Binary number as string</param>
        /// <returns>String as hexadecimal number</returns>
        private static string ConvertToHex(string inputNumber)
        {
            StringBuilder input = new StringBuilder(inputNumber);
            int check = inputNumber.Length % 4;
            if (check != 0)
            {
                input.Insert(0, "0", 4 - check); // Inserts leading zeroes if necessary
            }

            StringBuilder result = new StringBuilder();
            Dictionary<string, char> dict = new Dictionary<string, char>()
            { 
                { "0000", '0' }, { "0001", '1' }, { "0010", '2' }, { "0011", '3' }, { "0100", '4' }, { "0101", '5' }, 
                { "0110", '6' }, { "0111", '7' }, { "1000", '8' }, { "1001", '9' }, { "1010", 'A' }, { "1011", 'B' }, 
                { "1100", 'C' }, { "1101", 'D' }, { "1110", 'E' }, { "1111", 'F' }
            };

            for (int count = 0; count < input.Length; count += 4)
            {
                string temp = input.ToString(count, 4);
                result.Append(dict[temp]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns entered number as string validated as binary
        /// </summary>
        /// <returns>String binary number</returns>
        private static string NumberAsStringInput()
        {
            string input;
            int breakCount = 5;
            do
            {
                Console.Write("Enter number : ");
                input = Console.ReadLine();
                bool isHex = IsBinary(input);
                if (isHex)
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
        /// Returns boolean value true if specified string number is valid binary
        /// </summary>
        /// <param name="input">String number</param>
        /// <returns>Boolean value</returns>
        private static bool IsBinary(string input)
        {
            foreach (var digit in input)
            {
                if (digit < '0' || digit > '1')
                {
                    return false;
                }
            }

            return true;
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
