namespace SortListIncreasing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /*Write a program that reads a sequence of integers (List<int>) ending 
     * with an empty line and sorts them in an increasing order.*/

    internal class SampleProgram
    {
        private static void Main()
        {
            // var inputSequence = Input();
            // To change input to manual ucomment upper line and comment out lower one.
            var inputSequence = RandomConsoleInput(-100, 200, 30000);

            var sortedSequence = MergeSort_Split(inputSequence);

            Output(inputSequence, sortedSequence);
        }
 
        private static void Output(IList<int> inputSequence, IList<int> sortedSequence)
        {
            Console.WriteLine();
            Console.WriteLine("Entered sequence is: {0}", string.Join(", ", inputSequence));
            Console.WriteLine("Sorted sequence is: {0}", string.Join(", ", sortedSequence));
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

        /*function merge_sort(list m)
        // Base case. A list of zero or one elements is sorted, by definition.
        if length(m) <= 1
        return m

        // Recursive case. First, *divide* the list into equal-sized sublists.
        var list left, right
        var integer middle = length(m) / 2
        for each x in m before middle
        add x to left
        for each x in m after or equal middle
        add x to right

        // Recursively sort both sublists.
        left = merge_sort(left)
        right = merge_sort(right)
        // *Conquer*: merge the now-sorted sublists.
        return merge(left, right)*/

        private static IList<T> MergeSort_Split<T>(IList<T> sequence) where T : IComparable
        {
            if (sequence.Count <= 1)
            {
                return sequence;
            }

            int middlePoint = sequence.Count / 2;

            var left = CopyList<T>(sequence, 0, middlePoint);
            var right = CopyList<T>(sequence, middlePoint, sequence.Count);

            left = MergeSort_Split(left);
            right = MergeSort_Split(right);

            return MergeSort_Merge(left, right);
        }
 
        private static IList<T> CopyList<T>(IList<T> sequence, int startPoint, int endPoint)
        {
            var result = new List<T>();
            for (int i = startPoint; i < endPoint; i++)
            {
                result.Add(sequence[i]);
            }

            return result;
        }

        /*function merge(left, right)
        var list result
        // assign the element of the sublists to 'result' variable until there is no element to merge. 
        while length(left) > 0 or length(right) > 0
        if length(left) > 0 and length(right) > 0
        // compare the first two element, which is the small one, of each two sublists.
        if first(left) <= first(right)
        append first(left) to result
        left = rest(left)
        else
        append first(right) to result
        right = rest(right)
        else if length(left) > 0
        append first(left) to result
        left = rest(left)
        else if length(right) > 0
        append first(right) to result
        right = rest(right)
        end while
        return result*/

        private static IList<T> MergeSort_Merge<T>(IList<T> left, IList<T> right) where T : IComparable
        {
            var result = new List<T>();
            int leftLength = left.Count;
            int rightLength = right.Count;
            int leftCount = 0;
            int rightCount = 0;

            while (leftCount < leftLength && rightCount < rightLength)
            {
                if (left[leftCount].CompareTo(right[rightCount]) <= 0)
                {
                    leftCount = AppendNewElement(left, result, leftCount);
                }
                else
                {
                    rightCount = AppendNewElement(right, result, rightCount);
                }
            }

            while (leftCount < leftLength)
            {
                leftCount = AppendNewElement(left, result, leftCount);
            }

            while (rightCount < rightLength)
            {
                rightCount = AppendNewElement(right, result, rightCount);
            }

            return result;
        }
 
        private static int AppendNewElement<T>(IList<T> inputList, IList<T> result, int counter)
        {
            result.Add(inputList[counter]);
            counter += 1;
            return counter;
        }

        private static IList<T> Merge_Slow<T>(IList<T> left, IList<T> right) where T : IComparable
        {
            var result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0)
                    {
                        result.Add(left.First());
                        left = new List<T>(left.Skip(1));
                    }
                    else
                    {
                        result.Add(right.First());
                        right = new List<T>(right.Skip(1));
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left = new List<T>(left.Skip(1));
                }
                else 
                {
                    // if (right.Count > 0)
                    result.Add(right.First());
                    right = new List<T>(right.Skip(1));
                }
            }

            return result;
        }
    }
}