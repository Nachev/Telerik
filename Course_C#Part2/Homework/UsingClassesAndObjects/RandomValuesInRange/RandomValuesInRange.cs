namespace RandomValuesInRange
{
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Program that generates and prints to the console 10 random values in the range [100, 200].
    /// </summary>
    public class RandomValuesInRange
    {
        /// <summary>
        /// Static random generator.
        /// </summary>
        private static Random randomGenerator = new Random();

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            const int NumbersCount = 10;
            const int Min = 100;
            const int Max = 201;
            double[] randoms = GetRandomNumbers(NumbersCount, Min, Max);
            PrintArray(randoms);
        }

        /// <summary>
        /// Generates random numbers returning them as double array.
        /// </summary>
        /// <param name="numbersCount">How many numbers to be printed.</param>
        /// <param name="minimum">Minimal random number inclusive.</param>
        /// <param name="maximum">Maximal random number exclusive.</param>
        /// <returns>Double array filled with random numbers.</returns>
        private static double[] GetRandomNumbers(int numbersCount, double minimum, double maximum)
        {
            double[] result = new double[numbersCount];
            for (int count = 0; count < numbersCount; count++)
            {
                double tempNumber = (randomGenerator.NextDouble() * (maximum - minimum)) + minimum;
                result[count] = tempNumber;
            }

            return result;
        }

        /// <summary>
        /// Prints in console given array.
        /// </summary>
        /// <param name="array">Array to be printed.</param>
        private static void PrintArray(IEnumerable array)
        {
            StringBuilder result = new StringBuilder();
            foreach (var number in array)
            {
                result.AppendFormat("{0:#.##}", number);
                result.Append(", ");
            }

            result.Remove(result.Length - 2, 2);
            Console.WriteLine("Random numbers " + result);
        }
    }
}
