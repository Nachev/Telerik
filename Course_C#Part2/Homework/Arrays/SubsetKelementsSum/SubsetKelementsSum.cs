namespace SubsetKelementsSum
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
     * Find in the array a subset of K elements that have sum S or indicate about its absence*/

    public class SubsetKelementsSum
    {
        private static void Main()
        {
            Console.Title = "Find subset sum of K elements in array";

            int inputSum = 14;
            int subsetLength = 4;
            Console.WriteLine("Program that reads three integer numbers N, K and S and an array of N elements.");
            Console.WriteLine("Find in the array a subset of K elements that have sum S.");

            // Array length input
            int arrLength = 13; // IntInput("N");

            // Input method with check for correct input for lenght of wanted subset
            subsetLength = 4; // IntInput("K");

            // Input method with check for correct input for wanted sum
            inputSum = 32; // IntInput("S");

            // Array creation with required length
            int[] arr = { 12, 23, 4, 9, 6, 4, 23, 1, 0, 5, 3, 45, 13 }; // new int[arrLength];

            // ArrInput(arr, arrLength);

            FindSubsetSum(inputSum, subsetLength, arr);
        }

        private static void FindSubsetSum(int inputSum, int subsetLength, int[] arr)
        {
            // Create binary mask with all possible combinations mask = Math.Pow(numbers count, 2) - 1;
            long mask = 2;
            int length = arr.Length;
            for (int counter = 2; counter <= length; counter++)
            {
                mask *= 2;
            }

            mask -= 1;

            // Print mask for check
            Console.WriteLine("Mask is: " + Convert.ToString(mask, 2));

            // Cycle all possible combinations
            while (mask > 0)
            {
                int currentSum = new int();
                List<int> sumElements = new List<int>(); // Collects sum elements

                for (int counter = 0; counter < length; counter++)
                {
                    if (((mask >> counter) & 1) == 1)
                    {
                        currentSum += arr[counter];
                        sumElements.Add(arr[counter]);
                    }
                }

                // If there is a match print the result
                if ((currentSum == inputSum) && (sumElements.Count == subsetLength))
                {
                    PrintResult(sumElements, inputSum);
                }

                mask--;
            }
        }

        private static void PrintResult(List<int> sumElements, int inputSum)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < sumElements.Count; index++)
            {
                result.Append(sumElements[index]).Append(" + ");
            }

            result.Remove(result.Length - 3, 3);
            Console.WriteLine("Yes -> ({0}) = {1}", result.ToString(), inputSum);
        }

        private static void ArrInput(int[] arr, int arrLength)
        {
            // Input block with check for correct input for array elements
            for (int index = 1; index < arrLength; index++)
            {
                int breakCount = 5;
                int tempInput = new int();
                do
                {
                    Console.Write("Enter element {0} -> ", index);
                    if (int.TryParse(Console.ReadLine(), out tempInput))
                    {
                        arr[index] = tempInput;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input for element {0}!!! Try again.", index);
                    }

                    breakCount--;

                    if (breakCount <= 0)
                    {
                        Console.WriteLine("Error limit reached! Exiting.");
                        Environment.Exit(0);
                    }
                }
                while (breakCount > 0);
            }
        }

        private static int IntInput(string name)
        {
            // Input block with check for correct input for integer
            int breakCount = 5;
            int inputInt = new int();
            do
            {
                Console.Write("Enter number {0}: ", name);
                if (int.TryParse(Console.ReadLine(), out inputInt))
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

            return inputInt;
        }
    }
}
