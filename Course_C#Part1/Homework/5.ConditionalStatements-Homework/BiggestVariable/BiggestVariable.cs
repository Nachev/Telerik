namespace BiggestVariable
{
    using System;
    using System.Text;

    /*Write a program that finds the greatest of given 5 variables*/

    public class BiggestVariable
    {
        public static void Main()
        {
            double firstVar = new double();
            int insaneCount = 10;

            // Input cycle for the first vaiable with error check
            do
            {
                Console.Write("Enter first variable: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out firstVar))
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

            double secondVar = new double();
            insaneCount = 10;

            // Input cycle for the second variable with error check
            do
            {
                Console.Write("Enter second variable: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out secondVar))
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

            double thirdVar = new double();
            insaneCount = 10;

            // Input cycle for the third variable with error check
            do
            {
                Console.Write("Enter third variable: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out thirdVar))
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

            double fourthVar = new double();
            insaneCount = 10;

            // Input cycle for the fourth variable with error check
            do
            {
                Console.Write("Enter fourth variable: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out fourthVar))
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

            double fifthVar = new double();
            insaneCount = 10;

            // Input cycle for the fifth variable with error check
            do
            {
                Console.Write("Enter fifth variable: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out fifthVar))
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

            StringBuilder result = new StringBuilder(); 

            // Nested if statements to check the condition
            if (firstVar > secondVar)
            {
                if (firstVar > thirdVar)
                {
                    if (firstVar > fourthVar)
                    {
                        if (firstVar > fifthVar)
                        {
                            result.Append(firstVar);
                        }
                        else
                        {
                            result.Append(fifthVar);
                        }
                    }
                    else if (fourthVar > fifthVar)
                    {
                        result.Append(fourthVar);
                    }
                    else
                    {
                        result.Append(fifthVar);
                    }
                }
                else if (thirdVar > fourthVar)
                {
                    if (thirdVar > fifthVar)
                    {
                        result.Append(thirdVar);
                    }
                    else
                    {
                        result.Append(fifthVar);
                    }
                }
                else if (fourthVar > fifthVar)
                {
                    result.Append(fourthVar);
                }
                else
                {
                    result.Append(fifthVar);
                }
            }
            else if (secondVar > thirdVar)
            {
                if (secondVar > fourthVar)
                {
                    if (secondVar > fifthVar)
                    {
                        result.Append(secondVar);
                    }
                    else
                    {
                        result.Append(fifthVar);
                    }
                }
                else if (fourthVar > fifthVar)
                {
                    result.Append(fourthVar);
                }
                else
                {
                    result.Append(fifthVar);
                }
            }
            else if (thirdVar > fourthVar)
            {
                if (thirdVar > fifthVar)
                {
                    result.Append(thirdVar);
                }
                else
                {
                    result.Append(fifthVar);
                }
            }
            else if (fourthVar > fifthVar)
            {
                result.Append(fourthVar);
            }
            else
            {
                result.Append(fifthVar);
            }

            Console.WriteLine("Biggest of those five variables is " + result.ToString());
        }
    }
}
