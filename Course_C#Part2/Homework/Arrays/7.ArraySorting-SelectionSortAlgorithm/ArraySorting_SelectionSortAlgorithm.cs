using System;

/*Sorting an array means to arrange its elements in increasing order. 
//Write a program to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, find the smallest 
//from the rest, move it at the second position, etc*/

public class ArraySorting_SelectionSortAlgorithm
{
    public static void Main()
    {
        Console.Title = "Slection sort";

        double[] inputArray = { 4.53, 4.16, 5, 89, 12.54, -7.32, 23 };

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

        // Sorting by "Selection sort" algorithm
        for (int extIndex = 0; extIndex < inputArray.Length - 1; extIndex++)
        {
            double minNumber = inputArray[extIndex];
            int indexSave = new int();
            bool isThereSmaller = new bool();

            // Internal cycle for finding smallest value
            for (int intIndex = extIndex + 1; intIndex < inputArray.Length; intIndex++)
            {
                if (minNumber > inputArray[intIndex])
                {
                    isThereSmaller = true;
                    minNumber = inputArray[intIndex];
                    indexSave = intIndex;
                }
            }

            // Exchange places there is smaller number
            if (isThereSmaller)
            {
                double changer = inputArray[extIndex];
                inputArray[extIndex] = inputArray[indexSave];
                inputArray[indexSave] = changer;    
            }
        }

        /*//sorting cycle variant
        //for (int extindex = 0; extindex < inputarray.length; extindex++)
        //{
        //    for (int intindex = extindex; intindex < inputarray.length; intindex++)
        //    {
        //        if (inputarray[intindex] < inputarray[extindex] )
        //        {
        //            double changer = inputarray[extindex];
        //            inputarray[extindex] = inputarray[intindex];
        //            inputarray[intindex] = changer;
        //        }
        //    }
        //}*/

        // Print result
        Console.Write("Sorted array is: ");

        foreach (var item in inputArray)
        {
            Console.Write(item + ", ");
        }

        Console.WriteLine("\b\b  ");
    }
}