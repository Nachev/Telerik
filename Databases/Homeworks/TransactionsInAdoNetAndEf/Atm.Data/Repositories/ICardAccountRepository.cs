namespace Atm.Data.Repositories
{
    using System.Linq;
    using Atm.Models.Contracts;

    public interface ICardAccountRepository
    {
        bool DoesCardExists(string cardNumber);

        ICardAccount GetByCardNumberAndPin(string cardNumber, string pin);

        bool IsCashAmountSufficient(ICardAccount cardAccount, decimal withdrawValue);

        bool WithdrawAmount(ICardAccount cardAccount, decimal withdrawValue);
    }
}