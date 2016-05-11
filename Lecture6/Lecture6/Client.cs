using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
    using Lecture6;

    class Client   
    {
        List<AccountBase> accounts;

        public CurentAccount currentAccount;
        public MetalAccount metalAccount;

        public double sum;

        public Client()
        {
            currentAccount = new CurentAccount(1, "123", 1.1, true, 1.1);
            metalAccount = new MetalAccount(1, "123", 1.1, true, 1.1, "1кепеунр", 1.1);
            List<AccountBase> accounts = new List<AccountBase>();
            accounts.Add(currentAccount);
            accounts.Add(metalAccount);
        }

        public double Sum
        {
            get
            {
                double summa = 0;
                foreach (AccountBase account in accounts)
                {
                    summa = +account.Sum;
                }
                return summa;

            }
        }

    }
}
