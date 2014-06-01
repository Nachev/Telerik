namespace PositiveOrNegativeProduct
{
    using System;

    /*Write a program that shows the sign (+ or -) of the product of 
    three real numbers without calculating it. Use a sequence of if statements.*/

    public class PositiveOrNegativeProduct
    {
        public static void Main()
        {
            Console.Write("Enter first real number: ");
            double firstReal = new double();
            bool check1 = double.TryParse(Console.ReadLine(), out firstReal);
            Console.Write("Enter second real nubmer: ");
            double secondReal = new double();
            bool check2 = double.TryParse(Console.ReadLine(), out secondReal);
            Console.Write("Enter third real number: ");
            double thirdReal = new double();
            bool check3 = double.TryParse(Console.ReadLine(), out thirdReal);
            if (!(check1 && check2 && check3))
            {
                Console.WriteLine("Wrong input!!!");
                return;
            }

            Console.Write("The sign of the product of those three real nubmers is ");
            if (firstReal < 0 && secondReal < 0 && thirdReal < 0)
            {
                Console.WriteLine("-");
            }
            else if ((firstReal < 0 && secondReal < 0) || (secondReal < 0 && thirdReal < 0) || (firstReal < 0 && thirdReal < 0))
            {
                Console.WriteLine("+");
            }
            else if (firstReal < 0 || secondReal < 0 || thirdReal < 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }

            // Check
            Console.WriteLine(firstReal * secondReal * thirdReal);
        }
    }
}
