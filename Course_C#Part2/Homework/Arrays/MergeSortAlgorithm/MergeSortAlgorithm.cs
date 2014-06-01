namespace MergeSortAlgorithm
{
    using System;
    using System.Text;

    /* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia) */

    public class MergeSortAlgorithm
    {
        // Sort array using Merge Sort Algorithm: http://www.sorting-algorithms.com/merge-sort
        private static int[] Split(int[] argArray)
        {
            // If there is only one element left in the array return it's value
            if (argArray.Length < 2)
            {
                return argArray;
            }

            // Initializing two arrays for "left" and "right" part of current array
            int midPoint = argArray.Length / 2;
            int[] leftArray = new int[midPoint];
            int[] rightArray = new int[argArray.Length - midPoint];

            // Move half of the elements from argument array to the new arrays
            for (int leftIndex = 0; leftIndex < midPoint; leftIndex++)
            {
                leftArray[leftIndex] = argArray[leftIndex];
            }

            // The same operation for the other half
            for (int index = midPoint, rightIndex = 0; index < argArray.Length; index++, rightIndex++)
            {
                rightArray[rightIndex] = argArray[index];
            }

            // Recursive call of current method for both parts till their length becomes 1
            leftArray = Split(leftArray);
            rightArray = Split(rightArray);
            return Merge(leftArray, rightArray);
        }

        private static int[] Merge(int[] leftArr, int[] rightArr)
        {
            int leftIndexCount = 0;
            int rightIndexCount = 0;
            int[] resultArray = new int[leftArr.Length + rightArr.Length];

            // Fill in the new result array with the merged parts
            for (int arrIndex = 0; arrIndex < resultArray.Length; arrIndex++)
            {
                bool rightArrEnd = rightIndexCount == rightArr.Length;
                bool leftArrEnd = leftIndexCount == leftArr.Length;
                if (rightArrEnd || (!leftArrEnd && leftArr[leftIndexCount] <= rightArr[rightIndexCount]))
                {
                    resultArray[arrIndex] = leftArr[leftIndexCount];
                    leftIndexCount++;
                }
                else if (leftArrEnd || (!rightArrEnd && rightArr[rightIndexCount] <= leftArr[leftIndexCount]))
                {
                    resultArray[arrIndex] = rightArr[rightIndexCount];
                    rightIndexCount++;
                }
            }

            return resultArray;
        }

        private static void RandArrInput(int[] inputArray)
        {
            // Random input array for easyness
            Random rand = new Random();

            for (int index = 0; index < inputArray.Length; index++)
            {
                inputArray[index] = rand.Next(1, 5000);
            }
        }

        private static void ArrInput(int[] inputArray)
        {
            for (int index = 0; index < inputArray.Length; index++)
            {
                int insaneCount = 5;
                do
                {
                    Console.Write("Enter element {0} : ", index + 1);
                    string temp = Console.ReadLine();
                    if (int.TryParse(temp, out inputArray[index]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!! Try again.");
                    }

                    insaneCount--;

                    if (insaneCount == 0)
                    {
                        Console.WriteLine("Error limit reached! Exiting.");
                        Environment.Exit(0);
                    }
                }
                while (insaneCount > 0);
            }
        }

        private static void PrintArray(string arr, int[] inputArray)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();
            result.AppendFormat("{0} array is: ", arr).AppendLine();

            foreach (var integer in inputArray)
            {
                // Go to new line on line end
                int length = integer.ToString().Length;
                if (line.Length + length + 1 < Console.WindowWidth)
                {
                    line.Append(integer).Append(" ");
                }
                else
                {
                    line.AppendLine();
                    result.Append(line);
                    line.Clear();
                    line.Append(integer).Append(" ");
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static void Main()
        {
            Console.Title = "Merge sort algorithm";
            int[] inputArray = new int[100];

            RandArrInput(inputArray);

            int[] resultArray = Split(inputArray);

            // Print input array
            PrintArray("Input", inputArray);
            Console.WriteLine();

            // Print result
            PrintArray("Sorted", resultArray);
            Console.WriteLine();
        }
    }
}
