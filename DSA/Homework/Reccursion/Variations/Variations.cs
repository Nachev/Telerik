namespace Variations
{
    using System;
    using System.Collections.Generic;

    public static class Variations
    {
        private static string[] arr = new string[] { "a", "a", "b", "c" };

        public static void Main()
        {
            int numberOfElementsN = 3;

            int sequenceLengthK = 2;

            string[] currentArray = new string[sequenceLengthK]; 

            // Solve problem
            CalcVariationsRecursive(0, currentArray, numberOfElementsN, sequenceLengthK);
        }

        private static void CalcVariationsRecursive(int currentElement, string[] currentArray, int numberOfElements, int sequenceLength)
        {
            // End of recursion condition
            if (currentElement.CompareTo(sequenceLength) == 0)
            {
                Print(currentArray);
                return;
            }

            // Counter calling recursive same method. 
            for (int counter = 0; counter < numberOfElements; counter++)
            {
                currentArray[currentElement] = arr[counter];
                CalcVariationsRecursive(currentElement + 1, currentArray, numberOfElements, sequenceLength);
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
