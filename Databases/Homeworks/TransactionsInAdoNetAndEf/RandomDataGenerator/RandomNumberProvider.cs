namespace RandomDataGenerator
{
    using RandomDataGenerator.Contracts;
    using System;

    /// <summary>
    /// Random generator singleton.
    /// </summary>
    public class RandomNumberProvider : IRandomNumberProvider
    {
        /// <summary>Singleton instance of RandomNumberProvider.</summary>
        private static RandomNumberProvider instance;

        /// <summary>Readonly instance of Random class.</summary>
        private readonly Random randomGenerator;

        /// <summary>
        /// Prevents a default instance of the <see cref="RandomNumberProvider" /> class from being created.
        /// </summary>
        private RandomNumberProvider()
        {
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Returns the only instance of RandomNumberProvider.
        /// </summary>
        /// <returns>RandomNumberProvider only instance.</returns>
        public static RandomNumberProvider GetInstance()
        {
            // No need for multi threading fix.
            if (instance == null)
            {
                instance = new RandomNumberProvider();
            }

            return instance;
        }

        /// <summary>
        /// Generates random number through Random class.
        /// </summary>
        /// <param name="minNumber">Minimal range.</param>
        /// <param name="maxNumber">Maximal range.</param>
        /// <returns>Generated random number.</returns>
        public int GetIntInRange(int minNumber, int maxNumber)
        {
            int nextRandomNumber = this.randomGenerator.Next(minNumber, maxNumber + 1);
            return nextRandomNumber;
        }

        /// <summary>
        /// Overload with minimal range 0.
        /// </summary>
        /// <param name="maxNumber">Maximal range.</param>
        /// <returns>Generated random number.</returns>
        public int GetIntUpTo(int maxNumber)
        {
            return this.GetIntInRange(0, maxNumber);
        }

        /// <summary>
        /// Generates new double number in range.
        /// </summary>
        /// <param name="min">Minimal range value.</param>
        /// <param name="max">Maximal range value.</param>
        /// <returns>Generated number.</returns>
        public double GetDoubleInRange(double min, double max)
        {
            double result = new double();
            result = (this.randomGenerator.NextDouble() * (max - min)) + max;
            return result;
        }

        /// <summary>
        /// Generates new double number in range 0 to 1.
        /// </summary>
        /// <returns>Generated number.</returns>
        public double GetDouble()
        {
            return this.randomGenerator.NextDouble();
        }

        /// <summary>
        /// Generates number in range 0 to 100 and compares it with given percentage value.
        /// </summary>
        /// <param name="percent">Value for comparision.</param>
        /// <returns>True if generated number is smaller or equal to the given percentage value.</returns>
        public bool GetChance(int percent)
        {
            return this.randomGenerator.Next(0, 101) <= percent;
        }
    }
}
