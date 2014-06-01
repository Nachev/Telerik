namespace FillStringIfNeccesary
{
    using System;

    /*Write a program that reads from the console a string of maximum 20 characters. 
     * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
     * Print the result string into the console.*/

    public class FillStringIfNeccesary
    {
        private const int MaxLength = 20;

        private static void Main()
        {
            string inputString = StrInput();
            int strLength = inputString.Length;
            if (strLength < MaxLength)
            {
                inputString += new string('*', MaxLength - strLength);
            }

            Console.WriteLine(inputString);
        }

        private static string StrInput()
        {
            string inputStr = string.Empty;
            int breakCount = 5;
            do
            {
                Console.Write("Enter string : ");
                inputStr = Console.ReadLine();
                if (inputStr.Length <= MaxLength)
                {
                    break;
                }
                else
                {
                    if (breakCount > 0)
                    {
                        Console.WriteLine("Wrong input! Input lenght must be less than {0}", MaxLength);
                    }
                    else
                    {
                        Console.WriteLine("Error limit reached! Exiting.");
                        Environment.Exit(0);
                    }
                }

                breakCount--;
            } 
            while (true);

            return inputStr;
        }
    }
}
