namespace Atm.Client
{
    using System;
    using System.Linq;
    using Atm.Client.Contracts;

    internal class ConsoleHandler : IPrinter, IDataInput
    {
        private static ConsoleHandler instance;

        private ConsoleHandler()
        {
        }

        public static ConsoleHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleHandler();
                }

                return instance;
            }
        }

        public string GetStringInput()
        {
            var result = Console.ReadLine();
            return result;
        }

        public void Print(string textToPrint)
        {
            Console.Write(textToPrint);
        }

        public void PrintLine(string textToPrint)
        {
            Console.WriteLine(textToPrint);
        }
    }
}
