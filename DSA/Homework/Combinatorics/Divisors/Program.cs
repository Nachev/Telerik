namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static long divisorsCount = 0;
        private static long minDivisors = long.MaxValue;
        private static long result = 0;

        private static void Main(string[] args)
        {
            long numberOfElements = long.Parse(Console.ReadLine());
            long[] elements = new long[numberOfElements];

            for (long i = 0; i < numberOfElements; i++)
            {
                elements[i] = long.Parse(Console.ReadLine());
            }

            HeapCalcPermutations(elements, numberOfElements);

            Console.WriteLine(result);
        }

        private static void HeapCalcPermutations(long[] arr, long n)
        {
            if (n == 1)
            {
                long currentNumber  = long.Parse(string.Join("", arr));
                divisorsCount = FindDivisors(currentNumber);
                if (divisorsCount < minDivisors)
                {
                    minDivisors = divisorsCount;
                    result = currentNumber;
                }
            }
            else
            {
                for (long i = 0; i < n; i++)
                {
                    HeapCalcPermutations(arr, n - 1);

                    if ((n % 2) != 0)
                    {
                        Swap(arr, 1, n - 1);
                    }
                    else
                    {
                        Swap(arr, i, n - 1);
                    }
                }
            }
        }

        private static void Swap(long[] arr, long a, long b)
        {
            long swap = arr[a];
            arr[a] = arr[b];
            arr[b] = swap;
        }

        private static long FindDivisors(long num)
        {
            long count = 0;
 
            for(long i = 1, square = (long)Math.Ceiling(Math.Sqrt(num)); i <= square; i++)
            {
                 if(num % i == 0)
                 {
                      // Add i to list of divisors.
                      // Add num / i to list of divisors.
                      count ++;
                 }
            }

            return count *= 2;
        }
    }
}
