namespace IsLeapYear
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Program that reads a year from the console and checks whether it is a leap. Use DateTime.
    /// </summary>
    public class IsLeapYear
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            int year = new int();
            year = YearInput();
            bool isLeap = CheckIfYearLeap(year);
            string state = string.Empty;
            if (isLeap)
            {
                state = "\b";
            }
            else
            {
                state = "not";
            }

            Console.WriteLine("Entered year {0} is {1} leap", year, state);
        }

        /// <summary>
        /// Input method with check for correctness for year
        /// </summary>
        /// <returns>Entered year</returns>
        private static int YearInput()
        {
            DateTime date = new DateTime();
            string[] formats = { "yyyy", "yy" };
            do
            {
                Console.Write("Enter year to be checked : ");
                string tempInput = Console.ReadLine();
                bool check = DateTime.TryParseExact(
                    tempInput,
                    formats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again");
                }
            } 
            while (true);

            return date.Year;
        }

        /// <summary>
        /// Checks if given year is leap
        /// </summary>
        /// <param name="year">integer represented year to be checked</param>
        /// <returns>Boolean value true if year is leap</returns>
        private static bool CheckIfYearLeap(int year)
        {
            bool isYearLeap = new bool();
            isYearLeap = DateTime.IsLeapYear(year);

            return isYearLeap;
        }
    }
}
