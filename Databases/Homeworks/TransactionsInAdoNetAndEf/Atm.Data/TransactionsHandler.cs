namespace Atm.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Atm.Data.Repositories;
    using Atm.Models.Contracts;
    using Atm.Models;

    public class TransactionsHandler
    {
        private DbContext dbContext;
        private ICardAccountRepository cardAcountRepo;
        private IGenericRepository<TransactionHistory> transactionLogRepo;
        private IList<string> errors;

        public TransactionsHandler(DbContext dbContext, ICardAccountRepository cardAcountRepo, TransactionHistoryRepository transactionLogRepo)
        {
            this.dbContext = dbContext;
            this.cardAcountRepo = cardAcountRepo;
            this.transactionLogRepo = transactionLogRepo;
            this.errors = new List<string>();
        }

        public IList<string> Errors
        {
            get
            {
                return this.errors;
            }
        }

        public bool WithdrawTransaction(string cardNumber, string pin, decimal withdrawAmount)
        {
            bool result = true;

            using (var tran = this.dbContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                var currentCard = this.cardAcountRepo.GetByCardNumberAndPin(cardNumber, pin);
                if (currentCard == null)
                {
                    errors.Add("Unknown card or pin!");
                    result = false;
                }
                else
                {
                    var sufficentFunds = this.cardAcountRepo.IsCashAmountSufficient(currentCard, withdrawAmount);

                    if (sufficentFunds)
                    {
                        result = this.cardAcountRepo.WithdrawAmount(currentCard, withdrawAmount);
                        if (result == false)
                        {
                            errors.Add("Insufficent funds!");
                        }
                    }
                    else
                    {
                        errors.Add("Insufficent funds!");
                        result = false;
                    }
                }

                if (result)
                {
                    tran.Commit();
                    errors.Clear();
                    this.transactionLogRepo.Insert(
                        new TransactionHistory()
                        {
                            Ammount = withdrawAmount,
                            CardNumber = cardNumber,
                            TarnsactionDate = DateTime.UtcNow
                        });
                }
                else
                {
                    tran.Rollback();
                }
            }

            dbContext.SaveChanges();
            return result;
        }
    }
}