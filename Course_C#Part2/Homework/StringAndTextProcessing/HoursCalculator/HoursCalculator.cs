namespace HoursCalculator
{
    using System;
    using System.Globalization;

    /*Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
     * and prints the date and time after 6 hours and 30 minutes (in the same format) along with the 
     * day of week in Bulgarian.*/

    public class HoursCalculator
    {
        private static void Main()
        {
            DateTime dateTime = DateInput();
            DateTime result = dateTime.AddHours(6).AddMinutes(30);
            string format = "dd.MM.yyyy HH:mm:ss";
            Console.WriteLine(result.ToString(format));
            CultureInfo currentCulture = CultureInfo.CreateSpecificCulture("bg-BG");
            Console.WriteLine(result.ToString("dddd", currentCulture));
        }

        private static DateTime DateInput()
        {
            string[] formats = 
            { 
                "dd.MM.yyyy HH:mm:ss", 
                "dd.MM.yy HH:mm:ss", 
                "dd.M.yy HH:mm:ss", 
                "d.MM.yyyy HH:mm:ss", 
                "d.M.yyyy HH:mm:ss", 
                "d.MM.yy HH:mm:ss", 
                "d.M.yy HH:mm:ss",
                "dd.MM.yyyy H:mm:ss",
                "dd.MM.yy H:mm:ss", 
                "dd.M.yy H:mm:ss", 
                "d.MM.yyyy H:mm:ss", 
                "d.M.yyyy H:mm:ss", 
                "d.MM.yy H:mm:ss", 
                "d.M.yy H:mm:ss"
            };
            DateTime input = new DateTime();
            int breakCount = 5;
            do
            {
                Console.Write("Enter date and time: ");
                string tempInput = Console.ReadLine();
                if (DateTime.TryParseExact(
                    tempInput, 
                    formats,
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.AllowWhiteSpaces, 
                    out input))
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
