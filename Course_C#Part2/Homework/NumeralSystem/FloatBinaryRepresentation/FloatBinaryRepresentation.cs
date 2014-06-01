namespace FloatBinaryRepresentation
{
    using System;
    using System.Text;

    /// <summary>
    /// Program that shows the internal binary representation of given 32-bit signed 
    /// floating-point number in IEEE 754 format (the C# type float).
    /// </summary>
    public class FloatBinaryRepresentation
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            /*Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.*/
            const int FloatMaxLength = 23;
            int integerPart = new int();
            string strInput = Input();
            char sign = strInput[0] == '-' ? '1' : '0';
            strInput = strInput.TrimStart('-', ' ');
            float fractionalPart = float.Parse(strInput);
            integerPart = ExtractIntegerPart(fractionalPart);
            fractionalPart -= integerPart;
            int precision = fractionalPart.ToString().Length - 2;
            precision = precision > FloatMaxLength ? precision : FloatMaxLength;
            string mantissa = string.Empty;
            string integerBinary = ConvertIntToBinary(integerPart);
            string fractionalBinary = FractionaltoBinary(fractionalPart, precision);
            mantissa = MantissaForm(integerBinary, fractionalBinary);
            string exponent = ExponentCalc(integerBinary, fractionalBinary);
            Output(sign, exponent, mantissa);
        }

        /// <summary>
        /// Prints in console the result of conversion of float to binary
        /// </summary>
        /// <param name="sign">Char sign of number</param>
        /// <param name="exponent">String exponent part</param>
        /// <param name="mantissa">String mantissa part</param>
        private static void Output(char sign, string exponent, string mantissa)
        {
            Console.Write("Sign : {0} , ", sign);
            Console.Write("Exponent : {0} , ", exponent.PadLeft(8, '0'));
            Console.WriteLine("Mantissa : {0} ", mantissa.PadLeft(23, '0'));
        }

        /// <summary>
        /// Input method for string validated as float
        /// </summary>
        /// <returns>Float as string</returns>
        private static string Input() 
        {
            string input = string.Empty;
            int breakCount = 5;
            do
            {
                Console.Write("Enter float number to be converted : ");
                input = Console.ReadLine();
                bool check = FloatCheck(input);
                if (check)
                {
                    break;
                }
                else
                {
                    if (breakCount > 0)
                    {
                        Console.WriteLine("Wrong input! Try again.");
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
        /// Returns string value in binary of calculated exponent
        /// </summary>
        /// <param name="integerBinary">Integer part of float number</param>
        /// <param name="fractionalBinary">Fractional part of float number</param>
        /// <returns>Binary represented exponent of float number in string</returns>
        private static string ExponentCalc(string integerBinary, string fractionalBinary)
        {
            string exponent = string.Empty;
            int tempExp = new int();
            if (integerBinary.Length > 1 || integerBinary[0] == '1')
            {
                // -1 removes first bit from exponent calculation.
                tempExp = integerBinary.Length - 1;
            }
            else
            {
                int count = 0;
                while (fractionalBinary[count] == '0')
                {
                    count++;
                }

                tempExp = (count + 1) * -1;
            }

            // Adjust with bias 127
            tempExp += 127;
            exponent = ConvertIntToBinary(tempExp);

            return exponent;
        }

        /// <summary>
        /// Normalizes the mantissa of float (converts in format #.#####...)
        /// </summary>
        /// <param name="input">String binary number combined integer and fractional part of float</param>
        /// <param name="size">Size in bits of required result</param>
        /// <returns>String binary number as normalized mantissa</returns>
        private static string NormalizeMantissa(string input, int size)
        {
            StringBuilder output = new StringBuilder();
            output.Append(input.TrimStart(new char[] { '0', ' ' }));
            output.Remove(0, 1);
            output.Append('0', size - output.Length);
            return output.ToString();
        }

        /// <summary>
        /// Returns the mantissa of float number
        /// </summary>
        /// <param name="integerPart">Integer part in binary of float number</param>
        /// <param name="fractionalPart">Fractional part in binary of float number</param>
        /// <returns>String binary representation of the mantissa of float number</returns>
        private static string MantissaForm(string integerPart, string fractionalPart)
        {
            const int FloatMantissaSize = 23;
            StringBuilder output = new StringBuilder();
            output.Append(integerPart).Append(fractionalPart);

            // Removes first bit if it is 1
            if (output[0] > '0')
            {
                output.Remove(0, 1);
            }
            else
            {
                string normalizedMantissa = NormalizeMantissa(output.ToString(), FloatMantissaSize);
                output.Clear();
                output.Append(normalizedMantissa);
            }

            if (output.Length > FloatMantissaSize)
            {
                output.Remove(23, output.Length - FloatMantissaSize);
            }
            else
            {
                output.Append('0', FloatMantissaSize - output.Length);
            }

            return output.ToString();
        }

        /// <summary>
        /// Returns string number converted from decimal number to desired base.
        /// </summary>
        /// <param name="numberDec">Integer decimal number</param>
        /// <returns>String number</returns>
        private static string ConvertIntToBinary(int numberDec)
        {
            const int ResultBase = 2;
            StringBuilder result = new StringBuilder();

            while (numberDec > 0)
            {
                int temp = numberDec % ResultBase;
                numberDec /= ResultBase;
                result.Append(temp);
            }

            if (result.Length == 0)
            {
                result.Append('0');
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
        /// Converts fractional part of float number to binary
        /// </summary>
        /// <param name="fractNumber">Fractional part of float number</param>
        /// <param name="precision">Precision of resulting binary</param>
        /// <returns>Converted to binary fractional part of float</returns>
        private static string FractionaltoBinary(float fractNumber, int precision)
        {
            StringBuilder result = new StringBuilder();
            int digitCount = new int();
            while (fractNumber > 0 && digitCount < precision)
            {
                fractNumber *= 2;
                if (fractNumber >= 1)
                {
                    result.Append('1');
                    fractNumber -= 1;
                }
                else
                {
                    result.Append('0');
                }

                digitCount++;
            }

            return result.ToString();
        }

        /// <summary>
        /// Checks if given string valid float number
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Boolean value true if string is parsed correctly to float</returns>
        private static bool FloatCheck(string input)
        {
            float temp;
            bool isFloat = float.TryParse(input, out temp);

            return isFloat;
        }

        /// <summary>
        /// Extracts integer part of float number into int32
        /// </summary>
        /// <param name="input">Float number to be extracted from</param>
        /// <returns>Integer extracted from float</returns>
        private static int ExtractIntegerPart(float input)
        {
            int output = new int();
            output = (int)input;

            return output;
        }
    }
}
