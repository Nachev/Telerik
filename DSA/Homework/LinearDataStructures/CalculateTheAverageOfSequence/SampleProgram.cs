namespace CalculateTheAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Write a program that reads from the console a sequence of positive 
     * integer numbers. The sequence ends when empty line is entered. 
     * Calculate and print the sum and average of the elements of the 
     * sequence. Keep the sequence in List<int>.*/

    internal class SampleProgram
    {
        private static void Main()
        {
            var inputSequence = Input();
            long sum = CalculateSum(inputSequence);
            double average = CalculateAverage(sum, inputSequence.Count);
            Console.WriteLine("Sum is: {0}, average is: {1}", sum, average);
        }

        private static IList<int> Input()
        {
            bool isListInput = new bool(); 
            var result = new List<int>();
            Console.WriteLine("Enter sequence: ");
            do
            {
                Console.Write("-> ");
                string input = Console.ReadLine();
                int converted = new int();
                isListInput = int.TryParse(input, out converted);
                if (isListInput)
                {
                    result.Add(converted);
                }
            }
            while (isListInput || result.Count == 0);

            return result;
        }

        private static long CalculateSum(IList<int> sequence)
        {
            long result = new long();
            for (int i = 0; i < sequence.Count; i++)
            {
                result += sequence[i];
            }

            return result;
        }

        private static double CalculateAverage(long sum, int length)
        {
            double result = new double();
            result = sum / length;
            return result;
        }

        private static double CalculateAverage(IList<int> sequence)
        {
            long sum = new long();

            for (int i = 0; i < sequence.Count; i++)
            {
                sum += sequence[i];
            }

            double result = sum / sequence.Count;

            return result;
        }
    }
}
