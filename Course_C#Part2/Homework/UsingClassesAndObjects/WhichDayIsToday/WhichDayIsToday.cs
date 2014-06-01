namespace WhichDayIsToday
{
    using System;

    /// <summary>
    /// Program that prints to the console which day of the week is today. Use System.DateTime.
    /// </summary>
    public class WhichDayIsToday
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek);
        }
    }
}
