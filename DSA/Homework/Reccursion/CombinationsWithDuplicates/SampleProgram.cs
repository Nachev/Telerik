namespace CombinationsWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            int[] arr = new int[k];
            CalcCombinations(arr, n, 0, 1);
        }

        private static void CalcCombinations(int[] arr, int numberOfElements, int currentPosition, int next)
        {
            int sequenceLength = arr.Length;

            if (currentPosition >= sequenceLength)
            {
                PrintLoops(arr);
                return;
            }

            for (int currentElement = next; currentElement <= numberOfElements; currentElement++)
            {
                arr[currentPosition] = currentElement;
                CalcCombinations(arr, numberOfElements, currentPosition + 1, currentElement);
            }
        }

        private static void PrintLoops(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
