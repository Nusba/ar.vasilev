namespace Lecture6
{
    public class VipBankClient : BankClientBase
    {
        private const int MaxCountAccounts = 10;

        public VipBankClient(int id) : base(id, MaxCountAccounts)
        {
            base.MaxCountAccounts = MaxCountAccounts;
        }

        public VipBankClient()
        {
            base.MaxCountAccounts = MaxCountAccounts;
        }
    }
}
