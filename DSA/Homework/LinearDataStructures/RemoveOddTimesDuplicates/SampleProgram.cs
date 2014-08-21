namespace RemoveOddTimesDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /*Write a program that removes from given sequence all numbers that occur odd number of times. 
     * Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}*/

    internal class SampleProgram
    {
        private static void Main()
        {
            // var inputSequence = Input();
            // To change input to manual uncomment upper line and comment out lower one.
            var inputSequence = RandomConsoleInput(-5, 5, 20);
            Output(inputSequence.Values, "Input sequence is: ");
            var repetitionCount = GetIndexesOfRepeatedElements(inputSequence);
            RemoveOddTimesRepeatedEquals(inputSequence, repetitionCount);
            Output(inputSequence.Values, "Result sequence is: ");
        }

        private static void RemoveOddTimesRepeatedEquals<T>(
            IDictionary<int, T> mainSequence, 
            IDictionary<int, IList<int>> repetitionsCount)
        {
            // Foreach unique element check if indexes count is odd and remove them.
            foreach (var element in repetitionsCount)
            {
                if ((element.Value.Count & 1) == 1)
                {
                    foreach (var index in element.Value)
                    {
                        mainSequence.Remove(index);
                    }
                }
            }
        }

        private static IDictionary<T, IList<int>> GetIndexesOfRepeatedElements<T>(IDictionary<int, T> inputSequence) 
            where T : IComparable
        {
            // Holds the indexes in the main dictionary of repeated elements.
            var repeatedElementsIndexes = new Dictionary<T, IList<int>>();

            var length = inputSequence.Count;
            for (int i = 0; i < length; i++)
            {
                if (inputSequence.ContainsKey(i))
                {
                    var currentElement = inputSequence[i];

                    // If current element is already traversed add next index else create new one
                    if (repeatedElementsIndexes.ContainsKey(currentElement))
                    {
                        repeatedElementsIndexes[currentElement].Add(i);
                    }
                    else
                    {
                        repeatedElementsIndexes.Add(currentElement, new List<int>() { i });
                    }
                }
            }

            return repeatedElementsIndexes;
        }

        private static void Output<T>(ICollection<T> collection, string message)
        {
            Console.WriteLine();
            Console.WriteLine(message + string.Join(", ", collection));
        }

        private static IDictionary<int, int> RandomConsoleInput(int min, int max, int count = 20)
        {
            Random rng = new Random();
            StringBuilder consoleInput = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                var element = rng.Next(min, max).ToString();
                consoleInput.AppendLine(element);
            }

            consoleInput.AppendLine(string.Empty);

            IDictionary<int, int> result;
            using (StringReader consoleInputReader = new StringReader(consoleInput.ToString()))
            {
                Console.SetIn(consoleInputReader);
                result = Input();
            }

            return result;
        }

        private static IDictionary<int, int> Input()
        {
            bool isListInput = new bool();
            var result = new Dictionary<int, int>();
            int keyCount = 0;
            Console.WriteLine("Enter sequence: ");
            do
            {
                Console.Write("-> ");
                string input = Console.ReadLine();
                int converted = new int();
                isListInput = int.TryParse(input, out converted);
                if (isListInput)
                {
                    result.Add(keyCount, converted);
                    keyCount += 1;
                }
            }
            while (isListInput || result.Count == 0);

            return result;
        }
    }
}