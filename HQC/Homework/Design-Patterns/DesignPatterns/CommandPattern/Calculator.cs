namespace CommandPattern
{
    using System;

    /// <summary>The 'Receiver' class</summary>
    public class Calculator
    {
        private int curr = 0;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    this.curr += operand;
                    break;
                case '-':
                    this.curr -= operand;
                    break;
                case '*':
                    this.curr *= operand;
                    break;
                case '/':
                    this.curr /= operand;
                    break;
            }

            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                this.curr, @operator, operand);
        }
    }
}