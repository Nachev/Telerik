namespace Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            int n = 2;
            int[] arr = new int[n];
            InitializeArray(arr);
            HeapCalcPermutations(arr, n);
        }

        private static void HeapCalcPermutations(int[] arr, int n)
        {
            if (n == 1)
            {
                PrintLoops(arr);
            }
            else
            {
                for (int i = 0; i < n; i++)
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

        private static void InitializeArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }

        private static void Swap(int[] arr, int a, int b)
        {
            int swap = arr[a];
            arr[a] = arr[b];
            arr[b] = swap;
        }

        private static void PrintLoops(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
