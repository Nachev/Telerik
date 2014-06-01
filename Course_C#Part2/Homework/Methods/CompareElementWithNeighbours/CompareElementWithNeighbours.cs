namespace CompareElementWithNeighbours
{
    using System;
    using System.Text;

    /*Write a method that checks if the element at given position in given array of integers 
     * is bigger than its two neighbors (when such exist)*/

    public class CompareElementWithNeighbours
    {
        private static void Main()
        {
            Console.Title = "Array neighbours check";

            // Lenght of the array input
            // int length = new int();
            // length = InputCheck("array length", 1);

            // Array input
            int[] container = 
            { 
                2, 5, 6, 1, 3, 7, 9, 6, 4, 1, 21, 3, 4, 78, 3, 45, 45, 5, 5, 45, 1, 3, 223, 0, 1, 2 
            }; // new int[length];
            // ArrInput(container);
            Console.WriteLine("Input string is : {0}", string.Join(", ", container));

            // Tested index input
            int index = 1; // new int();
            // index = InputCheck("checked index", 0, container.Length - 1);
            Console.WriteLine("Checked index is : {0}", index);

            // Solve
            byte[] condition = new byte[2];
            CompareNeighbours(container, condition, index);
            PrintResult(condition);
        }

        private static int InputCheck(string name, int lowLimit = int.MinValue, int upLimit = int.MaxValue)
        {
            // Input method with error check
            int inputValue = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter value for {0}: ", name);
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out inputValue) && inputValue >= lowLimit && inputValue <= upLimit)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            } 
            while (breakCount > 0);
            return inputValue;
        }

        private static void ArrInput(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                arr[index] = InputCheck(string.Format("element {0}", index));
            }
        }

        private static byte[] CompareNeighbours(int[] arr, byte[] condition, int index)
        {
            if (index > 0)
            {
                // Check if bigger than smaller index
                if (arr[index] > arr[index - 1])
                {
                    // Console.WriteLine("Bigger than smaller indexed");
                    condition[0] = 1;
                }
                else
                {
                    // Console.WriteLine("Not bigger than smaller indexed element");
                    condition[0] = 0;
                }
            }
            else
            {
                // Console.WriteLine("No smaller indexed element");
                condition[0] = 2;
            }

            if (index < arr.Length - 1)
            {
                // Check if bigger than greater index
                if (arr[index] > arr[index + 1])
                {
                    // Console.WriteLine("Bigger than greater indexed");
                    condition[1] = 1;
                }
                else
                {
                    // Console.WriteLine("Not bigger than greater indexed element");
                    condition[1] = 0;
                }
            }
            else
            {
                // Console.WriteLine("No greater indexed element");
                condition[1] = 2;
            }

            return condition;
        }

        private static void PrintResult(byte[] condition)
        {
            string[] conditionStr = { "Not bigger than ", "Bigger than ", "No " };
            string[] neighbour = { "smaller ", "greater " };
            StringBuilder result = new StringBuilder();

            // Cycle through the neighbours
            for (int count = 0; count <= 1; count++)
            {
                // Append to result string comparator result
                result.Append(conditionStr[condition[count]]);

                // Append which neighbour is addressed
                result.Append(neighbour[count]);
                result.Append("indexed element");
                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
