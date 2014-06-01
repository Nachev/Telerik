namespace SortRealNumbers
{
    using System;

    /* Sort 3 real values in descending order using nested if statements. */

    public class SortRealNumbers
    {
        public static void Main()
        {
            double firstReal = new double();
            int insaneCount = 10;

            // Input cycle for the first double with error check
            do
            {
                Console.Write("Enter first real number: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out firstReal))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            double secondReal = new double();
            insaneCount = 10;

            // Input cycle for the second double with error check
            do
            {
                Console.Write("Enter second double: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out secondReal))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            double thirdReal = new double();
            insaneCount = 10;

            // Input cycle for the third double with error check
            do
            {
                Console.Write("Enter third real number: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out thirdReal))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            double change = 0.00;
            if (firstReal < secondReal)
            {
                change = firstReal;
                firstReal = secondReal;
                secondReal = change;
                if (secondReal < thirdReal)
                {
                    secondReal = thirdReal;
                    thirdReal = change;
                }
            }
            else if (secondReal < thirdReal)
            {
                change = secondReal;
                secondReal = thirdReal;
                thirdReal = change;
                if (secondReal > firstReal)
                {
                    change = secondReal;
                    secondReal = firstReal;
                    firstReal = change;
                }
            }

            Console.WriteLine("{0:0.00} {1:0.00} {2:0.00}", firstReal, secondReal, thirdReal);
        }
    }
}
