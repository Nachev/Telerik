using System;

/*Write a program that finds the maximal increasing sequence in an array. Example:
 * {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.*/

public class MaximalIncreasingSequenceInArray
{
    public static void Main()
    {
        Console.Title = "Maximal increasing sequence";

        // Array input
        double[] inputArray = { 3, 2, 3, 4, 2, 2, 4 };
        int resultIndex = new int();
        int maxCounter = new int();
        int counter = new int();
        bool notFirst = new bool();

        /* // Array input
        for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
        {
            // Internal cycle for correct input
            int breakCount = 3;

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

                breakCount--;
            }
            while (breakCount > 0);
        }*/

        // Solve
        for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
        {
            // Check if current element is bigger than previous . If current is first continue
            if (notFirst && (inputArray[arrIndex] > inputArray[arrIndex - 1]))
            {
                counter++; 

                // Check if this is the last element
                if ((arrIndex + 1 >= inputArray.Length) && (counter > maxCounter))
                {
                    maxCounter = counter;
                    resultIndex = arrIndex;
                }
            }
            else
            {
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    resultIndex = arrIndex - 1;
                    counter = 0;
                }
                else
                {
                    counter = 0;
                }
            }

            notFirst = true;
        }

        // Print result in required format
        Console.Write("\nMaximal increasing sequence is: ");
        Console.Write("{ ");
        for (int arrIndex = resultIndex - maxCounter; arrIndex <= resultIndex; arrIndex++)
        {
            Console.Write(inputArray[arrIndex]);
            if (arrIndex < resultIndex)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine("}");
    }
}
