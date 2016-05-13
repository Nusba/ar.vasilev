namespace Lecture5
{
    // - сберегательный счет - возможность пополнения и изъятия денег со счета
    public class SavingAccount : AccountBase
    {
        public SavingAccount(int id, string owner, double sum, bool isClose) : base(id, owner, sum, isClose)
        {
        }

        public SavingAccount()
        {
        }
    }   
}
