namespace WorkDaysTillDate
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Write a method that calculates the number of workdays between today and given date, passed as parameter.
    /// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified
    /// preliminary as array.
    /// </summary>
    public class WorkDaysTillDate
    {
        /// <summary>
        /// Main method contains requirements
        /// </summary>
        private static void Main()
        {
            const int NumberOfHolidays = 14;
            string[] holidays = new string[NumberOfHolidays] 
            {
                "01/01",
                "03/03",
                "18/04",
                "19/04",
                "20/04",
                "01/05",
                "06/05",
                "24/05",
                "06/09",
                "22/09",
                "01/11",
                "24/12",
                "25/12",
                "26/12"
            };
            string[] weekend = { "Saturday", "Sunday" };
            DateTime enteredDate = DateInput();

            int workDaysCount = CountWorkDays(holidays, weekend, enteredDate);

            Console.WriteLine("Workdays : {0}", workDaysCount);
        }

        /// <summary>
        /// Counts work days from now till specified date and returns it's value.
        /// </summary>
        /// <param name="holidays">Contains official holidays.</param>
        /// <param name="weekend">Contains weekend days names.</param>
        /// <param name="enteredDate">End date</param>
        /// <returns>Counted work days</returns>
        private static int CountWorkDays(string[] holidays, string[] weekend, DateTime enteredDate)
        {
            DateTime today = DateTime.Today;
            int workDaysCount = new int();
            while (true)
            {
                DateTime tempDateTime = today.AddDays(1);
                string currentDay = tempDateTime.DayOfWeek.ToString();
                string format = string.Format("dd/MM");
                string currentDate = tempDateTime.ToString(format);
                int searchIndex = Array.BinarySearch(holidays, currentDate);
                if (searchIndex < 0 && !weekend.Contains(currentDay))
                {
                    workDaysCount++;
                }

                today = tempDateTime;

                if (tempDateTime == enteredDate)
                {
                    break;
                }
            }

            return workDaysCount;
        }

        /// <summary>
        /// Date input method with check for correctness
        /// </summary>
        /// <returns>Entered date time value</returns>
        private static DateTime DateInput()
        {
            DateTime enteredDate = new DateTime();
            do
            {
                Console.Write("Enter end date : ");
                string input = Console.ReadLine();
                bool isCorrect = DateTime.TryParse(input, out enteredDate); 
                if (isCorrect && enteredDate.Year >= DateTime.Now.Year)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again");
                }
            }
            while (true);

            return enteredDate;
        }
    }
}
