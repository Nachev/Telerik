namespace MathOperationsOnIntSet
{
    using System;
    using System.Numerics;

    /*Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
     * Use variable number of arguments.*/

    public class MathOperationsOnIntSet
    {
        private static void Main()
        {
            while (true)
            {
                Console.Title = "Operations over set of integers";
                int length = IntInput("set length", 0);
                int[] set = new int[length];
                InputSelector(set);

                while (true)
                {
                    bool newSet = new bool();
                    int choice = new int();
                    PrintMenu();
                    choice = IntInput("menu choice", 0, 7);
                    switch (choice)
                    {
                        case 1: MinimumOfSet(set);
                            break;
                        case 2: MaximumOfSet(set);
                            break;
                        case 3: AverageOfSet(set);
                            break;
                        case 4: SumOfSet(set);
                            break;
                        case 5: ProductOfSet(set);
                            break;
                        case 6: newSet = true;
                            break;
                        case 7: Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                    if (newSet)
                    {
                        break;
                    }
                }
            }
        }

        private static void InputSelector(int[] set)
        {
            InputSelectorMenu();
            int inputSelect = IntInput("choice for input method", 0, 2);
            switch (inputSelect)
            {
                case 1: SetInput(set);
                    break;
                case 2: RandomizeIntArr(set);
                    break;
                default:
                    break;
            }
        }

        private static void InputSelectorMenu()
        {
            Console.WriteLine("Select set input method");
            Console.WriteLine("1. Manual");
            Console.WriteLine("2. Automatic");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Calculate minimum of set");
            Console.WriteLine("2. Calculate maximum of set");
            Console.WriteLine("3. Calculate average of set");
            Console.WriteLine("4. Calculate sum of set");
            Console.WriteLine("5. Calculate product of set");
            Console.WriteLine("6. Enter new set");
            Console.WriteLine("7. Exit");
        }

        private static int IntInput(string name, int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        {
            int breakCount = 3;
            int input = new int();
            do
            {
                Console.Write("Enter {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out input);
                if (check && input > lowerLimit && input <= upperLimit)
                {
                    break;
                }
                else
                {
                    if (breakCount <= 0)
                    {
                        Console.WriteLine("Error limit reached. Exiting");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!! Try again");
                    }
                }

                breakCount--;
            }
            while (true);

            return input;
        }

        private static void SetInput(int[] set)
        {
            int length = set.Length;
            for (int index = 0; index < length; index++)
            {
                set[index] = IntInput(string.Format("argument {0}", index + 1));
            }
        }

        private static void RandomizeIntArr(int[] set)
        {
            Random randomGenerator = new Random();
            for (int index = 0; index < set.Length; index++)
            {
                set[index] = randomGenerator.Next(sbyte.MinValue, sbyte.MaxValue);
            }

            PrintSet(set);
        }

        private static void PrintSet(int[] set)
        {
            Console.Write("Set is: ");
            Console.WriteLine("{ " + string.Join(", ", set) + " }");
            Console.WriteLine();
        }

        private static void MinimumOfSet(int[] set)
        {
            int minimum = int.MaxValue;
            for (int index = 0; index < set.Length; index++)
            {
                if (set[index] < minimum)
                {
                    minimum = set[index];
                }
            }

            Console.WriteLine("Minimum of this set is: {0}", minimum);
        }

        private static void MaximumOfSet(int[] set)
        {
            int maximum = int.MinValue;
            for (int index = 0; index < set.Length; index++)
            {
                if (set[index] > maximum)
                {
                    maximum = set[index];
                }
            }

            Console.WriteLine("Maximum of this set is: {0}", maximum);
        }

        private static void AverageOfSet(int[] set)
        {
            double average = new double();
            int length = set.Length;
            for (int index = 0; index < length; index++)
            {
                average += set[index];
            }

            average /= length;
            Console.WriteLine("The average of current set is : {0}", average);
        }

        private static void SumOfSet(int[] set)
        {
            int sum = new int();
            foreach (var item in set)
            {
                sum += item;
            }

            Console.WriteLine("The sum of current set is: {0}", sum);
        }

        private static void ProductOfSet(int[] set)
        {
            BigInteger product = 1;
            foreach (var item in set)
            {
                product *= item;
            }

            Console.WriteLine("The product of current set is : {0}", product);
        }
    }
}
