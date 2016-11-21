namespace CombinationsWithRepetition
{
    using System;

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
                PrintArray(arr);
                return;
            }

            for (int currentElement = next; currentElement <= numberOfElements; currentElement++)
            {
                arr[currentPosition] = currentElement;
                CalcCombinations(arr, numberOfElements, currentPosition + 1, currentElement);
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
