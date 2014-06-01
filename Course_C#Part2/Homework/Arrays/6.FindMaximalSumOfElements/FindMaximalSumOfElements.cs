using System;
using System.Collections.Generic;

/*Write a program that reads two integer numbers N and K and an array of N elements 
 * from the console. Find in the array those K elements that have maximal sum*/

public class FindMaximalSumOfElements
{
    public static void Main()
    {
        Console.Title = "Maximal sum in array";

        // N input with TryParse
        int lengthN = new int();
        int breakCount = 3;
        do
        {
            Console.Write("Enter integer N for array length: ");
            string temp = Console.ReadLine();
            bool correctInput = int.TryParse(temp, out lengthN);
            if (correctInput && lengthN < 100000 && lengthN > 1)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input for number N! Try again.");
            }

            breakCount--;

            if (breakCount <= 0)
            {
                Console.WriteLine("Error limit reached! Exit.");
                Environment.Exit(0);
            }
        }
        while (true);

        // K input with TryParse
        int sequenceK = new int();
        breakCount = 3;
        do
        {
            Console.Write("Enter integer K for sequence length: ");
            string temp = Console.ReadLine();
            bool correctInput = int.TryParse(temp, out sequenceK);
            if (correctInput && sequenceK < lengthN && sequenceK > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input for number K! Try again.");
            }

            breakCount--;

            if (breakCount <= 0)
            {
                Console.WriteLine("Error limit reached! Exit.");
                Environment.Exit(0);
            }
        } 
        while (true);
        List<double> array = new List<double>();

        // Array input with TryParse
        for (int arrIndex = 0; arrIndex < lengthN; arrIndex++)
        {
            breakCount = 3;

            do
            {
                Console.Write("Enter element {0} - ", arrIndex + 1);
                string temp = Console.ReadLine();
                double tempNumber = new double();
                bool correctInput = double.TryParse(temp, out tempNumber);
                if (correctInput)
                {
                    array.Add(tempNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for element {0}! Try again.", arrIndex + 1);
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exit.");
                    Environment.Exit(0);
                }
            }
            while (true);
        }

        // Those K elements with highest value are biggest K elements

        /* Sorting
         * array.Sort();*/

        // Direct check without sorting
        double sum = new double();
        List<double> result = new List<double>();
        int counter = sequenceK;
        while (counter > 0)
        {
            double maxElement = new double();

            // Find biggest element and add it to the sum and result List
            foreach (var number in array)
            {
                if (maxElement < number)
                {
                    maxElement = number;
                }
            }

            array.Remove(maxElement);
            result.Add(maxElement);
            sum += maxElement;
            counter--;
        }

        Console.Write("Biggest sum of " + sequenceK + " elements is - " + sum + " . Formed by { ");
        foreach (var number in result)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine("}");
    }
}
