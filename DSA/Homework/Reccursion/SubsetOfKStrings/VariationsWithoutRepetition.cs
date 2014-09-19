namespace SubsetOfKStrings
{
    using System;
    using System.Collections.Generic;

    public static class VariationsWithoutRepetition
    {
        private static string[] arr = new string[] { "a", "b", "c", "d" };
        private static int[] arr2 = { 0, 1, 2, 3 };

        public static void Main()
        {
            int numberOfElementsN = 8;

            int sequenceLengthK = 4;

            string[] currentArray = new string[sequenceLengthK];

            // Solve problem
            CalcVariationsRecursive(0, currentArray, numberOfElementsN, sequenceLengthK, -1);
        }

        private static void CalcVariationsRecursive(int currentElement, string[] currentArray, int numberOfElements, int sequenceLength, int next)
        {
            // End of recursion condition
            if (currentElement.CompareTo(sequenceLength) == 0)
            {
                Print(currentArray);
                return;
            }

            // Counter calling recursive same method. 
            for (int counter = next + 1; counter < numberOfElements; counter++)
            {
                if (currentElement % 2 == 0)
                {
                    currentArray[currentElement] = arr2[counter % arr2.Length].ToString();
                }
                else
                {
                    currentArray[currentElement] = arr[counter % arr.Length];
                }

                CalcVariationsRecursive(currentElement + 1, currentArray, numberOfElements, sequenceLength, counter);
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void PrintArray(int[] arr)
        {
            // Print array
            for (int index = 0; index < arr.Length; index++)
            {
                Console.Write(arr[index]);
            }

            Console.WriteLine();
        }
    }
}
