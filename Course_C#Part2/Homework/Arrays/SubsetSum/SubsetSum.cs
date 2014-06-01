namespace SubsetSum
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /*We are given an array of integers and a number S. Write a program to find if there exists a 
     * subset of the elements of the array that has a sum S. 
     * Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)*/

    public class SubsetSum
    {
        private static void Main()
        {
            Console.Title = "Subset sums";

            int[] arr = { 2, 1, 2, 4, 3, 5, 67, 34, 123, 2, 6, 9, 0, -34, -1, 34, 5 };
            int inputSum = 183;

            // Remove duplicates if necessary
            arr = RemoveDuplicates(arr);

            ArrayPrint(arr);

            SubsetSums(arr, inputSum);
        }

        private static void SubsetSums(int[] arr, int inputSum)
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
                    // Check if current array element participates in the combination 
                    if (((mask >> counter) & 1) == 1)
                    {
                        currentSum += arr[counter];
                        sumElements.Add(arr[counter]);
                    }
                }

                // If there is a match print the result
                if (currentSum == inputSum)
                {
                    PrintResult(inputSum, sumElements);
                }

                mask--;
            }
        }

        private static void PrintResult(int inputSum, List<int> sumElements)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < sumElements.Count; index++)
            {
                result.Append(sumElements[index]).Append(" + ");
            }

            result.Remove(result.Length - 3, 3);
            Console.WriteLine("Yes -> ({0}) = {1}", result.ToString(), inputSum);
        }

        private static void ArrayPrint(IEnumerable array)
        {
            StringBuilder line = new StringBuilder();

            foreach (var number in array)
            {
                line.Append(number).Append(" ");
                int length = number.ToString().Length;

                if (line.Length >= Console.WindowWidth)
                {
                    line.Remove(line.Length - (length + 1), length);
                    Console.WriteLine(line.ToString());
                    line.Clear();
                    line.Append(number).Append(" ");
                }
            }

            Console.WriteLine(line.ToString());
        }

        private static int[] RemoveDuplicates(int[] arr)
        {
            arr = ArraySorter(arr);

            Console.WriteLine("Sorted array is: ");
            ArrayPrint(arr);
            Console.WriteLine();

            int length = arr.Length;

            for (int index = 0; index < arr.Length; index++)
            {
                int previous = index - 1;
                while (previous >= 0 && arr[index] == arr[previous])
                {
                    arr[previous] = int.MaxValue;
                    previous--;
                    length--;
                }
            }

            arr = ArraySorter(arr);
            int[] newArr = new int[length];

            for (int index = 0; index < length; index++)
            {
                newArr[index] = arr[index];
            }

            return newArr;
        }

        private static int[] ArraySorter(int[] arr)
        {
            int length = arr.Length;

            for (int index = 1; index < length; index++)
            {
                int swapIdx = index;

                while (arr[swapIdx] < arr[swapIdx - 1])
                {
                    int swap = arr[swapIdx];
                    arr[swapIdx] = arr[swapIdx - 1];
                    arr[swapIdx - 1] = swap;
                    swapIdx--;

                    if (swapIdx <= 0)
                    {
                        break;
                    }
                }
            }

            return arr;
        }
    }
}
