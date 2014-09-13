namespace Atm.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Atm.Data;
    using Atm.Data.Repositories;
    using Atm.Models;
    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;
    using RandomDataGenerator.Enumerations;

    internal class FakeDataFiller
    {
        private const int FakeDataCount = 1000000;

        public static void FillCardHoldersWithFakeData(AtmEntities dbContext, CardHolderRepository userRepo)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            var randomDataProvider = new RandomDataProvider();

            int length = FakeDataCount - userRepo.GetAll().Count();
            for (int i = 0; i < length; i++)
            {
                var currentCardHolder = new CardHolder()
                {
                    Name = randomDataProvider.GetFirstName() + " " + randomDataProvider.GetStringExact(1, RandomDataType.BigLetters) + " " + randomDataProvider.GetLastName()
                };

                userRepo.Insert(currentCardHolder);

                if (i % 133 == 0) // Randomly chosen value
                {
                    dbContext.SaveChanges();
                }
            }

            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        public static void FillCardAccountsWithFakeData(AtmEntities dbContext, CardAccountRepository cardAccountsRepo, IList<int> cardHolderIds)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            var randomDataProvider = new RandomDataProvider();
            var numberProvider = RandomNumberProvider.GetInstance();
            var registeredCardNumbers = new HashSet<long>();
            var currentCardNumbers = cardAccountsRepo.GetAll().Select(ca => ca.CardNumber).ToArray();
            int currentCardsCount = 0;

            foreach (var number in currentCardNumbers)
            {
                if (string.IsNullOrEmpty(number))
                {
                    continue;
                }

                registeredCardNumbers.Add(long.Parse(number));
                currentCardsCount += 1;
            }

            int length = FakeDataCount - currentCardsCount;
            for (int i = 0; i < length; i++)
            {
                CardAccount currentCardAccount = GenerateCardAccount(registeredCardNumbers, cardHolderIds, numberProvider, randomDataProvider);

                cardAccountsRepo.Insert(currentCardAccount);

                if (i % 133 == 0) // Randomly chosen value
                {
                    dbContext.SaveChanges();
                }
            }

            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        private static CardAccount GenerateCardAccount(HashSet<long> registeredCardNumbers, IList<int> cardHolderIds, IRandomNumberProvider numberProvider, IRandomDataProvider randomDataProvider)
        {
            string cardNumber = string.Empty;
            long number = new long();
            while (number == 0 || registeredCardNumbers.Contains(number))
            {
                number = (long)numberProvider.GetIntInRange(0, 1999999999) * (long)numberProvider.GetIntInRange(1, 5);
            }

            registeredCardNumbers.Add(number);
            cardNumber = number.ToString().PadLeft(10, '0');
            var holderId = cardHolderIds[numberProvider.GetIntUpTo(cardHolderIds.Count - 1)];
            var pin = randomDataProvider.GetStringExact(4, RandomDataType.Numerics);
            var cash = (decimal)numberProvider.GetDoubleInRange(100.00D, 10000.00D);

            CardAccount currentCardAccount = new CardAccount()
            {
                CardNumber = cardNumber,
                CardHolderId = holderId,
                CardPin = pin,
                CardCash = cash
            };
            return currentCardAccount;
        }
    }
}
