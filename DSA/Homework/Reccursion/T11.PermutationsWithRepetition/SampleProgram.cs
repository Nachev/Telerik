namespace T11.PermutationsWithRepetition
{
    using System;

    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            int[] arr = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Permute(arr, 0, arr.Length);
        }

        private static void Permute<T>(T[] arr, int currentIndex, int arrayLength) where T: IFormattable, IComparable<T>
        {
            PrintLoops(arr);
            if (currentIndex < arrayLength)
            {
                for (int i = arrayLength - 2; i >= currentIndex; i--)
                {
                    for (int k = i + 1; k < arrayLength; k++)
                    {
                        if (arr[i].CompareTo(arr[k]) != 0)
                        {
                            T swapValue = arr[i];
                            arr[i] = arr[k];
                            arr[k] = swapValue;

                            Permute(arr, i + 1, arrayLength);
                        }
                    }

                    T swap = arr[i];
                    for (int j = i; j < arrayLength - 1;)
                    {
                        arr[j] = arr[++j];
                    }

                    arr[arrayLength - 1] = swap;
                }
            }
        }

        private static void PrintLoops<T>(T[] arr) where T: IFormattable
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
