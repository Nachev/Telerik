namespace ReadNumbers
{
    using System;

    /// <summary>
    /// Program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
    /// </summary>
    public class ReadNumbers
    {
        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            Console.Title = "Number reader";
            Console.WriteLine("Enter single number in range 1 - 255!");
            int input = ReadNumber(0, 256);
            Console.WriteLine("Enter array of ten numbers 1 < n1 < n2 ... < 100. From highest to lowest.");
            int[] arrInputNumbers = new int[10];
            int index = 0;
            arrInputNumbers[index] = ArrInput(arrInputNumbers, index);
            Console.WriteLine(string.Join(", ", arrInputNumbers));
        }

        /// <summary>
        /// Recursive input for array of integers 
        /// </summary>
        /// <param name="array">Input array</param>
        /// <param name="index">Current index</param>
        /// <returns>Entered integer number in range</returns>
        private static int ArrInput(int[] array, int index)
        {
            if (index == 9)
            {
                return array[index] = ReadNumber(array[index - 1], 100);
            }

            return array[index] = ReadNumber(1, ArrInput(array, index + 1));
        }

        /// <summary>
        /// Input method for strings
        /// </summary>
        /// <returns>String read from console</returns>
        private static string InputStr()
        {
            Console.Write("Enter number : ");
            string inputStr = Console.ReadLine();
            return inputStr;
        }

        /// <summary>
        /// Method ReadNumber(start, end) that enters an integer number in given range [start…end]. 
        /// If an invalid number or non-number text is entered, the method should throw an exception.
        /// </summary>
        /// <param name="start">Bottom limit of range</param>
        /// <param name="end">Top limit of range</param>
        /// <returns>Entered integer in range</returns>
        private static int ReadNumber(int start, int end)
        {
            int output = new int();
            int breakCount = 5;
            do
            {
                string tempIn = InputStr();
                try
                {
                    output = int.Parse(tempIn);
                    if (output <= start || output >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    break;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine("Wrong input! Input is not in a correct format!");
                    throw formatEx;
                }
                catch (ArgumentOutOfRangeException aofrEx)
                {
                    Console.WriteLine("Wrong input! Input is out of specified range -> {0} - {1}.", start, end);
                    throw aofrEx;
                }
                catch (OverflowException)
                {
                    Console.Write("Wrong input! Number is out of the range of {0}.", typeof(int));
                }

                if (breakCount <= 0)
                {
                    Console.WriteLine(" Error limit reached! Exiting");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(" Try again");
                }

                breakCount--;
            }
            while (true);

            return output;
        }
    }
}
