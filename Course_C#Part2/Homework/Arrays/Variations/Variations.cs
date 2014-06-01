namespace Variations
{
    using System;
    using System.Collections.Generic;

    /*Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
     * Example:N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}*/

    public class Variations
    {
        public static void Main()
        {
            Console.Title = "Variations";
            Console.WriteLine("Program that reads two numbers N and K and generates all the variations of K elements ");
            Console.WriteLine("from the set [1..N]");

            int numberOfElements = Input("N");

            int sequenceLength = Input("K");
            
            int[] arr = new int[sequenceLength];

            // initialize array to 1
            arr = InitLoops(arr);

            // Solve problem
            CalcVariationsRecursive(0, arr, numberOfElements, sequenceLength);
        }

        private static int Input(string name)
        {
            // Input block with check for correct input for numberOfElemets
            int breakCount = 5;
            int value = new int();
            do
            {
                Console.Write("Enter number {0}: ", name);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                breakCount--;
            }
            while (breakCount > 0);

            return value;
        }

        private static void CalcVariationsRecursive(int currentElement, int[] arr, int numberOfElements, int sequenceLength)
        {
            // End of recursion condition
            if (currentElement == sequenceLength)
            {
                Print(arr);
                return;
            }

            // Counter calling recursive same method. 
            for (int counter = 1; counter <= numberOfElements; counter++)
            {
                arr[currentElement] = counter;
                CalcVariationsRecursive(currentElement + 1, arr, numberOfElements, sequenceLength);
            }
        }

        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        private static void CalcVariationsIterattive(int[] arr, int numberOfElements, int sequenceLength)
        {
            InitLoops(arr);

            int currentPosition;

            while (true)
            {
                PrintArray(arr);

                currentPosition = sequenceLength - 1;
                arr[currentPosition] = arr[currentPosition] + 1;

                while (arr[currentPosition] > numberOfElements)
                {
                    arr[currentPosition] = 1;
                    currentPosition--;

                    if (currentPosition < 0)
                    {
                        return;
                    }

                    arr[currentPosition] = arr[currentPosition] + 1;
                }
            }
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

        private static int[] InitLoops(int[] arr)
        {
            // Initialize array to 1
            for (int index = 0; index < arr.Length; index++)
            {
                arr[index] = 1;
            }

            return arr;
        }
    }
}
