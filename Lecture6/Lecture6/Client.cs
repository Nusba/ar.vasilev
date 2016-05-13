namespace Lecture6
{
    using System.Collections.Generic;
    
    // Класс относиться к заданию 1
    public class Client
    {
        private readonly List<AccountBase> accounts = new List<AccountBase>();

        public Client()
        {
        }

        public double CalculationTotal
        {
            get
            {
                double total = 0;

                foreach (AccountBase account in accounts)
                {
                    total = total + account.Sum;
                }

                return total;
            }
        }

        public void AddAccount(AccountBase newAccount)
        {
            accounts.Add(newAccount);
        }
    }
}
