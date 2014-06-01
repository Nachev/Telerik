namespace Bank
{
    using System;

    public class DepositAccount : BankAccountBase
    {
        private const decimal NO_INTEREST = 0.0M;

        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Deposit sum must be positive number!");
            }

            this.Balance += sum;
        }

        public void Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Withdraw sum must be positive number!");
            }

            this.Balance -= sum;
        }

        /// <summary>
        /// Deposit accounts have no interest if their balance is positive and less than 1000.
        /// </summary>
        public override decimal CalcInterestAmount(int periodMonths)
        {
            if (periodMonths <= 0)
            {
                throw new ArgumentException("Period must be positive number!");
            }

            if (this.Balance > 0 && this.Balance < 1000)
            {
                return NO_INTEREST;
            }

            return base.CalcInterestAmount(periodMonths);
        }
    }
}
