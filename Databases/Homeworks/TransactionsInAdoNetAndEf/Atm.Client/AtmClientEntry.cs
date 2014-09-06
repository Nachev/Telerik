namespace Atm.Client
{
    using System;
    using System.Linq;

    using Atm.Data;
    using Atm.Data.Repositories;
    using Atm.Models.Contracts;

    public class AtmClientEntry
    {
        private static void Main(string[] args)
        {
            using (var dbContext = new AtmEntities())
            {
                var userRepo = new CardHolderRepository(dbContext);
                var cardAccountRepo = new CardAccountRepository(dbContext);
                var transactionHystoryRepo = new TransactionHistoryRepository(dbContext);
                var consoleHandler = ConsoleHandler.Instance;
                FakeDataFiller.FillCardHoldersWithFakeData(dbContext, userRepo);
                dbContext.SaveChanges();
                consoleHandler.PrintLine("Card holders faking finished.");
                var cardHoldersIds = userRepo.GetAll().Select(u => u.Id).ToList();
                FakeDataFiller.FillCardAccountsWithFakeData(dbContext, cardAccountRepo, cardHoldersIds);
                dbContext.SaveChanges();
                consoleHandler.PrintLine("Card accounts faking finished.");

                var card = GetCredentials(cardAccountRepo);
                if (card != null)
                {
                    if(WithdrawSum(dbContext, cardAccountRepo, transactionHystoryRepo, card))
                    {
                        consoleHandler.PrintLine("Withdraw successful.");
                    }
                }
            }
        }

        private static ICardAccount GetCredentials(CardAccountRepository cardAcountRepo)
        {
            var consoleHandler = ConsoleHandler.Instance;
            consoleHandler.Print("Enter card number: ");
            var cardNumberToFind = consoleHandler.GetStringInput();
            if(cardNumberToFind.Length < cardAcountRepo.NumberLength || !cardAcountRepo.DoesCardExists(cardNumberToFind))
            {
                consoleHandler.PrintLine("This card does not exists in the database.");
                return null;
            }

            consoleHandler.Print("Enter pin: ");
            var enteredPin = consoleHandler.GetStringInput();
            if (enteredPin.Length != cardAcountRepo.PinLength)
            {
                consoleHandler.PrintLine("Entered pin does not match predefined length: " + cardAcountRepo.PinLength);
            }

            var result = cardAcountRepo.GetByCardNumberAndPin(cardNumberToFind, enteredPin);
            if (result == null)
            {
                consoleHandler.PrintLine("Entered pin does not match.");
            }

            return result;
        }

        private static bool WithdrawSum(
            AtmEntities dbContext, 
            CardAccountRepository cardAcountRepo,
            TransactionHistoryRepository tarnsactionHystoryRepo, 
            ICardAccount cardAccount)
        {
            var transactionsHandler = new TransactionsHandler(dbContext, cardAcountRepo, tarnsactionHystoryRepo);
            var consoleHandler = ConsoleHandler.Instance;
            consoleHandler.Print("Enter value to withdraw: ");
            var withdrawValueInput = consoleHandler.GetStringInput();
            decimal withdrawValue = new decimal();
            if(!decimal.TryParse(withdrawValueInput, out withdrawValue))
            {
                return false;
            }

            return transactionsHandler.WithdrawTransaction(cardAccount.CardNumber, cardAccount.CardPin, withdrawValue);
        }
    }
}