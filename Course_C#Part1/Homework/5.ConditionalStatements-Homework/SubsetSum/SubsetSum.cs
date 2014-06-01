namespace SubsetSum
{
    using System;

    /*We are given 5 integer numbers. Write a program that checks if the sum 
     * of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0*/

    public class SubsetSum
    {
        public static void Main()
        {
            Console.WriteLine("Enter five integers");
            int firstInt = new int();
            int insaneCount = 10;

            // Input cycle for the first integer with error check
            do
            {
                Console.Write("Enter first integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out firstInt))
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

            int secondInt = new int();
            insaneCount = 10;

            // Input cycle for the second integer with error check
            do
            {
                Console.Write("Enter second integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out secondInt))
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

            int thirdInt = new int();
            insaneCount = 10;

            // Input cycle for the third integer with error check
            do
            {
                Console.Write("Enter third integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out thirdInt))
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
            
            int fourthInt = new int();
            insaneCount = 10;

            // Input cycle for the fourth integer with error check
            do
            {
                Console.Write("Enter fourth integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out fourthInt))
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

            int fifthInt = new int();
            insaneCount = 10;

            // Input cycle for the fifth integer with error check
            do
            {
                Console.Write("Enter fifth integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out fifthInt))
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

            // Print desired binary mask
            Console.WriteLine("Binary combination mask: " + Convert.ToString((int)(Math.Pow(2, 5) - 1), 2));

            // Create the mask
            int mask = (int)Math.Pow(2, 5) - 1;

            // Counter that counts number of subsequents equal to zero
            int check = new int();

            // Cycle through possible combinations
            for (int combination = 1; combination <= mask; combination++)
            {
                bool isChecked = false;
                int currentSum = new int();
                for (int currInt = 0; currInt < 5; currInt++)
                {
                    if (((combination >> currInt) & 1) == 1)
                    {
                        isChecked = true;
                        switch (currInt)
                        {
                            case 0:
                                currentSum += firstInt;
                                break;
                            case 1:
                                currentSum += secondInt;
                                break;
                            case 2:
                                currentSum += thirdInt;
                                break;
                            case 3:
                                currentSum += fourthInt;
                                break;
                            case 4:
                                currentSum += fifthInt;
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                    }
                }

                // check the condition and if current combination is tested
                if (currentSum == 0 && isChecked)
                {
                    Console.WriteLine("Yes there are {0} combinations equl to zero", check + 1);
                    check++;
                }
            }

            if (check == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
