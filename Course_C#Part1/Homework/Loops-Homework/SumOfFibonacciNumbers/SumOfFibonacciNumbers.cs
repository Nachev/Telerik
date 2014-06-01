namespace SumOfFibonacciNumbers
{
    using System;

    /*Write a program that reads a number N and calculates the sum of the first N members o
     * f the sequence of Fibonacci: 0, 1, 1,2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
     * Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members*/

    public class SumOfFibonacciNumbers
    {
        public static void Main()
        {
            Console.Title = "Calculates the sum of the first N members of the sequence of Fibonacci";
            int numberN = new int();
            do
            {
                Console.Write("Enter N: ");
                if (int.TryParse(Console.ReadLine(), out numberN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }
            } 
            while (true);
            
            // Calculate the sum while printing the sequence
            int fibParent1 = 1;
            int fibParent2 = 0;
            long sum = 1;
            Console.Write(fibParent1 + ", " + fibParent2);
            for (int i = 0; i < numberN; i++)
            {
                int temp = fibParent1;
                fibParent1 = fibParent2 + temp;
                fibParent2 = temp;
                Console.Write(", " + fibParent1);
                sum += fibParent1;
            }

            /*List<int> fibonacci = new List<int>();
            fibonacci.Add(0);
            fibonacci.Add(1);
            for (int i = 0; i < numberN; i++)
            {
                int temporary = fibonacci[i + 1] + fibonacci[i];
                fibonacci.Add(temporary);
                Console.Write("{0}, ", fibonacci[i]);
            }
            fibonacci.Remove(fibonacci[fibonacci.Count  -1]);
            fibonacci.Remove(fibonacci[fibonacci.Count - 1]);
            long sum = new long();
            foreach (int number in fibonacci)
            {
                sum += number;
            } */

            Console.WriteLine();
            Console.WriteLine("The sum is: {0}", sum);
        }
    }
}
