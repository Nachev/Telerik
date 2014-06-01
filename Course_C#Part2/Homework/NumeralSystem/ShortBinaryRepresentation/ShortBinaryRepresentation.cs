namespace ShortBinaryRepresentation
{
    using System;
    using System.Text;

    /// <summary>
    /// Program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    /// </summary>
    public class ShortBinaryRepresentation
    {
        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            Console.Title = "Short to binary converter";
            short inputNumber = ShortInput();

            // Console.WriteLine(Convert.ToString(inputNumber, 2));
            string result = string.Empty;
            if (inputNumber < 0)
            {
                inputNumber *= -1;
                inputNumber--;
                result = ConvertFromDecToBin(inputNumber);
                result = InvertBinary(result);
            }
            else
            {
                result = ConvertFromDecToBin(inputNumber);
            }

            Console.WriteLine("Binary representation is : {0}", result);
        }

        /// <summary>
        /// Returns short validated number entered from console.
        /// </summary>
        /// <returns>Entered short number.</returns>
        private static short ShortInput()
        {
            short inputNumber = new short();
            byte breakCount = 5;
            do
            {
                Console.Write("Enter number : ");
                string temp = Console.ReadLine();
                bool check = short.TryParse(temp, out inputNumber);
                if (check)
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
                        Console.WriteLine("Wrong input! Try again.");
                    }
                }

                breakCount--;
            } 
            while (true);

            return inputNumber;
        }

        /// <summary>
        /// Converts from short to binary.
        /// </summary>
        /// <param name="numberDec">Short number in decimal format.</param>
        /// <returns>Converted from decimal string number.</returns>
        private static string ConvertFromDecToBin(int numberDec)
        {
            const int ResultBase = 2;
            StringBuilder invertedResult = new StringBuilder();
            StringBuilder result = new StringBuilder();

            while (numberDec > 0)
            {
                int temp = numberDec % ResultBase;
                numberDec /= ResultBase;
                invertedResult.Append(temp);
            }

            // Reverse order of elements.
            for (int index = 0; index < invertedResult.Length; index++)
            {
                result.Append(invertedResult[invertedResult.Length - 1 - index]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Inverts binary string representation of a number
        /// </summary>
        /// <param name="input">Binary number to be inverted</param>
        /// <returns>Inverted string number</returns>
        private static string InvertBinary(string input)
        {
            // Fill string with leading zeroes
            StringBuilder zeroFilled = new StringBuilder();
            zeroFilled.Append('0', 16 - input.Length);
            zeroFilled.Append(input);

            StringBuilder result = new StringBuilder();
            for (int index = 0; index < zeroFilled.Length; index++)
            {
                if (zeroFilled[index] == '0')
                {
                    result.Append('1');
                }
                else
                {
                    result.Append('0');
                }
            }

            return result.ToString();
        }
    }
}
