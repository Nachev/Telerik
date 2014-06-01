namespace BinarySearch
{
    using System;

    /*Write a program that finds the index of given element in a sorted array 
     * of integers by using the binary search algorithm (find it in Wikipedia)*/

    public class BinarySearch
    {
        private static void Main()
        {
            Console.Title = "Binary search";

            int[] inputArray = { 9, 3, 5, 65, 13, 56, 4, 75, 37 };

            // Input(inputArray);

            // Searched element input
            int elementX = 3; // SearchedElementInput();

            // Sorting
            BubbleSort(inputArray);

            // Visual test
            ArrPrint(inputArray);

            // Binary search
            BinarySearching(inputArray, elementX);
        }

        private static void BinarySearching(int[] inputArray, int elementX)
        {
            int minIndex = 0;
            int maxIndex = inputArray.Length - 1;

            // If minIndex becomes bigger than  maxIndex there is no such number in the array
            while (minIndex <= maxIndex)
            {
                // Middle point
                int searchIndex = minIndex + ((maxIndex - minIndex) / 2);

                // Higher indexes // Lower indexes // Min = max index found
                if (elementX > inputArray[searchIndex])
                {
                    minIndex = searchIndex + 1;
                }
                else if (elementX < inputArray[searchIndex])
                {
                    maxIndex = searchIndex - 1;
                }
                else
                {
                    Console.WriteLine("Searched index is {0}", searchIndex);
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("There is no such element in this array");
        }

        private static void ArrPrint(int[] inputArray)
        {
            Console.WriteLine("Sorted array:");
            int i = new int();
            foreach (var number in inputArray)
            {
                Console.WriteLine("Element {0} -> {1} ", i, number);
                i++;
            }
        }

        private static void BubbleSort(int[] inputArray)
        {
            /*Bubble sort with edit
             *for i = 1:n,
                swapped = false
                    for j = n:i+1, 
                        if a[j] < a[j-1], 
                            swap a[j,j-1]
                            swapped = true
            → invariant: a[1..i] in final position
                break if not swapped
            end*/

            int length = inputArray.Length;
            int lengthCopy = length;
            bool swapped = new bool();
            do
            {
                swapped = false;
                for (int index = 1; index < length; index++)
                {
                    if (inputArray[index] < inputArray[index - 1])
                    {
                        inputArray[index] ^= inputArray[index - 1];
                        inputArray[index - 1] ^= inputArray[index];
                        inputArray[index] ^= inputArray[index - 1];
                        swapped = true;
                    }
                }

                lengthCopy--;
            }
            while (swapped && lengthCopy > 0);
        }

        private static int SearchedElementInput()
        {
            int insaneCount = 10;
            Console.WriteLine("Enter element value to search for");
            int elementX = new int();
            do
            {
                Console.Write("X -> ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out elementX))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for X! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            return elementX;
        }

        private static void Input(int[] inputArray)
        {
            Console.WriteLine("Enter array elements:");
            int insaneCount = 3;

            // Input cycle for array
            for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
            {
                // Internal cycle for correct input
                do
                {
                    insaneCount--;
                    Console.Write("element {0} -> ", arrIndex);
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

                    if (insaneCount <= 0)
                    {
                        Console.WriteLine("Error limit reached! Exit.");
                        Environment.Exit(0);
                    }
                }
                while (true);
            }
        }
    }
}
