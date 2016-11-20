namespace ReverseStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Write a program that reads N integers from the console and reverses them 
     * using a stack. Use the Stack<int> class.*/

    internal class SampleProgram
    {
        private static void Main()
        {
            var inputSequence = ProgramInput();
            Console.WriteLine("Entered stack is: " + string.Join(", ", inputSequence));

            var reversedStack = ReverseStack(inputSequence);
            Console.WriteLine("Reversed stack is: " + string.Join(", ", reversedStack));
            Console.ReadLine();
        }

        private static int NumberInput(string message = "-> ")
        {
            bool isCorrectInteger = new bool();
            int result = new int();
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                isCorrectInteger = int.TryParse(input, out result);
                if (isCorrectInteger)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }
            while (true);

            return result;
        }

        private static Stack<int> ProgramInput()
        {
            var result = new Stack<int>();
            int length = NumberInput("Enter sequence length: ");
            Console.WriteLine("Enter sequence elements: ");
            do
            {
                int inputNumber = NumberInput();
                result.Push(inputNumber);
                length--;
            }
            while (length > 0);

            return result;
        }

        private static IEnumerable<T> ReverseStack<T>(Stack<T> sequence)
        {
            var result = new Stack<T>(sequence.Count);
            int length = sequence.Count;
            for (int i = 0; i < length; i++)
            {
                result.Push(sequence.Pop());
            }

            return result;
        }
    }
}
