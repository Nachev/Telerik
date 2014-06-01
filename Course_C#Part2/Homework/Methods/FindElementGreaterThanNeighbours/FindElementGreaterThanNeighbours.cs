namespace FindElementGreaterThanNeighbours
{
    using System;

    /* Write a method that returns the index of the first element in array that is bigger 
    than its neighbors, or -1, if there’s no such element.
    Use the method from the previous exercise. */

    public class FindElementGreaterThanNeighbours
    {
        private static void Main()
        {
            Console.Title = "First in array bigger than it's neighbours";

            int[] inputArr = new int[25];
            RandomizeArray(inputArr);

            PrintArray(inputArr);

            PrintResult(inputArr);
        }

        private static void PrintResult(int[] inputArr)
        {
            byte[] condition = new byte[2];
            int resultIndex = new int();
            resultIndex = FindGreatOne(inputArr, condition);

            if (resultIndex >= 0)
            {
                Console.WriteLine("Element with index {0} is the first one greater than it's neighbours", resultIndex);
            }
            else
            {
                Console.WriteLine("There is no element greater than it's neighbours.");
            }
        }

        private static int FindGreatOne(int[] inputArray, byte[] condition)
        {
            bool isGreater = new bool();
            int length = inputArray.Length - 1;
            for (int index = 1; index < length; index++)
            {
                isGreater = true;
                CompareNeighbours(inputArray, condition, index);

                for (int count = 0; count <= 1; count++)
                {
                    if (condition[count] != 1)
                    {
                        isGreater = false;
                    }
                }

                if (isGreater)
                {
                    return index;
                }
            }

            return -1;
        }

        private static byte[] CompareNeighbours(int[] arr, byte[] condition, int index)
        {
            if (index > 0)
            {
                // Check if bigger than smaller index
                if (arr[index] > arr[index - 1])
                {
                    // Bigger than smaller indexed
                    condition[0] = 1;
                }
                else
                {
                    // Not bigger than smaller indexed element
                    condition[0] = 0;
                }
            }
            else
            {
                // No smaller indexed element
                condition[0] = 2;
            }

            if (index < arr.Length - 1)
            {
                // Check if bigger than greater index
                if (arr[index] > arr[index + 1])
                {
                    // Bigger than greater indexed
                    condition[1] = 1;
                }
                else
                {
                    // Not bigger than greater indexed element
                    condition[1] = 0;
                }
            }
            else
            {
                // No greater indexed element
                condition[1] = 2;
            }

            return condition;
        }

        private static void RandomizeArray(int[] randArr)
        {
            Random randomGen = new Random();

            for (int count = 0; count < randArr.Length; count++)
            {
                randArr[count] = randomGen.Next(-258, 257);
            }
        }

        private static void PrintArray(int[] inputArray)
        {
            Console.WriteLine("Array elements are:");
            for (int index = 0; index < inputArray.Length; index++)
            {
                Console.WriteLine("index {0} -> {1}", index, inputArray[index]);
            }
        }
    }
}
