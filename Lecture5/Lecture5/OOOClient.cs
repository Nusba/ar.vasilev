namespace Lecture5
{
    public class OooClient : Client
    {
        private readonly string name;
        private string account;

        public OooClient(int id, string phone, double sum, string name, string account) : base(id, phone, sum)
        {
            this.name = name;
            this.account = account;
        }

        public override string ReturnNameAndSum()
        {
            return this.name + " " + base.Sum;
        }
    }
}