namespace DaysBetweenDates
{
    using System;
    using System.Globalization;

    /*Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.*/
    
    public class DaysBetweenDates
    {
        private static void Main()
        {
            DateTime firstDate = DateInput("first");
            Console.WriteLine("The year is {0}", DateTime.IsLeapYear(firstDate.Year) ? "leap" : "not leap");

            DateTime secondDate = DateInput("second");
            Console.WriteLine("The year is {0}", DateTime.IsLeapYear(secondDate.Year) ? "leap" : "not leap");

            int distance = Math.Abs(firstDate.DayOfYear - secondDate.DayOfYear);
            Console.WriteLine("Distance: {0} days", distance);

            TimeSpan distanceSpan = firstDate.Subtract(secondDate);
            Console.WriteLine("Distance: {0} days", distanceSpan.Days);
        }

        private static DateTime DateInput(string name)
        {
            string[] formats = { "dd.MM.yyyy", "dd.MM.yy", "dd.M.yy", "d.MM.yyyy", "d.M.yyyy", "d.MM.yy", "d.M.yy" };
            DateTime input = new DateTime();
            int breakCount = 5;
            do
            {
                Console.Write("Enter the {0} date: ", name);
                string tempInput = Console.ReadLine();
                if (DateTime.TryParseExact(tempInput, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out input))
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
    }
}
