namespace MathTaskSolve
{
    using System;
    using System.Collections.Generic;

    /*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0*/

    public class MathTaskSolve
    {
        private static void Main()
        {
            Console.Title = "Math tasks solver";

            int choice = new int();
            PrintMenu();
            choice = IntInput("choice", true, 3);
            switch (choice)
            {
                case 1: ReverseDigits(); 
                    break;
                case 2: AverageOfaSequence(); 
                    break;
                case 3: LinearEquationSolver(); 
                    break;
                default: Console.Write("Error"); 
                    break;
            }
        }

        private static int IntInput(string name, bool positiveCheck = false, int upperLimit = int.MaxValue)
        {
            int breakCount = 3;
            int input = new int();
            do
            {
                Console.Write("Enter {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out input);
                if (check && (positiveCheck ? input > 0 : true) && input <= upperLimit)
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

        private static double DoubleInput(string name, bool isZeroCheck = false)
        {
            int breakCount = 3;
            double input = new double();
            do
            {
                Console.Write("Enter {0} : ", name);
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out input);
                if (check && (isZeroCheck ? input != 0 : true))
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

        private static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Reverses the digits of a number");
            Console.WriteLine("2. Calculates the average of a sequence of integers");
            Console.WriteLine("3. Solves a linear equation: a * x + b = 0");
        }

        private static void ReverseDigits()
        {
            int input = IntInput("number", true);
            int[] digits = IntToArray(input);
            string result = string.Join(string.Empty, digits);
            Console.WriteLine("Reversed number is : {0}", result);
        }

        private static int[] IntToArray(int input)
        {
            int[] result = new int[input.ToString().Length];
            for (int index = 0; input > 0; index++)
            {
                result[index] = input % 10;
                input /= 10;
            }

            return result;
        }

        private static void AverageOfaSequence()
        {
            List<int> sequence = new List<int>();
            // SequenceInput(sequence);
            SequenceRandomize(sequence);
            double average = new double();
            foreach (var element in sequence)
            {
                average += element;
            }

            average /= sequence.Count;
            string strSequence = string.Join(", ", sequence);
            Console.WriteLine("The average of the sequence \" {0} \" is {1}", strSequence, average);
        }

        private static void SequenceRandomize(List<int> array)
        {
            Random randomGenerator = new Random();
            int length = new int();
            length = IntInput("sequence length (less than 100)", true, 100);
            for (int index = 0; index < length; index++)
            {
                array.Add(randomGenerator.Next(short.MinValue, short.MaxValue));
            }
        }

        private static void SequenceInput(List<int> array)
        {
            int length = new int();
            length = IntInput("sequence length (less than 100)", true, 100);
            for (int index = 0; index < length; index++)
            {
                array[index] = IntInput(string.Format("element {0}", index + 1));
            }
        }

        private static void LinearEquationSolver()
        {
            double coeffA = DoubleInput("coefficent \"a\"", true);
            double coeffB = DoubleInput("coefficent \"b\"");
            Console.WriteLine("Entered equation is : {0}*x {1} = 0", coeffA, coeffB.ToString("+ #.##;- #.##;+ 0"));
            Console.WriteLine("x = {0}", -coeffB / coeffA);
        }
    }
}
