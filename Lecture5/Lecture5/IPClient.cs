namespace Lecture5
{
    using System;

    public class IpClient : Client
    {
        private readonly string fio;
        private DateTime birthday;

        public IpClient(int id, string phone, double sum, string fio, DateTime birthday) : base(id, phone, sum)
        {
            this.fio = fio;
            this.birthday = birthday;
        }

        public override string ReturnNameAndSum()
        {
            return this.fio + " " + base.Sum;
        }
    }
}