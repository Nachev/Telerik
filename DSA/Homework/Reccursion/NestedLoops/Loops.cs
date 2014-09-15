namespace NestedLoops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
