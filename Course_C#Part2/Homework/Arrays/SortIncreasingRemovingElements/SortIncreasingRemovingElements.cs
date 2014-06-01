namespace SortIncreasingRemovingElements
{
    using System;
    using System.Text;

    /*Write a program that reads an array of integers and removes from it a minimal number of elements in such 
     * way that the remaining array is sorted in increasing order. Print the remaining sorted array. 
     * Example:{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}*/

    public class SortIncreasingRemovingElements
    {
        private static void Main()
        {
            Console.WriteLine("Program that reads an array of integers");
            Console.WriteLine("Removes from it a minimal number of elements remaining sorted array in increasing order");
            int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 }; // new int[10];

            // Array input
            // ArrInput(arr);

            GrayCodeCalc(arr);
        }

        private static void GrayCodeCalc(int[] arr)
        {
            // Create binary mask with all possible combinations mask = Math.Pow(numbers count, 2) - 1;
            uint mask = 1;
            int length = arr.Length;
            mask <<= length;
            mask -= 1;

            // Print mask for visual check
            Console.WriteLine("Combination mask is: " + Convert.ToString(mask, 2));

            // Cycle all possible combinations
            int[] idxCollector = new int[arr.Length]; // Collects indexes of subset
            int maxCounter = new int(); // Save max subset length
            while (mask > 0)
            {
                int[] tempIdxColl = new int[idxCollector.Length]; // Collect current subset indexes
                int previousEl = int.MinValue; // Variable to store previous element of subset
                int counter = new int();
                for (int index = 0; index < length; index++)
                {
                    // Check if current element is element of the checked subset
                    if (((mask >> index) & 1) == 1)
                    {
                        // Check if order of the current subset is increasing
                        if (previousEl <= arr[index])
                        {
                            previousEl = arr[index];
                            tempIdxColl[counter] = index;
                            counter++;
                        }
                    }
                }

                // Check if current icreasing subset is longest one
                if (counter > maxCounter)
                {
                    maxCounter = counter;

                    // Save current index collection
                    for (int index = 0; index < counter; index++)
                    {
                        idxCollector[index] = tempIdxColl[index];
                    }
                }

                mask--;
            }

            CreateResultArray(arr, idxCollector, maxCounter);

            PrintResult(arr, maxCounter, idxCollector);
        }

        private static void CreateResultArray(int[] arr, int[] idxCollector, int maxCounter)
        {
            int[] resultArray = new int[maxCounter];
            for (int index = 0; index < maxCounter; index++)
            {
                resultArray[index] = arr[idxCollector[index]];
            }
        }

        private static void PrintResult(int[] arr, int length, int[] idxCollector)
        {
            StringBuilder resultArray = new StringBuilder();
            for (int index = 0; index < length; index++)
            {
                resultArray.Append(arr[idxCollector[index]]).Append(", ");
            }

            resultArray.Remove(resultArray.Length - 2, 2);
            Console.WriteLine("Result array is: { " + resultArray.ToString() + " }");
        }

        private static void ArrInput(int[] arr)
        {
            // Input block with check for correct input for array elements
            for (int index = 1; index <= arr.Length; index++)
            {
                int breakCount = 5;
                do
                {
                    Console.Write("Enter element {0} -> ", index);
                    if (int.TryParse(Console.ReadLine(), out arr[index - 1]))
                    {
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
    }
}
