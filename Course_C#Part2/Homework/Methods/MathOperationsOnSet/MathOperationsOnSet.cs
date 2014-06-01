namespace MathOperationsOnSet
{
    using System;
    using System.Dynamic;

    /*Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
     * Use variable number of arguments.*/

    public class MathOperationsOnSet
    {
        private static void Main()
        {
            Console.Title = "Operations over set of generic type";

            byte[] setByte = { 13, 24, 5, 16, 97, 21, 12, 14, 74, 31, 4, 13 };
            int[] setInt = { 1024, 256, -512, 64, int.MaxValue, 91, 23, 12598, int.MinValue, 1445, 7403, 231, 4, 213 };
            double[] setDouble = 
            { 
                125.23, 652.23, 3.2359, 45687.12, -4.23, 4, 5459, 
                7.8, -99989.7, -12.41, 732575.21, 8165.31635, -3.31256540 
            };
            decimal[] setDecimal = 
                { 
                125.23M, 652.23M, 3.2359M, 45687.12M, -4.23M, 4M, 5459M, 
                7.8M, -99989.7M, -12.41M, 732575.21M, 8165.31635M, -3.31256540M 
            };

            MinimumOfSet(setByte, byte.MaxValue);
            MinimumOfSet(setDouble, double.MaxValue);
            MinimumOfSet(setInt, int.MinValue);
            MaximumOfSet(setDecimal, decimal.MinValue);
            AverageOfSet(setDouble);
            AverageOfSet(setInt);
            SumOfSet(setDecimal);
            ProductOfSet(setDouble);
        }

        private static void MinimumOfSet<T>(T[] set, T minimum) where T : IComparable<T>
        {
            foreach (var item in set)
            {
                if (item.CompareTo(minimum) < 0)
                {
                    minimum = item;
                }
            }

            Console.WriteLine("Minimum of current set of {0} is : {1}", typeof(T), minimum);
        }

        private static void MaximumOfSet<T>(T[] set, T maximum) where T : IComparable<T>
        { 
            for (int index = 0; index < set.Length; index++)
            {
                if (set[index].CompareTo(maximum) > 0)
                {
                    maximum = set[index];
                }
            }

            Console.WriteLine("Maximum of current set of {0} is : {1}", typeof(T), maximum);
        }

        private static void AverageOfSet<T>(T[] set)
        {
            dynamic average = 0;
            int length = set.Length;
            for (int index = 0; index < length; index++)
            {
                average += set[index];
            }

            average /= length;
            Console.WriteLine("The average of current set is : {0}", average);
        }

        private static void SumOfSet<T>(T[] set)
        {
            dynamic sum = 1;
            foreach (var item in set)
            {
                sum += item;
            }

            Console.WriteLine("The sum of current set is: {0}", sum);
        }

        private static void ProductOfSet<T>(T[] set)
        {
            dynamic product = 1L;
            foreach (var item in set)
            {
                product *= item;
            }

            Console.WriteLine("The product of current set is : {0}", product);
        }
    }
}
