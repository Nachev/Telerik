namespace NumberRepresentations
{
    using System;

    /*Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
     * percentage and in scientific notation. Format the output aligned right in 15 symbols.*/

    public class NumberRepresentations
    {
        private static void Main()
        {
            int inputNumber = IntInput();
            
            Console.WriteLine("{0:D}".PadLeft(15), inputNumber);
            Console.WriteLine("{0:X}".PadLeft(15), inputNumber);
            Console.WriteLine("{0:P}".PadLeft(15), inputNumber);
            Console.WriteLine("{0:E}".PadLeft(15), inputNumber);
        }

        private static int IntInput()
        {
            int output = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter integer number : ");
                string tempIn = Console.ReadLine();
                bool isCorrect = int.TryParse(tempIn, out output);
                if (isCorrect)
                {
                    break;
                }
                else
                {
                    if (breakCount > 0)
                    {
                        Console.WriteLine("Wrong input! Try again");
                    }
                    else
                    {
                        Console.WriteLine("Error limit reached! Exiting");
                        Environment.Exit(0);
                    }
                }

                breakCount--;
            }
            while (true);

            return output;
        }
    }
}
