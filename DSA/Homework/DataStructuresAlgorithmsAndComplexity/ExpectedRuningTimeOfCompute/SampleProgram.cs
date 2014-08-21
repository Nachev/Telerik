namespace ExpectedRuningTimeOfCompute
{
    using System;
    using System.Linq;

    /* What is the expected running time of the following C# code? 
     * Explain why. Assume the array's size is n. 
     * 
     * Answer: Expected runing time is O(n ^ 2), because while the 
     * external "for" loop is executed "n" times, the internal "while" 
     * loop is executed n - 1 times for every iteration of the external one.*/

    public class SampleProgram
    {
        private const int DefaultArrayCapacity = 1000;
        private const int MinimalValueInArray = 0;
        private const int MaximalValueInArray = 101;

        private static readonly Random rng = new Random();

        internal static void Main(string[] args)
        {
            var arrayToCompute = GenerateRandomArray();
            var counter = Compute(arrayToCompute);
            Console.WriteLine("{0} iterations counted.", counter);
        }

        private static long Compute(int[] arr)
        {
            // Counts how many times the while loop is iterated.
            long countIterations = new long();

            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }

                    countIterations += 1;
                }
            }

            return countIterations;
        }

        private static int[] GenerateRandomArray(int capacity = DefaultArrayCapacity)
        {
            int[] randomArray = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                randomArray[i] = rng.Next(MinimalValueInArray, MaximalValueInArray);
            }

            return randomArray;
        }
    }
}