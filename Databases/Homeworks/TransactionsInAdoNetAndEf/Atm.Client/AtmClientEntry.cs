namespace Atm.Client
{
    using Atm.Data;
    using Atm.Data.Repositories;
    using Atm.Models;
    using RandomDataGenerator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AtmClientEntry
    {
        private const int FakeDataCount = 100000;

        static void Main(string[] args)
        {
            using (var dbContext = new AtmEntities())
            {
                var userRepo = new CardHolderRepository(dbContext);
                var cardAccountsRepo = new CardAccountRepository(dbContext);
                //FillCardHoldersWithFakeData(dbContext, userRepo);
                dbContext.SaveChanges();
                FillCardAccountsWithFakeData(dbContext, cardAccountsRepo);
                dbContext.SaveChanges();
            }
        }

        private static void FillCardHoldersWithFakeData(AtmEntities dbContext, CardHolderRepository userRepo)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            var randomDataProvider = new RandomDataProvider();
            var numberProvider = RandomNumberProvider.GetInstance();

            for (int i = 0; i < FakeDataCount; i++)
            {
                var currentCardHolder = new CardHolder()
                {
                    Name = randomDataProvider.GetFirstName() + " " + randomDataProvider.GetStringExact(1, RandomDataGenerator.Enumerations.RandomDataType.BigLetters) + " " + randomDataProvider.GetLastName()
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

        private static void FillCardAccountsWithFakeData(AtmEntities dbContext, CardAccountRepository cardAccountsRepo)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            var randomDataProvider = new RandomDataProvider();
            var numberProvider = RandomNumberProvider.GetInstance();

            for (int i = 0; i < FakeDataCount; i++)
            {
                string number = string.Empty;
                while (string.IsNullOrEmpty(number) || cardAccountsRepo.DoesCardExists(number))
                {
                    number = randomDataProvider.GetStringExact(10, RandomDataGenerator.Enumerations.RandomDataType.Numerics);
                }

                var holderId = numberProvider.GetIntUpTo(FakeDataCount - 1);
                var pin = randomDataProvider.GetStringExact(4, RandomDataGenerator.Enumerations.RandomDataType.Numerics);
                var cash = (decimal)numberProvider.GetDoubleInRange(100.00D, 10000.00D);

                CardAccount currentCardAccount = new CardAccount()
                {
                    CardNumber = number,
                    CardHolderId = holderId,
                    CardPin = pin,
                    CardCash = cash
                };
                    
                cardAccountsRepo.Insert(currentCardAccount);

                if (i % 133 == 0) // Randomly chosen value
                {
                    dbContext.SaveChanges();
                }
            }

            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}