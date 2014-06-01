using System;

/*Write a program that reads two arrays from the console and compares them element by element.*/

public class ArrayCompare
{
    private static void Main()
    {
        Console.Title = "Array compare";
        Console.WriteLine("Enter elements of the arrays:");

        double[] firstArray = { 12.45, 23, 45.75, 4535.467654357, 45 };
        double[] secondArray = { 45.1224, 23, 486.45, 788, 48.4567, 89.5687 };

        // First array input with error check
        // ArrInput(firstArray, "First");

        Console.WriteLine();

        // Second array input with error check
        // ArrInput(secondArray, "Second");

        Console.WriteLine();

        // Check length of arrays to ensure there will be no missed elements
        int length = Math.Min(firstArray.Length, secondArray.Length);

        // Compare elements one by one
        for (int index = 0; index < length; index++)
        {
            if (firstArray[index] > secondArray[index])
            {
                Console.WriteLine("First array element {0} - {1} is greater", index + 1, firstArray[index]);
            }
            else if (firstArray[index] < secondArray[index])
            {
                Console.WriteLine("Second array element {0}  - {1} is greater", index + 1, secondArray[index]);
            }
            else
            {
                Console.WriteLine("Elements {0} are equal.", index + 1);
            }
        }
    }

    private static void ArrInput(double[] array, string name)
    {
        // Array input loop with error check
        for (int index = 0; index < array.Length; index++)
        {
            while (true)
            {
                Console.Write("{0} array element {1} :", name, index + 1);
                string temp = Console.ReadLine();
                bool correctInput = double.TryParse(temp, out array[index]);
                if (correctInput)
                {
                    break;
                }
                else
                {
                    Console.Write("Wrong input!. Try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
