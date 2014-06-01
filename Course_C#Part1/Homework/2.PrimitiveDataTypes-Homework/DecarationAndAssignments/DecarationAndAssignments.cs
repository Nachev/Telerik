namespace DecarationAndAssignments
{
    using System;

    class DecarationAndAssignments
    {
        static void Main()
        {
            /*Declare an integer variable and assign it with the value 254 in hexadecimal format. 
             * Use Windows Calculator to find its hexadecimal representation*/
            Console.WriteLine("Exercise 4\n");
            int Integer = 0xFE;
            Console.WriteLine("This is 0xFE in decimal - {0}", Integer);
            Console.WriteLine();
            /*Declare a character variable and assign it with the symbol that has Unicode code 72. 
             * Hint: first use the Windows Calculator to find the hexadecimal representation of 72*/
            Console.WriteLine("Exercise 5\n");
            char UnicSymbol = '\u0048';
            Console.WriteLine("This is unicode 72 - {0}", UnicSymbol);
            Console.WriteLine();
            /*Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender*/
            Console.WriteLine("Exercise 6\n");
            bool IsFemale = false;
            Console.WriteLine("\"I am female\" is {0}", IsFemale);
            Console.WriteLine();
            /*Declare two string variables and assign them with “Hello” and “World”. 
             * Declare an object variable and assign it with the concatenation of the first two variables 
             * (mind adding an interval). Declare a third string variable and initialize it with the value 
             * of the object variable (you should perform type casting).*/
            Console.WriteLine("Exercise 7\n");
            string firstWord = "Hello";
            string secondWord = "World";
            object wholeSentence = firstWord + " " + secondWord;
            Console.WriteLine(wholeSentence);
            string convertedSentence = (string)wholeSentence;
            Console.WriteLine(convertedSentence);
            Console.WriteLine();
            /*Declare two string variables and assign them with following value:
             * <The "use" of quotations causes difficulties>
             * Do the above in two different ways: with and without using quoted strings*/
            Console.WriteLine("Exercise 8\n");
            string firstSentence = "The \"use\" of quotations causes difficulties";
            Console.WriteLine(firstSentence);
            string secondSentence = @"The ""use"" of quotations causes difficulties";
            Console.WriteLine(secondSentence);
            Console.WriteLine();
            /*Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
             * Use Windows Character Map to find the Unicode code of the © symbol. 
             * Note: the © symbol may be displayed incorrectly*/
            Console.WriteLine("Exercise 9\n");
            char copyRight = '\u00A9';
            Console.WriteLine("  {0}\n {0}{0}{0}\n{0}{0}{0}{0}{0}", copyRight);
        }   
    }
}
