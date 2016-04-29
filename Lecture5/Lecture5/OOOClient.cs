namespace Lecture5
{
    public class OOOClient : Client
    {
        public string Name;
        public string Account;

        public OOOClient(int id, string phone, double sum, string name, string account) : base(id,phone,sum)
        {
            Name = name;
            Account = account;
        }

        public override string ReturnNameAndSum()
        {
            return Name + " " + base.Sum;
        }
    }
}