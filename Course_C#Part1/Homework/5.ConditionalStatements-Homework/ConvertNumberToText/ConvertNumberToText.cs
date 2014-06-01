namespace ConvertNumberToText
{
    using System;
    using System.Text;

    /*Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation.
     * Examples:
     * 0  "Zero"
     * 273  "Two hundred seventy three"
     * 400  "Four hundred"
     * 501  "Five hundred and one"
     * 711  "Seven hundred and eleven"*/

    public class ConvertNumberToText
    {
        public static void Main()
        {
            // Input block with error check
            Console.Write("Enter number form 0 to 999: ");
            uint number = new int();
            int check = 10;
            do
            {
                Console.Write("-> ");
                string temp = Console.ReadLine();
                if (uint.TryParse(temp, out number) && number < 1000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                check--;
            }
            while (check > 0);

            // Divide entered number to digits
            byte[] digits = new byte[3];
            uint temporaryNumber = number;
            byte count = 2;
            do
            {
                digits[count] = (byte)(temporaryNumber % 10);
                temporaryNumber /= 10;
                count--;
            }
            while (temporaryNumber != 0);

            // Create string arrays with digit values
            string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = 
            { 
                string.Empty, "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" 
            };
            string[] tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            // string[] thousandsGroups = { "", " Thousand", " Million", " Billion" }; Not in use
            StringBuilder text = new StringBuilder();

            // Add " in the beginning of the text
            text.Append("\"");

            // Check entered number and assign name
            if (number < 10)
            {
                text.Append(ones[digits[2]]);
            }
            else if (number > 10 && number < 20)
            {
                text.Append(teens[digits[2]]);
            }
            else if ((number == 10 || number > 20) && number < 100)
            {
                if (number % 10 == 0)
                {
                    text.Append(tens[digits[1] - 1]);
                }
                else
                {
                    text.Append(tens[digits[1] - 1]).Append(" ").Append(ones[digits[2]]);
                }
            }
            else if (number > 100)
            {
                if (number % 100 == 0)
                {
                    text.Append(ones[digits[0]]).Append(" hundred");
                }
                else if (number % 10 == 0)
                {
                    text.Append(ones[digits[0]]).Append(" hundred and ").Append(tens[digits[1] - 1]);
                }
                else
                {
                    text.Append(ones[digits[0]]).Append(" hundred and ");
                    if (digits[1] > 1)
                    {
                        text.Append(tens[digits[1] - 1]).Append(" ").Append(ones[digits[2]]);
                    }
                    else  if (digits[1] > 0)
                    {
                        text.Append(teens[digits[1]]);
                    }
                    else
                    {
                        text.Append(ones[digits[2]]);
                    }
                }
            }

            // Add " at the end of text
            text.Append("\"");
            string variant2 = text.ToString();

            // Print the result with capitalized first letter
            char firstLetter = char.ToUpper(text[1]);
            text.Replace(text[1], firstLetter, 1, 1);
            Console.WriteLine("Entered number is {0}", text.ToString());

            Console.WriteLine("To see second variant press any key");
            Console.ReadKey();

            // Variant 2 to capitalize first letter
            char[] letters = variant2.ToCharArray();
            letters[1] = char.ToUpper(letters[1]);
            string answer = new string(letters);
            Console.WriteLine(answer);
        }
    }
}
