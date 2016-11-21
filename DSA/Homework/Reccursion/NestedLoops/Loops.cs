namespace NestedLoops
{
    using System;

    internal class Loops
    {
        private static void Main(string[] args)
        {
            int[] arr = new int[3];
            NestedLoops(arr, 0);
        }

        private static void NestedLoops(int[] arr, int count)
        {
            if (arr.Length == count)
            {
                Console.WriteLine(string.Join(", ", arr));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[count] = i;
                NestedLoops(arr, count + 1);
            }
        }
    }
}
