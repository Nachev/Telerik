namespace Bank
{
    using System;
    using System.Text;

    public abstract class BankAccountBase : IDepositable, IInterestable
    {
        private decimal balance;
        private decimal interestRate;

        public BankAccountBase(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                HandleNegativeValue(value);
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            protected set
            {
                HandleNegativeValue(value);
                this.interestRate = value;
            }
        }

        public Customer Customer { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Account type: {0} | ", this.GetType().Name);
            result.AppendFormat("Customer type: {0} | ", this.Customer);
            result.AppendFormat("Balance: {0:C} | ", this.Balance);
            result.AppendFormat("Interest rate: {0} %", this.InterestRate);
            return result.ToString();
        }

        public virtual decimal CalcInterestAmount(int periodMonths)
        {
            return periodMonths * this.InterestRate;
        }

        public abstract void Deposit(decimal sum);

        private static void HandleNegativeValue(decimal value)
        {
            if (value < 0.0M)
            {
                throw new ArgumentException("Value must be non-negative!");
            }
        }
    }
}
