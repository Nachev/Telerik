namespace Atm.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Atm.Models;
    using Atm.Models.Contracts;

    public class CardAccountRepository : GenericRepository<CardAccount>
    {
        public CardAccountRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public bool DoesCardExists(string cardNumber)
        {
            if (cardNumber.Length != 10)
            {
                return false;
            }

            var result = this.DbSet.Any(ca => ca.CardNumber == cardNumber);
            return result;
        }

        public ICardAccount GetByCardNumberAndPin(string cardNumber, string pin)
        {
            if (pin.Length > 4 || pin.Length < 4)
            {
                throw null;
            }

            var result = this.DbSet.FirstOrDefault(c => c.CardNumber == cardNumber && c.CardPin == pin);
            return result;
        }

        public bool IsCashAmountSufficient(ICardAccount cardAccount, decimal withdrawValue)
        {
            return cardAccount.CardCash >= withdrawValue;
        }

        public bool WithdrawAmount(ICardAccount cardAccount, decimal withdrawValue)
        {
            cardAccount.CardCash = cardAccount.CardCash - withdrawValue;
            if (cardAccount.CardCash < 0)
            {
                return false;
            }

            return true;
        }
    }
}
