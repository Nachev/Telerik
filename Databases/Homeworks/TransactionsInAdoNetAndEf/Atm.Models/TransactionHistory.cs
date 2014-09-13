namespace Atm.Models
{
    using System;
    using System.Linq;
    using Atm.Models.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class TransactionHistory : ITransactionHistory
    {
        [Key]
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime TarnsactionDate { get; set; }

        public decimal Ammount { get; set; }
    }
}
