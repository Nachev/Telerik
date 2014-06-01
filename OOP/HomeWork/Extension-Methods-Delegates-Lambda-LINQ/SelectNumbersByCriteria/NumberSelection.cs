namespace SelectNumbersByCriteria
{
    using System;
    using System.Collections;
    using System.Linq;

    /*Write a program that prints from given array of integers all numbers 
     * that are divisible by 7 and 3. Use the built-in extension methods and 
     * lambda expressions. Rewrite the same with LINQ.*/

    public class NumberSelection
    {
        private const int DIVISOR3 = 3;
        private const int DIVISOR7 = 7;
        private static Random rng = new Random();

        private static void Main()
        {
            int[] array = new int[30];

            GenerateArray(array);
            PrintRandomArray(array);
            Console.WriteLine();
            var result = SelectNumbersLinq(array);
            PrintResult(result);
            var result2 = SelectNumbersLambda(array);
            PrintResult(result2);
        }

        private static void PrintResult(IEnumerable result)
        {
            Console.WriteLine("Divisible by 7 and 3 :");
            PrintArray(result);
        }

        private static void PrintRandomArray(IEnumerable array)
        {
            Console.WriteLine("Random array :");
            PrintArray(array);
        }

        private static void PrintArray(IEnumerable array)
        {
            foreach (var number in array)
            {
                Console.Write("{0,4}", number);
            }

            Console.WriteLine();
        }

        private static void GenerateArray(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = rng.Next(950);
            }
        }

        // LINQ
        private static int[] SelectNumbersLinq(int[] array)
        {
            var result =
                from number in array
                where number % DIVISOR3 == 0 && number % DIVISOR7 == 0
                select number;
            return result.ToArray();
        }

        // Lambda
        private static int[] SelectNumbersLambda(int[] array)
        {
            return array.Where(x => x % DIVISOR3 == 0 && x % DIVISOR7 == 0).ToArray();
        }
    }
}
