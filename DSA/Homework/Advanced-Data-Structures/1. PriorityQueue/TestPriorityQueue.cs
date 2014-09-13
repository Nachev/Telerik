namespace PriorityQueue
{
    using System;

    public class TestPriorityQueue
    {
        public static void Main(string[] args)
        {
            PriorityQueue<int> testQueue = new PriorityQueue<int>(5);
            testQueue.Enqueue(1);
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);
            testQueue.Enqueue(5);
            testQueue.Enqueue(1);
            testQueue.Dequeue();
            testQueue.Enqueue(25);
            Console.WriteLine("Dequeue: {0}", testQueue.Dequeue());
            testQueue.Print();
            testQueue.Enqueue(2);
            testQueue.Print();
        }
    }
}
