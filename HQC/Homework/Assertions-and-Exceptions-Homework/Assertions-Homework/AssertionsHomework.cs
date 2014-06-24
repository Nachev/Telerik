namespace AssertionsHomework
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Cannot sort null array.");
            }

            if (arr.Length <= 0)
            {
                throw new ArgumentException("Cannot sort empty array.");
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }
   
        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr == null || arr.Length <= 0, "Array is null or empty");
            Debug.Assert(startIndex < 0 || startIndex >= arr.Length, "Start index is out of range!");
            Debug.Assert(endIndex < startIndex || endIndex >= arr.Length, "End index is out of range!");
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        private static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            Debug.Assert(firstValue == null || secondValue == null, "Swaping null value! Are you sure?");
            T swapValue = firstValue;
            firstValue = secondValue;
            secondValue = swapValue;
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Cannot search in null array.");
            }

            if (arr.Length <= 0)
            {
                throw new ArgumentException("Cannot search in empty array.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("Wanted value is null!");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr == null || arr.Length <= 0, "Array is null or empty");
            Debug.Assert(startIndex < 0 || startIndex >= arr.Length, "Start index is out of range!");
            Debug.Assert(endIndex < startIndex || endIndex >= arr.Length, "End index is out of range!");
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else 
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }
    }
}
