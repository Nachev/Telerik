namespace MostFrequentNumberInArray
{
    using System;

    /*Write a program that finds the most frequent number in an array. Example
     * {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)*/

    public class MostFrequentNumberInArray
    {
        private static void Main()
        {
            Console.Title = "Most frequent number in array";

            int[] inputArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            //// Input cycle
            // Console.WriteLine("Enter array elements:");
            // Input(inputArray);

            // Using new sorted array
            int[] sortedArray = Split(inputArray);

            /*foreach (var item in sortedArray)
            {
                Console.Write(item + " ");
            }*/

            // Variable for counting equal numbers 
            int currentCount = 1;

            // Variable for storing best result
            int bestCount = new int();

            // Variable that keeps the index of the most frequent element
            int indexSave = new int();
            int length = sortedArray.Length;

            for (int arrIndex = 1; arrIndex < length; arrIndex++)
            {
                // If current element is bigger than previous means new sequence of equal elements is reached
                if (sortedArray[arrIndex] > sortedArray[arrIndex - 1])
                {
                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        indexSave = arrIndex - 1;
                        currentCount = 1;
                    }
                    else
                    {
                        currentCount = 1;       
                    }
                }
                else
                {
                    // If current element is not bigger means it's equal to previous and counting continues
                    currentCount++;
                }
            }

            if (currentCount > bestCount)
            {
                bestCount = currentCount;
                indexSave = length - 1;
            } 

            Console.WriteLine("Most frequent number is: ({0}) repeated {1} times", sortedArray[indexSave], bestCount);
        }

        private static void Input(int[] inputArray)
        {
            for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
            {
                // Internal cycle for correct input
                int breakcount = 3;
                do
                {
                    Console.Write(" element " + (arrIndex + 1) + " - ");
                    string temp = Console.ReadLine();
                    bool correctInput = int.TryParse(temp, out inputArray[arrIndex]);
                    if (correctInput)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input number! Try again.");
                    }

                    breakcount--;

                    if (breakcount <= 0)
                    {
                        Console.WriteLine("Error limit reached! Exit");
                        Environment.Exit(0);
                    }
                }
                while (true);
            }
        }

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
                if (rightIndexCount == rightArr.Length ||
                    (leftIndexCount < leftArr.Length && leftArr[leftIndexCount] <= rightArr[rightIndexCount]))
                {
                    resultArray[arrIndex] = leftArr[leftIndexCount];
                    leftIndexCount++;
                }
                else if (leftIndexCount == leftArr.Length || (rightIndexCount < rightArr.Length && rightArr[rightIndexCount] <= leftArr[leftIndexCount]))
                {
                    resultArray[arrIndex] = rightArr[rightIndexCount];
                    rightIndexCount++;
                }
            }

            return resultArray;
        }
    }
}
