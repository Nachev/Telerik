namespace FindLongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /*Write a method that finds the longest subsequence of equal numbers in given List<int> 
     * and returns the result as new List<int>. Write a program to test whether the method 
     * works correctly.*/

    internal class SampleProgram
    {
        private static void Main()
        {
            // var inputSequence = Input();
            // To change input to manual uncomment upper line and comment out lower one.
            var inputSequence = RandomConsoleInput(-10, 10, 30);
            var result = FindLongestSequenceOfEquals(inputSequence);
            Output(inputSequence, result);
        }

        private static Tuple<T, int> FindLongestSequenceOfEquals<T>(IList<T> inputSequence) where T : IComparable
        {
            T resultElement = inputSequence.First();
            int currentCounter = 1;
            int maxCounter = new int();

            for (int i = 1; i < inputSequence.Count; i++)
            {
                if (inputSequence[i - 1].CompareTo(inputSequence[i]) == 0)
                {
                    currentCounter += 1;

                    if (maxCounter < currentCounter)
                    {
                        maxCounter = currentCounter;
                        resultElement = inputSequence[i - 1];
                    }
                }
                else 
                {
                    currentCounter = 1;
                }
            }

            return new Tuple<T,int>(resultElement, maxCounter);
        }

        private static void Output<T>(IList<T> inputSequence, Tuple<T, int> outputResult)
        {
            Console.WriteLine();
            Console.WriteLine("Input sequence is: " + string.Join(", ", inputSequence));
            Console.WriteLine("Longest sequence of equals is {0} elements long of element - {1}", outputResult.Item2, outputResult.Item1);
        }

        private static IList<int> RandomConsoleInput(int min, int max, int count = 20)
        {
            Random rng = new Random();
            StringBuilder consoleInput = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                var element = rng.Next(min, max).ToString();
                consoleInput.AppendLine(element);
            }

            consoleInput.AppendLine(string.Empty);

            IList<int> result;
            using (StringReader consoleInputReader = new StringReader(consoleInput.ToString()))
            {
                Console.SetIn(consoleInputReader);
                result = Input();
            }

            return result;
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
    }
}