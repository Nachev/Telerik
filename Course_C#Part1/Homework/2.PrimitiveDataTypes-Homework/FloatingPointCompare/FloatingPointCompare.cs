using System;

/*Write a program that safely compares floating-point numbers with precision of
 * 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true
*/

class FloatingPointCompare
{
    static void Main()
    {
        Console.WriteLine("Program for safely comparing of floating-point numbers \nwith precision of seven signs after decimal point");
        float number1 = 0.0f;
        float number2 = 0.0f;
        bool compare = new bool();
        do
        {
            Console.Write("Enter first number:");
            compare = float.TryParse(Console.ReadLine(), out number1);
            if (compare)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input! Try again.");
            }
        } while (true);
        do
        {
            Console.Write("Enter second number:");
            compare = float.TryParse(Console.ReadLine(), out number2);
            if (compare)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input! Try again.");
            }
        } while (true);
        compare = (number1 == number2);
        Console.WriteLine("Equasion is {0}", compare);
    }
}