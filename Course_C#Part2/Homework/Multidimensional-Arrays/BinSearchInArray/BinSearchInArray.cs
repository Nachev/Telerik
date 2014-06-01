namespace BinSearchInArray
{
    using System;
    using System.Collections;
    using System.Text;

    /*Write a program, that reads from the console an array of N integers and an integer K, 
     * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K*/

    public class BinSearchInArray
    {
        public static void Main()
        {
            Console.Title = "BinSearch";

            // Input for array length
            int arrLength = new int();
            while (arrLength <= 0)
            {
                arrLength = Input("N");
            }

            // Input for searched value
            int wantedValue = Input("K");

            int[] arr = new int[arrLength];

            // Filling the array with random numbers instead of writing them in the console
            arr = RandomFill(arr);

            // Print filled array
            Console.WriteLine("Random array is:");
            Print(arr);

            // Sort the array using isertion sort
            arr = InsertionSort(arr);

            // Print sorted array
            Console.WriteLine("Sorted array is:");
            Print(arr);

            // Searching for wanted item
            Console.WriteLine("Search results:");
            int index = Array.BinarySearch(arr, wantedValue);
            ShowWhere(arr, index);            
        }

        public static int Input(string varName)
        {
            int input = new int();
            int breakCount = 10;
            do
            {
                Console.Write("Enter value for {0}: ", varName);
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again:");
                }

                breakCount--;
            } 
            while (breakCount > 0);

            return input;
        }

        public static int[] RandomFill(int[] array)
        {
            Random rand = new Random();
            int length = array.Length;

            for (int index = 0; index < length; index++)
            {
                array[index] = rand.Next(100);
            }

            return array;
        }

        public static int[] InsertionSort(int[] arr)
        {
            int length = arr.Length;
            for (int count = 0; count < length; count++)
            {
                int value = arr[count];
                int index = count;

                while (index > 0 && arr[index - 1] >= value)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }

                arr[index] = value;
            }

            return arr;
        }

        public static void Print(int[] array)
        {
            StringBuilder line = new StringBuilder();
            int length = array.Length;
            Console.WriteLine("\nBegining of print");

            for (int index = 0; index < length; index++)
            {
                line.Append("(").Append(index).Append(")-> ");
                line.Append(array[index]).Append(", ");

                if (line.Length >= Console.WindowWidth - 9)
                {
                    Console.WriteLine(line.ToString());
                    line.Clear();
                }
            }

            Console.WriteLine("{0}\nEnd of print", line.ToString());
            Console.WriteLine();
        }

        public static void ShowWhere(int[] array, int index)
        {
            if (index < 0)
            {
                /*If the index is negative, it represents the bitwise 
                complement of the next larger element in the array.*/

                index = ~index;

                Console.Write("Not found. Largest number is: ");

                if (index == 0)
                {
                    Console.WriteLine("{0} ", array[index]);
                }
                else
                {
                    Console.WriteLine("{0} ", array[index - 1]);
                }
            }
            else
            {
                Console.WriteLine("Found at index {0}.", index);
            }
        }
    }
}
