namespace CombinationsWithoutRepetition
{
    using System;

    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            int n = 5;
            int k = 2;
            int[] arr = new int[k];
            CalcCombinations(arr, n, 1, 0);
        }

        private static void CalcCombinations(int[] arr, int numberOfElements, int currentPosition, int next)
        {
            int currentElement;
            int sequenceLength = arr.Length;

            if (currentPosition > sequenceLength)
            {
                return;
            }
            else
            {
                for (currentElement = next + 1; currentElement <= numberOfElements; currentElement++)
                {
                    arr[currentPosition - 1] = currentElement;

                    if (currentPosition == sequenceLength)
                    {
                        PrintLoops(arr);
                    }

                    CalcCombinations(arr, numberOfElements, currentPosition + 1, currentElement);
                }
            }
        }

        private static void PrintLoops(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
