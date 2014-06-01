namespace GetMaxMethod
{
    using System;

    /*Write a method GetMax() with two parameters that returns the bigger of two integers.
     * Write a program that reads 3 integers from the console and prints the biggest of 
     * them using the method GetMax()*/

    public class GetMaxMethod
    {
        private static void Main()
        {
            Console.Title = "GetMax method";

            int firstInteger = Input("first test number");
            int secondInteger = Input("seconf test number");
            int thirdInteger = Input("third test number");
            int result = GetMax(firstInteger, GetMax(secondInteger, thirdInteger));
            Console.WriteLine("Biggest number is: {0}", result);
        }

        private static int GetMax(int firstInt, int secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }
            else
            {
                return secondInt;
            }
        }

        private static int Input(string name)
        {
            int inputValue = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter value for {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out inputValue);

                if (check)
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
            while (true);

            return inputValue;
        }
    }
}
