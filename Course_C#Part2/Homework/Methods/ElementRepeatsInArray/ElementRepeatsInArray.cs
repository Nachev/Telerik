namespace ElementRepeatsInArray
{
    using System;

    /*Write a method that counts how many times given number appears in given array. 
     * Write a test program to check if the method is working correctly*/

    public class ElementRepeatsInArray
    {
        private static void Main()
        {
            Console.Title = "Count equal elements in array";

            // int arrayLength = new int();
            // arrayLength = InputCheck("array lenght");
            int element = new int();
            element = 7; // InputCheck("required element");

            int[] array = { 2, 1, 56, 12, 7, 53, 4, 7, 7, 12, 2, 5, 7, 365, 4, 95, 123, 7, 5 }; // new int[arrayLength];
            // ArrayInput(array);
            ArrayPrint(array);

            PrintResult(element, array);
        }

        private static void PrintResult(int element, int[] array)
        {
            int repeatCounter = CountRepeatness(array, element);

            if (repeatCounter == 0)
            {
                Console.WriteLine("Element {0} is not found in this array", element);
            }
            else
            {
                Console.WriteLine("Element {0} appears {1} times in the array", element, repeatCounter);
            }
        }

        private static int CountRepeatness(int[] array, int element)
        {
            int counter = new int();

            foreach (var member in array)
            {
                if (member == element)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int InputCheck(string name)
        {
            int inputValue = new int();
            int breakCount = 5;

            do
            {
                Console.Write("Enter value for {0} : ", name);
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out inputValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached!! Exiting.");
                    Environment.Exit(0);
                }
            } 
            while (breakCount > 0);

            return inputValue;
        }

        private static void ArrayInput(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = InputCheck(string.Format("element {0}", index + 1));
            }
        }

        private static void ArrayPrint(int[] array)
        {
            string result = string.Join(", ", array);
            Console.WriteLine("Array is : { " + result + " };");
        }
    }
}
