namespace HexToBinaryDirect
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*Write a program to convert hexadecimal numbers to binary numbers (directly).*/

    /// <summary>
    /// Program to convert hexadecimal numbers to binary numbers (directly).
    /// </summary>
    public class HexToBinaryDirect
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            string inputNumber = NumberAsStringInput();
            string result = ConvertToBinary(inputNumber);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns converted to binary hexadecimal number.
        /// </summary>
        /// <param name="input">Valid hexadecimal number as string</param>
        /// <returns>String binary number</returns>
        private static string ConvertToBinary(string input)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<char, string> elements = new Dictionary<char, string>() 
            { 
                { '0', "0000" }, { '1', "0001" }, { '2', "0010" }, { '3', "0011" }, { '4', "0100" }, { '5', "0101" }, 
                { '6', "0110" }, { '7', "0111" }, { '8', "1000" }, { '9', "1001" }, { 'A', "1010" }, { 'B', "1011" }, 
                { 'C', "1100" }, { 'D', "1101" }, { 'E', "1110" }, { 'F', "1111" } 
            };

            for (int index = 0; index < input.Length; index++)
            {
                result.Append(elements[input[index]]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns string validated as correct hexadecimal number.
        /// </summary>
        /// <returns>String hex number</returns>
        private static string NumberAsStringInput()
        {
            string input;
            int breakCount = 5;
            do
            {
                Console.Write("Enter number : ");
                input = Console.ReadLine();
                bool isHex = IsHex(input);
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
        /// Returns boolean value true if specified string number is valid hexadecimal.
        /// </summary>
        /// <param name="input">String number as hex</param>
        /// <returns>Boolean value</returns>
        private static bool IsHex(string input)
        {
            bool isDecToHex = true;
            foreach (var element in input)
            {
                if (!(char.IsDigit(element) || (element >= 'A' && element <= 'F')))
                {
                    isDecToHex = false;
                }
            }

            return isDecToHex;
        }
    }
}
