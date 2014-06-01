namespace FindMaxElementInPortionOfArray
{
    using System;

    /*Write a method that return the maximal element in a portion of array of integers starting 
    at given index. Using it write another method that sorts an array in ascending / descending order*/

    public class FindMaxElementInPortionOfArray
    {
        private static void Main()
        {
            Console.Title = "Finds max elements in portion of array";
            // Input array length
            int arrayLength = 15;

            // Input array
            int[] array = new int[arrayLength];
            ArrayRandomizer(array);

            // Print array
            Console.WriteLine("Unsorted");
            PrintArray(array);
            Console.WriteLine();

            // Method FindMaxAfterIndex
            int maxNumberIndex = FindMaxElementAfterIndex(array);
            Console.WriteLine("Maximal number in the array is: {0}", array[maxNumberIndex]);

            // Sort array descending 
            SortDescending(array);

            // Print array
            Console.WriteLine("Sorted descending");
            PrintArray(array);
            Console.WriteLine();

            // Sort ascending
            SortAscending(array);

            // Print array
            Console.WriteLine("Sorted ascending");
            PrintArray(array);
            Console.WriteLine();
        }

        private static void ArrayRandomizer(int[] array)
        {
            Random randomGenerator = new Random();
            for (int index = 0; index < array.Length; index++)
            {
                int nextNumber = randomGenerator.Next(-256, 255);
                array[index] = nextNumber;
            }
        }

        private static int FindMaxElementAfterIndex(int[] array, int index = 0)
        {
            int maxElement = int.MinValue; // Keeps current maximal element

            // Cycle from entered index to array end
            for (int curentIndex = index; curentIndex < array.Length; curentIndex++) 
            {
                int currentEl = array[curentIndex];

                // if current element is bigger than max element keep it's value and index
                if (maxElement < currentEl) 
                {
                    maxElement = currentEl;
                    index = curentIndex;
                }
            }

            return index;
        }

        private static void SortDescending(int[] array)
        {
            for (int currentIndex = 0; currentIndex < array.Length; currentIndex++)
            {
                int maxMemberIndex = FindMaxElementAfterIndex(array, currentIndex); // Find max element

                // swap max and current element
                {
                    int swap = array[currentIndex];
                    array[currentIndex] = array[maxMemberIndex];
                    array[maxMemberIndex] = swap;
                }
            }
        }

        private static void SortAscending(int[] array)
        {
            // Reverse descending order
            SortDescending(array);
            Array.Reverse(array);
        }

        private static void PrintArray(int[] array)
        {
            string result = string.Join(", ", array);
            Console.WriteLine("Array: {0}", result);
        }
    }
}
