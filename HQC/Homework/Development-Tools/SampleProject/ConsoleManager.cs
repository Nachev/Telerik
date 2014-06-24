namespace Matrix
{
    using System;
    using System.Linq;

    /// <summary>
    /// Static class that manages the console interaction.
    /// </summary>
    public static class ConsoleManager
    {
        /// <summary>Number of maximal attempts for input allowed.</summary>
        private const int AttemptsLimit = 5;

        /// <summary>
        /// Handles input from the console for dimensions of the matrix with filter.
        /// </summary>
        /// <param name="message">Message to be printed before input.</param>
        /// <param name="minRange">Lower limit of the filter.</param>
        /// <param name="maxRange">Higher limit of the filter.</param>
        /// <returns>Entered valid integer.</returns>
        public static int DimensionsInput(string message, int minRange, int maxRange)
        {
            int inputNumber = new int();
            int attemptsCount = 1;
            bool parseNotSuccessful = false;
            bool inputNotInRange = false;

            Console.Write(message);
            do
            {
                Console.Write("-> ");
                string inputValue = Console.ReadLine();
                parseNotSuccessful = !int.TryParse(inputValue, out inputNumber);
                inputNotInRange = inputNumber < minRange || inputNumber > maxRange;
                if (attemptsCount >= AttemptsLimit)
                {
                    throw new ApplicationException("Attempts limit reached! Maximal number of input attempts is " + AttemptsLimit);
                }

                attemptsCount++;
            }
            while (parseNotSuccessful || inputNotInRange);

            return inputNumber;
        }

        /// <summary>
        /// Prints string on the console.
        /// </summary>
        /// <param name="stringToBePrinted">String to be printed.</param>
        public static void Print(string stringToBePrinted)
        {
            Console.Write(stringToBePrinted);
        }
    }
}