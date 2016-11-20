namespace RemoveNegatives
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /*Write a program that removes from given sequence all negative numbers.*/

    internal class SampleProgram
    {
        private static void Main()
        {
            // var inputSequence = Input();
            // To change input to manual uncomment upper line and comment out lower one.
            var inputSequence = RandomConsoleInput(-10, 10, 30);
            Output(inputSequence.Values, "Input sequence is: ");
            RemoveNegatives(inputSequence);
            Output(inputSequence.Values, "Positive sequence is: ");
        }

        private static void RemoveNegatives<T>(IDictionary<int, T> inputSequence) where T: IComparable
        {
            var elementIndex = inputSequence.First().Key;
            var length = inputSequence.Count;

            for (int i = 0; i < length; i++)
            {
                if (inputSequence.ContainsKey(i))
                {                    
                    elementIndex = i;
                }

                if (inputSequence[elementIndex].CompareTo(0) < 0)
                {
                    inputSequence.Remove(elementIndex);
                }
            }
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