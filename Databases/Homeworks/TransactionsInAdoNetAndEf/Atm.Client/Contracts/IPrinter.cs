namespace Atm.Client.Contracts
{
    using System;

    public interface IPrinter
    {
        void Print(string textToPrint);

        void PrintLine(string textToPrint);
    }
}
