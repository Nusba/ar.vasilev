namespace Lecture7
{
    public class CommonBankClient : BankClientBase
    {
        private new const int MaxCountAccounts = 3;

        public CommonBankClient(int id) : base(id, MaxCountAccounts)
        {
            base.MaxCountAccounts = MaxCountAccounts;
        }

        public CommonBankClient()
        {
            base.MaxCountAccounts = MaxCountAccounts;
        }
    }
}
