namespace SumOfSequenceInArray
{
    using System;
    using System.Text;

    /*Write a program that finds in given array of integers a sequence of given sum S (if present). 
    Example: {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}*/

    public class SumOfSequenceInArray
    {
        private static void Main()
        {
            Console.Title = "Find given sum in array";

            int[] inputArray = { 4, 3, 1, 4, 2, 5, 8 };

            // Input cycle
            // ArrInput(inputArray);

            int sum = 11;

            // sum = SumInput(sum);

            // Variable that keeps current sum
            int currentSum = new int();

            /*//variable that keeps current biggest sum
            //int bestSum = new int();*/

            // Variable that keeps starting index for the result sequence
            int resultSeqStart = new int();

            // Variable that keeps final index for the result sequence
            int resultSeqStop = inputArray.Length;

            // Flag used to mark that current sum is bigger than required
            bool isTooBig = new bool();

            int length = inputArray.Length;
            for (int arrIndex = 0; arrIndex < length; arrIndex++)
            {
                // If current sum is too big do not add another element
                if (!isTooBig)
                {
                    currentSum += inputArray[arrIndex];
                }
                else
                {
                    isTooBig = false;
                }

                // Check if current sum has reached required sum
                if (currentSum == sum)
                {
                    resultSeqStop = arrIndex;
                    break;
                }
                else
                {
                    // if current sum becomes equal or less than zero - new start index asign
                    if (currentSum <= 0)
                    {
                        resultSeqStart = arrIndex + 1;
                        currentSum = 0;
                    }
                }

                // If current sum becomes bigger than required one, substract first element from it
                if (currentSum > sum)
                {
                    currentSum -= inputArray[resultSeqStart];
                    resultSeqStart++;
                    arrIndex--;
                    isTooBig = true;
                }
            }

            if (currentSum == sum)
            {
                // Print the result
                ResultPrint(inputArray, resultSeqStart, resultSeqStop);
            }
            else
            {
                Console.WriteLine("There is no sequence resulting required sum - {0}", sum);
            }
        }

        private static int SumInput(int sum)
        {
            // Requred sum input
            Console.Write("Enter sum value: ");

            int breakCount = 3;

            do
            {
                string temp = Console.ReadLine();
                bool correctInput = int.TryParse(temp, out sum);
                if (correctInput)
                {
                    break;
                }
                else
                {
                    Console.Write("Wrong input!! Try again: ");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting");
                }
            }
            while (true);

            return sum;
        }

        private static void ResultPrint(int[] inputArray, int resultSeqStart, int resultSeqStop)
        {
            StringBuilder result = new StringBuilder();
            result.Append("Resulting sequence is: { ");

            for (int index = resultSeqStart; index <= resultSeqStop; index++)
            {
                result.Append(inputArray[index]).Append(',').Append(" ");
            }

            result.Remove(result.Length - 2, 1);
            result.Append("}");

            Console.WriteLine(result.ToString());
        }

        private static void ArrInput(int[] inputArray)
        {
            Console.WriteLine("Enter array elements:");

            for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
            {
                // Internal cycle for correct input
                int breakCount = 3;

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

                    breakCount--;

                    if (breakCount <= 0)
                    {
                        Console.WriteLine("Error limit reached!! Exit!");
                        Environment.Exit(0);
                    }
                }
                while (true);
            }
        }
    }
}
