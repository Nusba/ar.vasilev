namespace Lecture6
{
    public class Bank
    {
        public void Transaction(AccountBase sender, AccountBase recipient, double sum)
        {
            sender.WithdrawFunds(sum);
            recipient.AddFunds(sum);
        }
    }
}
