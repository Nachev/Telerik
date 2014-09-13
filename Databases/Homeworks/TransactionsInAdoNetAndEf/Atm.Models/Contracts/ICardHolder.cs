namespace Atm.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICardHolder
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<CardAccount> CardAccounts { get; }
    }
}