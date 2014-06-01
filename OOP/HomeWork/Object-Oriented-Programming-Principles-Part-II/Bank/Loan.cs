namespace Bank
{
    using System;

    public class LoanAccount : BankAccountBase
    {
        private const decimal NO_INTEREST = 0.0M;
        private const int COMPANY_NO_INTEREST_PERIOD = 2;
        private const int INDIVIDUAL_NO_INTEREST_PERIOD = 3;

        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        /// <summary>
        /// Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
        /// </summary>
        public override decimal CalcInterestAmount(int periodMonths)
        {
            if (periodMonths <= 0)
            {
                throw new ArgumentException("Period must be positive number!");
            }

            if (this.Customer == Customer.Individual)
            {
                if (periodMonths <= INDIVIDUAL_NO_INTEREST_PERIOD)
                {
                    return NO_INTEREST;
                }

                return base.CalcInterestAmount(periodMonths - INDIVIDUAL_NO_INTEREST_PERIOD);
            }

            if (periodMonths <= COMPANY_NO_INTEREST_PERIOD)
            {
                return NO_INTEREST;
            }

            return base.CalcInterestAmount(periodMonths - COMPANY_NO_INTEREST_PERIOD);
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Deposit sum must be positive number!");
            }

            this.Balance -= sum;
        }
    }
}
