namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*We are given numbers N and M and the following 
    operations:
    a) N = N+1
    b) N = N+2
    c) N = N*2
    Write a program that finds the shortest sequence of 
    operations from the list above that starts from N 
    and finishes in M. Hint: use a queue.
     Example: N = 5, M = 16
     Sequence: 5  7  8  16*/
    internal class SampleProgram
    {
        private static readonly IList<Func<int, int>> pattern = new List<Func<int, int>>()
        {
            new Func<int, int>(x => 2 * x),
            new Func<int, int>(x => x + 2),
            new Func<int, int>(x => x + 1),
        };

        private static void Main(string[] args)
        {
            int firstMember = Input("Enter first member");
            int requiredMember = Input("Enter destination member");
            var calcResult = CalculateMembers(firstMember, requiredMember, pattern);
            Console.WriteLine(string.Format("Result is: {0}", string.Join(", ", calcResult)));
        }

        private static IEnumerable<int> CalculateMembers(int firstMember, int requiredMember, IList<Func<int, int>> pattern)
        {
            int listLength = requiredMember - firstMember / 2;
            var queue = new Queue<List<int>>(listLength);
            var currentList = new List<int>();
            var checkedValues = new HashSet<int>();

            // The queue stores members for calculation.
            currentList.Add(firstMember);
            queue.Enqueue(currentList);

            int currentMember = firstMember;

            while (queue.Count > 0)
            {

                // If a new pattern cycle begun, get new element for calculation.
                currentList = queue.Dequeue();
                currentMember = currentList.Last();

                if (currentMember < requiredMember && !checkedValues.Contains(currentMember))
                {
                    checkedValues.Add(currentMember);
                    for (int patternIndex = 0; patternIndex < pattern.Count; patternIndex++)
                    {
                        // Calculate next member via current pattern method.
                        var nextMember = pattern[patternIndex](currentMember);

                        var nextList = new List<int>(currentList);
                        nextList.Add(nextMember);
                        queue.Enqueue(nextList);
                    }
                }

                if (currentMember == requiredMember)
                {
                    return currentList;
                }
            }

            return null;
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