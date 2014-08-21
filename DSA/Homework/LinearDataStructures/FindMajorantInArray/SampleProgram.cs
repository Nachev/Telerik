namespace FindMajorantInArray
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /* * The majorant of an array of size N is a value that occurs in it at least N/2 + 1
     * times. Write a program to find the majorant of given array (if exists). 
     * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3*/

    internal class SampleProgram
    {
        private static void Main()
        {
            var inputSequence = Input();
            // To change input to manual, uncomment upper line and comment out lower one.
            //var inputSequence = RandomConsoleInput(-5, 5, 20);

            Output(inputSequence, "Input sequence is: ");
            var elementsCount = GetElementsCount(inputSequence);
            int majorant;
            if (FindMajorant(elementsCount, inputSequence.Count, out majorant))
            {
                Console.WriteLine("Majorant is " + majorant);
            }
            else
            {
                Console.WriteLine("No majorant in the sequence");
            }
        }

        private static bool FindMajorant<T>(IDictionary<T, int> elementsCount, int sequenceLength, out T majorant)
        {
            majorant = elementsCount.First().Key;
            foreach (var item in elementsCount)
            {
                if (item.Value > sequenceLength / 2)
                {
                    majorant = item.Key;
                    return true;
                }
            }

            return false;
        }

        private static IDictionary<T, int> GetElementsCount<T>(IList<T> inputSequence)
            where T : IComparable
        {
            // Holds the count of repeated elements.
            var elementsCount = new Dictionary<T, int>();

            var length = inputSequence.Count;
            for (int i = 0; i < length; i++)
            {
                var currentElement = inputSequence[i];

                // If current element is already traversed increment else create new one
                if (elementsCount.ContainsKey(currentElement))
                {
                    elementsCount[currentElement] += 1;
                }
                else
                {
                    elementsCount.Add(currentElement, 1);
                }
            }

            return elementsCount;
        }

        private static void Output<T>(ICollection<T> collection, string message)
        {
            Console.WriteLine();
            Console.WriteLine(message + string.Join(", ", collection));
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