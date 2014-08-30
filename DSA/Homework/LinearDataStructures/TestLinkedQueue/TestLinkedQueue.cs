namespace TestLinkedQueue
{
    using System;
    using System.Linq;

    using QueueWithList;

    /*Implement the ADT queue as dynamic linked list. 
    Use generics (LinkedQueue<T>) to allow storing 
    different data types in the queue.*/
    internal class TestLinkedQueue
    {
        private static void Main()
        {
            LinkedQueue<int> testQueue = new LinkedQueue<int>();

            testQueue.Enqueue(5);
            testQueue.Enqueue(7);
            testQueue.Enqueue(15);
            testQueue.Enqueue(23);
            testQueue.Enqueue(11);
            testQueue.Enqueue(455);
            testQueue.Enqueue(5855);
            testQueue.Enqueue(5);
            Console.WriteLine("Enqueued: " + string.Join(", ", testQueue));

            Console.WriteLine(new string('-', 48));
            testQueue.Dequeue();
            Console.WriteLine("Dequeued: " + string.Join(", ", testQueue));

            Console.WriteLine(new string('-', 48));
            Console.WriteLine("Peek: " + testQueue.Peek());

            Console.WriteLine(new string('-', 48));
            Console.WriteLine("Count: " + testQueue.Count);

            Console.WriteLine(new string('-', 48));
            Console.WriteLine("Contains: " + testQueue.Contains(455));
            Console.WriteLine("Contains: " + testQueue.Contains(455));

            int[] testArray = new int[testQueue.Count];
            testArray = testQueue.ToArray();

            Console.WriteLine(new string('-', 48));
            Console.WriteLine("To array: " + string.Join(", ", testArray));

            Console.WriteLine(new string('-', 48));
            testQueue.Clear();
            Console.WriteLine("Cleared: " + string.Join(", ", testQueue));
            Console.WriteLine("Cleared count: " + testQueue.Count);

            Console.WriteLine(new string('-', 48));
        }
    }
}