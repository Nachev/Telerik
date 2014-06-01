namespace TypeOfInput
{
    using System;

    /*Write a program that, depending on the user's choice inputs int, double or string variable. 
     * If the variable is integer or double, increases it with 1. If the variable is string, 
     * appends "*" at its end. The program must show the value of that variable as a console output. 
     * Use switch statement*/

    public class TypeOfInput
    {
        public static void Main()
        {
            Console.Write("Enter variable: ");
            string input = Console.ReadLine();

            int key = new int();
            int integerIn = new int();
            double doubleIn = new double();

            // Check for int or double with tryparse
            if (int.TryParse(input, out integerIn))
            {
                key = 1;
            }
            else if (double.TryParse(input, out doubleIn))
            {
                key = 2;
            }
            else
            {
                key = 3;
            }

            switch (key)
            {
                case 1:
                    integerIn++;
                    Console.WriteLine("Entered variable is integer. Result: {0}", integerIn);
                    break;
                case 2:
                    doubleIn++;
                    Console.WriteLine("Entered varable is double. Result: {0:0.00}", doubleIn);
                    break;
                case 3:
                    Console.WriteLine("Entered variable is string. Result :" + input + "*");
                    break;
                default:
                    Console.WriteLine((string)input + '*');
                    break;
            }
            
            // OR For double and integer requirement is the same + 1.
            double real = new double();
            switch (double.TryParse(input, out real))
            {
                case true:
                    Console.WriteLine("Result is: {0}", real + 1);
                    break;
                case false:
                    Console.WriteLine("Result is " + input + "*");
                    break;
                default:
                    break;
            }
        }
    }
}
