namespace Combinations
{
    using System;

    /*Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set
     * [1..N]. Example: N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}*/

    public class Combinations
    {
        private static void Main()
        {
            Console.Title = "Combinations of K distinct elements";

            // Input numberOfElements
            int numberOfElements = Input("N");

            // Input for sequenceLength
            int sequenceLength = Input("K");

            int[] arr = new int[sequenceLength];

            CalcCombinations(arr, numberOfElements, 1, 0);
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

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            }
            while (breakCount > 0);

            return value;
        }

        // Programming = ++Algorithms;
        /*void comb(unsigned i, unsigned after)
         { 
         * unsigned j;
           if (i > k) return;
           for (j = after + 1; j <= n; j++) 
         * {
               mp[i - 1] = j;
               if (i == k) print(i);
               comb(i + 1, j);
           }
        }*/

        private static void CalcCombinations(int[] arr, int numberOfElements, int currentPosition, int next)
        {
            // Recursive method for combination calculation
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
                        PrintLoops(arr, currentPosition);
                    }

                    CalcCombinations(arr, numberOfElements, currentPosition + 1, currentElement);
                }
            }
        }

        private static void PrintLoops(int[] arr, int currentPos)
        {
            for (int index = 0; index < currentPos; index++)
            {
                Console.Write("{0} ", arr[index]);
            }

            Console.WriteLine();
        }
    }
}