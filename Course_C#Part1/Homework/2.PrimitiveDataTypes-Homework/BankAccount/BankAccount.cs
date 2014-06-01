namespace BankAccount
{
    using System;
    /*A bank account has a holder name (first name, middle name and last name), 
     * available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers 
     * associated with the account. Declare the variables needed to keep the information for 
     * a single bank account using the appropriate data types and descriptive names.*/
    class BankAccount
    {
        static void Main()
        {
            string firstName = "John";
            string middleName = "Smith";
            string lastName = "Doe";
            string bankName = "Bank of America";
            string iBAN = "US12BOAL3246545788";
            string bicCode = "BOAUS2B912";
            decimal balance = 1000000000.00M;
            long CrCard1 = 376776959270282;
            long CrCard2 = 375278143394186;
            long CrCard3 = 372267517576414;
            Console.WriteLine("Your bank account is".PadLeft(30) + "\n" + new string('*', 40));
            Console.WriteLine("Name: ".PadRight(15) + (firstName + " " + middleName + " " + lastName));
            Console.WriteLine("Bank: ".PadRight(15) + bankName);
            Console.WriteLine("IBAN: ".PadRight(15) + iBAN);
            Console.WriteLine("Bic Code: ".PadRight(15) + bicCode);
            Console.WriteLine("Balance: ".PadRight(15) + balance);
            Console.WriteLine("Credit cards issued:\n\t-card1: {0}\n\t-card2: {1}\n\t-card3: {2}", CrCard1, CrCard2, CrCard3);
        }
    }
}
