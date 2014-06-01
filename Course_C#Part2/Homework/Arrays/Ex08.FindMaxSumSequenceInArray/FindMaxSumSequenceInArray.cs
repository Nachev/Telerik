using System;

/*Write a program that finds the sequence of maximal sum in given array. Example:
 * {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
 * Can you do it with only one loop (with single scan through the elements of the array)?*/

public class FindMaxSumSequenceInArray
{
    public static void Main()
    {
        Console.Title = "Sequence of maximal sum";

        double[] inputArray = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        /*// Input cycle
        Console.WriteLine("Enter array elements:");
        for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
        {
            // Internal cycle for correct input
            do
            {
                Console.Write(" element " + (arrIndex + 1) + " - ");
                string temp = Console.ReadLine();
                bool correctInput = double.TryParse(temp, out inputArray[arrIndex]);
                if (correctInput)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input number! Try again.");
                }
            }
            while (true);
        }*/

        // Variable that keeps current sum
        double currentSum = new double();

        // Variable that keeps current biggest sum
        double bestSum = new double();

        // Variable that keeps starting index for the result sequence
        int resultSeqStart = new int();

        // Variable that keeps final index for the result sequence
        int resultSeqStop = inputArray.Length;
        int length = inputArray.Length;

        // Flag used to mark the beginning of new result sequence
        bool isNewSequence = new bool();
        for (int arrIndex = 0; arrIndex < length; arrIndex++)
        {
            // Variable to save the sum before adding current element
            double previousSum = currentSum;
            currentSum += inputArray[arrIndex];

            // Check if sum is growing
            if (currentSum > previousSum)
            {
                // The following block ensures that the last element will not be missed
                // Check if the last index is reached and sum is bigger than the last best one
                if (arrIndex == length - 1 && currentSum > bestSum)
                {
                    if (isNewSequence)
                    {
                        resultSeqStart = arrIndex;
                    }

                    resultSeqStop = arrIndex;
                    break;
                }
                else
                {
                    // If this is the beginning of new result sequence set start index
                    if (isNewSequence)
                    {
                        resultSeqStart = arrIndex;
                        isNewSequence = false;
                    }

                    continue;        
                }
            }
            else
            {
                // Save current best sum and the final index of result sequence
                if (previousSum > bestSum)
                {
                    bestSum = previousSum;
                    resultSeqStop = arrIndex - 1;
                }
                else if (currentSum <= 0)
                {
                    isNewSequence = true;
                    currentSum = 0;
                }
            }
        }

        // Print the result
        Console.Write("The sequence of maximal sum is: ");

        for (int index = resultSeqStart; index <= resultSeqStop; index++)
        {
            Console.Write(inputArray[index] + ", ");
        }

        Console.WriteLine("\b\b  ");
    }
}