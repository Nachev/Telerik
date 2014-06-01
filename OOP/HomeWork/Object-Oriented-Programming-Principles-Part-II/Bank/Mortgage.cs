namespace Bank
{
    using System;

    public class MortgageAccount : BankAccountBase
    {
        private const decimal NO_INTEREST = 0.0M;
        private const int COMPANY_HALF_INTEREST_PERIOD = 12;
        private const int INDIVIDUAL_NO_INTEREST_PERIOD = 6;

        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        /// <summary>
        /// Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
        /// </summary>
        public override decimal CalcInterestAmount(int periodMonths)
        {
            if (periodMonths <= 0)
            {
                throw new ArgumentException("Period must be positive number!");
            }

            if (this.Customer == Customer.Company && periodMonths <= COMPANY_HALF_INTEREST_PERIOD)
            {
                return base.CalcInterestAmount(periodMonths) / 2;
            }

            if (this.Customer == Customer.Individual && periodMonths < INDIVIDUAL_NO_INTEREST_PERIOD)
            {
                return NO_INTEREST;
            }

            return base.CalcInterestAmount(periodMonths);
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Deposit sum must be positive number!");
            }

            this.Balance += sum;
        }
    }
}
