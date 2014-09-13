using System;

namespace Atm.Models.Contracts
{
    public interface ITransactionHistory
    {
        int Id { get; set; }

        string CardNumber { get; set; }

        DateTime TarnsactionDate { get; set; }

        decimal Ammount { get; set; }
    }
}