using System;

/*Write a program that finds the maximal sequence of equal elements in an array.
 * Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.*/

public class MaximalSequensOfEqualElements
{
    public static void Main()
    {
        Console.Title = "Maximal sequence of equal elements";

        int[] inputArray = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int resultIndex = new int();
        int maxCounter = new int();
        int counter = new int();
        bool notFirst = new bool();

        /*// Array input
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
            }
            while (breakCount > 0);
        }*/

        // Solve
        for (int arrIndex = 0; arrIndex < inputArray.Length; arrIndex++)
        {
            // Check if current element is equal to previous . If current is first continue
            if (notFirst && (inputArray[arrIndex] == inputArray[arrIndex - 1]))
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
        Console.WriteLine();
        Console.Write("Maximal sequence is: { ");
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