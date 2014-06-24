//-----------------------------------------------------------------------
//    ACME Inc.
// <summary>2. Refactor the following code to apply variable usage and naming best practices:</summary>
//-----------------------------------------------------------------------
namespace Statistics
{
    using System;

    /// <summary>
    /// Sample set class for task 2.
    /// </summary>
    public class Set
    {
        /// <summary>Initial container length.</summary>
        private const int InitialContainerLength = 50;

        /// <summary>Array of doubles to contain the members of the set.</summary>
        private double[] container = new double[InitialContainerLength];

        /// <summary>Number of elements of the set.</summary>
        private int numberOfElements = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// </summary>
        /// <param name="args">Initial values of the set.</param>
        public Set(params double[] args)
        {
            foreach (var member in args)
            {
                this.container[this.numberOfElements] = member;
                this.numberOfElements++;
                if (this.container.Length == this.numberOfElements)
                {
                    this.container = this.ExtendContainer(this.container);
                }
            }
        }

        /// <summary>
        /// Prints statistics of the set.
        /// </summary>
        public void PrintStatistics()
        {
            double max = this.GetMaximalValue();
            this.Print("maximal", max);

            double min = this.GetMinimalValue();
            this.Print("minimal", min);

            double average = this.GetAverageValue();
            this.Print("average", average);
        }

        /// <summary>
        /// Extends container size.
        /// </summary>
        /// <param name="container">This container.</param>
        /// <returns>Extended container.</returns>
        private double[] ExtendContainer(double[] container)
        {
            double[] result = new double[container.Length * 2];
            for (int i = 0; i < container.Length; i++)
            {
                result[i] = container[i];
            }

            return result;
        }

        /// <summary>
        /// Gets the average value of the set.
        /// </summary>
        /// <returns>Average value</returns>
        private double GetAverageValue()
        {
            double average = new double();
            double sum = new double();
            for (int i = 0; i < this.numberOfElements; i++)
            {
                sum += this.container[i];
            }

            average = sum / this.numberOfElements;
            return average;
        }

        /// <summary>
        /// Gets the minimal value of the set.
        /// </summary>
        /// <returns>Minimal value.</returns>
        private double GetMinimalValue()
        {
            double min = double.MaxValue;
            for (int i = 0; i < this.numberOfElements; i++)
            {
                if (this.container[i] < min)
                {
                    min = this.container[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Gets the maximal value of the set.
        /// </summary>
        /// <returns>Maximal value.</returns>
        private double GetMaximalValue()
        {
            double max = double.MinValue;
            for (int i = 0; i < this.numberOfElements; i++)
            {
                if (this.container[i] > max)
                {
                    max = this.container[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints statistical value on the console.
        /// </summary>
        /// <param name="evaluation">Minimal / Maximal / Average</param>
        /// <param name="value">Value to be printed.</param>
        private void Print(string evaluation, double value)
        {
            Console.WriteLine(evaluation + " value is " + value);
        }
    }
}
