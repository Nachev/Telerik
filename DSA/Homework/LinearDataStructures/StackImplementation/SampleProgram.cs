namespace StackTest
{
    using System;
    using System.Linq;

    using StackImplement;

    /*Implement the ADT stack as auto-resizable array . 
    Resize the capacity on demand (when no space is 
    available to add / insert a new element).*/
    internal class SampleProgram
    {
        private static void Main()
        {
            StackWithArray<int> testStack = new StackWithArray<int>();
            Console.WriteLine("Push");
            testStack.Push(23);
            testStack.Push(13);
            testStack.Push(7);
            testStack.Push(5);
            testStack.Push(15);
            testStack.Push(243);
            testStack.Push(544);
            testStack.Push(42);
            Console.WriteLine("Pushed: " + string.Join(", ", testStack));
            Console.WriteLine("Peek: " + testStack.Peek());
            Console.WriteLine("Pop: " + testStack.Pop());
            Console.WriteLine("Poped: " + string.Join(", ", testStack));
            Console.WriteLine("Count: " + testStack.Count());
            Console.WriteLine("Contains 13: " + testStack.Contains(13));
            Console.WriteLine("Contains 42: " + testStack.Contains(42));
            Console.WriteLine("Trim excess");
            testStack.TrimExcess();
        }
    }
}