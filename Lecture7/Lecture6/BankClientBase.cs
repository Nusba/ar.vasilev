namespace Lecture7
{
    using System;
    using System.Collections.Generic;

    public abstract class BankClientBase : IComparable
    {
        private readonly List<AccountBase> accounts = new List<AccountBase>();

        protected BankClientBase(int id, int maxCountAccounts)
        {
            this.Id = id;
            this.MaxCountAccounts = maxCountAccounts;
            accounts = new List<AccountBase>();
        }

        protected BankClientBase()
        {
            this.Id = 13;
            this.MaxCountAccounts = this.MaxCountAccounts;
            accounts = new List<AccountBase>();
        }

        private int Id { get; set; }

        protected int MaxCountAccounts { private get; set; }

        public bool AddAccount(AccountBase newAccount)
        {
            if (accounts.Count  < this.MaxCountAccounts)
            {
                accounts.Add(newAccount);
                return true;
            }
            else
            {
                Console.WriteLine($"Невозможно добавить новый счет к клиенту {this.Id}, количество счетов не может превышать {this.MaxCountAccounts}");
                return false;
            }

        }

        public void GetAllAccountsAndSums()
        {
            if (accounts.Count > 0)
            {
                foreach (AccountBase account in accounts)
                {
                    Console.WriteLine($"Счет: {account.Id}, Баланс: {account.Sum}");
                }
            }
            else
            {
                Console.WriteLine($"У клиента {this.Id} нет счетов");
            }
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

        public double GetSumCurentAccount(int accountId)
        {
            foreach (AccountBase account in accounts)
            {
                if (accountId == account.Id)
                {
                    return account.Sum;
                }
            }
            Console.WriteLine($"Счет с {this.Id}, не найден.");
            return 0;
        }

        public void CloseCurentAccount(int accountId)
        {
            int closingAccounts = 0;

            foreach (AccountBase account in accounts)
            {
                if (accountId == account.Id)
                {
                    account.CloseAccount();
                    closingAccounts++;
                }
            }

            if (closingAccounts == 0)
            {
                Console.WriteLine($"Счет с номером {this.Id}, не найден.");
            }
        }

        public int CompareTo(object obj)
        {
            var client = (BankClientBase)obj;
            if (CalculationTotal > client.CalculationTotal)
            {
                return 1;
            }

            if (CalculationTotal < client.CalculationTotal)
            {
                return -1;
            }

            return 0;
        }
    }
}

