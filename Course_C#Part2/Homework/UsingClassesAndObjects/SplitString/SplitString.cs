namespace SplitString
{
    using System;

    /// <summary>
    /// A program that reads a sequence of positive integer values written into a string, 
    /// separated by spaces and calculates their sum.
    /// </summary>
    public class SplitString
    {
        private static void Main()
        {
            do
            {
                Console.Write("Enter values in row : ");
                string input = Console.ReadLine();
                input = input.Trim();
                char[] separator = { ' ' };
                string[] splitted = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                long sum = new long();
                bool isFinished = true;

                foreach (var element in splitted)
                {
                    int tempNumber = new int();
                    if (int.TryParse(element, out tempNumber))
                    {
                        sum += tempNumber;
                    }
                    else
                    {
                        Console.WriteLine("Error in input");
                        isFinished = false;
                        break;
                    }
                }

                if (isFinished)
                {
                    Console.WriteLine("Sum is: {0}", sum);
                    break;
                }
            }
            while (true);
        }
    }
}
