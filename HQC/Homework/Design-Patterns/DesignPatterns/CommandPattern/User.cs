namespace CommandPattern
{
    using System;
    using System.Collections.Generic;

    /// <summary> The 'Invoker' class </summary>
    public class User
    {
        // Initializers
        private Calculator calculator = new Calculator();
        private List<Command> commands = new List<Command>();
        private int current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (this.current < this.commands.Count - 1)
                {
                    Command command = this.commands[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if (this.current > 0)
                {
                    Command command = this.commands[--this.current] as Command;
                    command.UnExecute();
                }
            }
        }
          
        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(
                this.calculator, @operator, operand);

            command.Execute();

            // Add command to undo list

            this.commands.Add(command);

            this.current++;
        }
    }
}