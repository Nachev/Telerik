namespace IntAsArray
{
    using System;
    using System.Threading;

    /*Write a method that adds two positive integer numbers represented as arrays of digits 
     * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
     * Each of the numbers that will be added could have up to 10 000 digits*/

    public class AddIntArrays
    {
        private static void Main()
        {
            Console.Title = "Add integers as arrays";

            int firstArrayLength = InputCheck("first integer length");
            IntAsArray firstArray = new IntAsArray(firstArrayLength); // Using custom class IntAsArray
            firstArray.Randomize();
            Console.WriteLine("First integer is : {0}", firstArray.ToString());

            int secondArrayLength = InputCheck("second integer length");
            IntAsArray secondArray = new IntAsArray(secondArrayLength);
            secondArray.Randomize();
            Console.WriteLine("Second integer is : {0}", secondArray.ToString());

            IntAsArray result = firstArray + secondArray;
            Console.WriteLine("Result is : {0}", result.ToString());
        }

        private static int InputCheck(string name)
        {
            // Input block with error check
            int inputValue = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter value for {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out inputValue);
                if (check && inputValue > 0)
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
    }
}
