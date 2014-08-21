namespace FirstFiftyMembersOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SampleProgram
    {
        private static readonly IList<Func<int, int>> Pattern = new List<Func<int, int>>() 
        {
            new Func<int, int>(x => x + 1),
            new Func<int, int>(x => (2 * x) + 1),
            new Func<int, int>(x => x + 2),
        };
 
        private static void Main(string[] args)
        {
            int firstMember = Input("Enter first member");
            int sequenceLength = Input("Enter sequence length");
            var calcResult = CalculateMembers(firstMember, sequenceLength, Pattern);
            Console.WriteLine(string.Format("Result is: {0}", string.Join(", ", calcResult)));
        }

        // Varant 2
        private static IList<int> CalculateMembers(int firstMember, int sequenceLength, IList<Func<int, int>> pattern)
        {
            var queue = new Queue<int>(50);
            var result = new List<int>(50);

            // The queue stores members for calculation.
            queue.Enqueue(firstMember);

            // The list stores the result.
            result.Add(firstMember);

            int patternLeadElement = new int();

            for (int counter = 0; counter < sequenceLength; counter += 1)
            {
                var patternIndex = counter % pattern.Count;

                // If a new pattern cycle begun, get new element for calculation.
                if (patternIndex == 0)
                {
                    patternLeadElement = queue.Dequeue();
                }

                // Calculate next member via current pattern method.
                var patternElement = pattern[patternIndex](patternLeadElement);

                queue.Enqueue(patternElement);
                result.Add(patternElement);
            }

            return result.GetRange(0, sequenceLength);
        }

        // Variant 1
        private static IList<int> CalculateMembers(int firstMember, int sequenceLength)
        {
            var queue = new Queue<int>(50);
            var result = new List<int>(50);

            queue.Enqueue(firstMember);
            result.Add(firstMember);

            for (int counter = 0; counter < sequenceLength; counter += 3)
            {
                var patternLeadElement = queue.Dequeue();

                var patternElementOne = patternLeadElement + 1;
                queue.Enqueue(patternElementOne);
                result.Add(patternElementOne);

                var patternElementTwo = (2 * patternLeadElement) + 1;
                queue.Enqueue(patternElementTwo);
                result.Add(patternElementTwo);

                var patternElementThree = patternLeadElement + 2;
                queue.Enqueue(patternElementThree);
                result.Add(patternElementThree);
            }

            return result.GetRange(0, sequenceLength);
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