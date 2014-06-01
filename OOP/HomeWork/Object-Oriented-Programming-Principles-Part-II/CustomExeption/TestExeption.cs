namespace CustomExeption
{
    using System;

    /*Define a class InvalidRangeException<T> that holds information about an error condition related to 
     * invalid range. It should hold error message and a range definition [start … end].
     * Write a sample application that demonstrates the InvalidRangeException<int> and 
     * InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range 
     * [1.1.1980 … 31.12.2013].*/

    public class TestExeption
    {
        private static void Main()
        {
            Console.WriteLine("Enter number in range [1 - 100].");
            try
            {
                int enteredNumber = int.Parse(Console.ReadLine());
                if (enteredNumber < 1 || enteredNumber > 100)
                {
                    throw new InvalidRangeException<int>(1, 100, "Message");
                }
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine("Valuee should be in range [{0} - {1}]!", e.MinValue, e.MaxValue);
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Enter date in format d.M.YYYY in range [1.1.1980 - 31.12.2013]");
            DateTime enteredDate = DateTime.Parse(Console.ReadLine());
            DateTime minValue = new DateTime(1980, 1, 1, 0, 0, 0);
            DateTime maxValue = new DateTime(2013, 12, 31, 23, 59, 59);
            int lowBorder = DateTime.Compare(enteredDate, minValue);
            int highBorder = DateTime.Compare(enteredDate, maxValue);
            if (lowBorder < 0 || highBorder > 0)
            {
                throw new InvalidRangeException<DateTime>(minValue, maxValue);
            }
        }
    }
}
