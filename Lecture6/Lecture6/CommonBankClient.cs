﻿namespace Lecture6
{
    public class CommonBankClient : BankClientBase
    {
        private const int MaxCountAccounts = 3;

        public CommonBankClient(int id) : base(id, MaxCountAccounts)
        {

        }

        public CommonBankClient()
        {
            base.MaxCountAccounts = MaxCountAccounts;
        }
    }
}
