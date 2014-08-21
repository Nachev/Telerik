namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SampleProgram
    {
        private static readonly IList<Func<int, int>> Pattern = new List<Func<int, int>>() 
        {
            new Func<int, int>(x => x + 1),
            new Func<int, int>(x => x + 2),
            new Func<int, int>(x => 2 * x),
        };

        private static void Main(string[] args)
        {
            int firstMember = Input("Enter first member");
            int requiredMember = Input("Enter destination member");
            var calcResult = CalculateMembers(firstMember, requiredMember, Pattern);
            Console.WriteLine(string.Format("Result is: {0}", string.Join(", ", calcResult)));
        }

        // Varant 2
        private static IList<int> CalculateMembers(int firstMember, int requiredMember, IList<Func<int, int>> pattern)
        {
            int queueLength = requiredMember - firstMember / 2;
            var queue = new Queue<int>(queueLength);
            var result = new List<int>();

            // The queue stores members for calculation.
            queue.Enqueue(firstMember);

            // The list stores the result.
            result.Add(firstMember);

            int currentMember = firstMember;

            while (true)
            {
                // If a new pattern cycle begun, get new element for calculation.
                if (currentMember < requiredMember)
                {
                    patternLeadElement = queue.Dequeue();
                }

                if (currentMember == requiredMember)
                {
                    patternLeadElement = queue.Dequeue();
                }

                // Calculate next member via current pattern method.
                var patternElement = pattern[patternIndex](patternLeadElement);

                queue.Enqueue(patternElement);
                result.Add(patternElement);
            }

            return result.GetRange(0, requiredMember);
        }

        private static int Input(string message)
        {
            bool isCorrectInput = new bool();
            var result = new int();
            Console.Write(message);
            do
            {
                Console.Write(" -> ");
                string input = Console.ReadLine();
                isCorrectInput = int.TryParse(input, out result);
            }
            while (!isCorrectInput);

            return result;
        }
    }
}