namespace LinkedListImplementation
{
    using System;
    using LinkedList;

    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            // Creation
            LinkedList<int> testList = new LinkedList<int>() { 1, 2, 3, 4, 5};

            // Addition
            testList.Add(6);
            testList.Add(7);
            Console.WriteLine(string.Join(", ", testList)); // Enumerator

            // Removal
            testList.Remove(4);
            Console.WriteLine(string.Join(", ", testList));

            Console.WriteLine("Contains 6: " + testList.Contains(6));
            Console.WriteLine("Contains 4: " + testList.Contains(4));

            int[] arr = new int[6];
            testList.CopyTo(arr, 0);
            Console.WriteLine("Copied to array " + string.Join(", ", arr));

            testList.AddAfter(6, 13);
            Console.WriteLine("Add after result " + string.Join(", ", testList));

            testList.AddBefore(6, 13);
            Console.WriteLine("Add before result " + string.Join(", ", testList));
        }
    }
}
