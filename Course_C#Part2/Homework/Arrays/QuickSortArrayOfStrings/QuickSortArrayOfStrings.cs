namespace QuickSortArrayOfStrings
{
    using System;

    /*Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia)*/

    public class QuickSortArrayOfStrings
    {
        /*// left is the index of the leftmost element of the subarray
// right is the index of the rightmost element of the subarray (inclusive)
// number of elements in subarray = right-left+1
function partition(array, left, right, pivotIndex)
 pivotValue := array[pivotIndex]
 swap array[pivotIndex] and array[right]  // Move pivot to end
 storeIndex := left
 for i from left to right - 1  // left ≤ i < right
     if array[i] <= pivotValue
         swap array[i] and array[storeIndex]
         storeIndex := storeIndex + 1  // only increment storeIndex if swapped
 swap array[storeIndex] and array[right]  // Move pivot to its final place
 return storeIndex*/
        private static int Partition(string[] arrStr, int left, int right, int pivotIndex)
        {
            string pivotValue = arrStr[pivotIndex];

            // Move pivot to end
            arrStr[pivotIndex] = arrStr[right];
            arrStr[right] = pivotValue;
            int storeIndex = left;

            for (int index = left; index < right; index++)
            {
                // If arrStr[index] <= pivotValue
                if (arrStr[index].CompareTo(pivotValue) <= 0)
                {
                    string temp = arrStr[storeIndex];
                    arrStr[storeIndex] = arrStr[index];
                    arrStr[index] = temp;
                    storeIndex++;
                }
            }

            // Move pivot to its final position
            arrStr[right] = arrStr[storeIndex];
            arrStr[storeIndex] = pivotValue;
            return storeIndex;
        }

        /*function quicksort(array, left, right)
 // If the list has 2 or more items
 if left < right
     // See "#Choice of pivot" section below for possible choices
     choose any pivotIndex such that left ≤ pivotIndex ≤ right
     // Get lists of bigger and smaller items and final position of pivot
     pivotNewIndex := partition(array, left, right, pivotIndex)
     // Recursively sort elements smaller than the pivot
     quicksort(array, left, pivotNewIndex - 1)
     // Recursively sort elements at least as big as the pivot
     quicksort(array, pivotNewIndex + 1, right)*/
        private static void QuickSort(string[] arrStr, int left, int right)
        {
            Random rand = new Random();

            // If the list has 2 or more items
            if (left < right)
            {
                // pivot random choice
                int pivotIndex = rand.Next(left, right + 1);

                // Get lists of bigger and smaller items and final position of pivot
                int pivotNewIndex = Partition(arrStr, left, right, pivotIndex);

                // Recursively sort elements smaller than the pivot
                QuickSort(arrStr, left, pivotNewIndex - 1);

                // Recursively sort elements at least as big as the pivot
                QuickSort(arrStr, pivotNewIndex + 1, right);
            }
        }

        private static void PrintArray(string[] arrStr)
        {
            foreach (var item in arrStr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private static void Input(string[] arrStr)
        {
            Console.WriteLine("Enter string array elements");
            for (int index = 0; index < arrStr.Length; index++)
            {
                Console.Write("Element {0} -> ", index + 1);
                arrStr[index] = Console.ReadLine();
            }
        }

        private static void Main()
        {
            Console.Title = "Qick sort of strings";

            // Create array of strings
            string[] arrStr = new string[10] 
            { 
                "faith", "job", "yankee", "fit", "old", "quest", "cod", "goat", "devil", "ten" 
            };

            // Input loop for string array
            // Input(arrStr);

            Console.WriteLine("Input array in alphabetical order is");
            PrintArray(arrStr);

            int left = 0;
            int right = arrStr.Length - 1;

            QuickSort(arrStr, left, right);

            Console.WriteLine("Sorted array in alphabetical order is");
            PrintArray(arrStr);
        }
    }
}
