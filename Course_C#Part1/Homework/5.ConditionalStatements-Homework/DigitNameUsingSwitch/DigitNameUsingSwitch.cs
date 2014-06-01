namespace DigitNameUsingSwitch
{
    using System;
    using System.Text;

    /* Write program that asks for a digit and depending on the input 
     * shows the name of that digit (in English) using a switch statement */

    public class DigitNameUsingSwitch
    {
        public static void Main()
        {
            int digit = new int();
            int insaneCount = 10;

            // Input loop with correct input check
            do
            {
                Console.Write("Enter digit:");
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out digit);
                if (check && digit < 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Input must be single digit. Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            StringBuilder result = new StringBuilder();
            switch (digit)
            {
                case 0:
                    result.Append("Zero");
                    break;
                case 1:
                    result.Append("One");
                    break;
                case 2:
                    result.Append("Two");
                    break;
                case 3:
                    result.Append("Three");
                    break;
                case 4:
                    result.Append("Four");
                    break;
                case 5:
                    result.Append("Five");
                    break;
                case 6:
                    result.Append("Six");
                    break;
                case 7:
                    result.Append("Seven");
                    break;
                case 8:
                    result.Append("Eigth");
                    break;
                case 9:
                    result.Append("Nine");
                    break;
                default:
                    result.Append("There is no such number in the database");
                    break;
            }

            Console.WriteLine("Entered digit is " + result.ToString());
        }
    }
}
