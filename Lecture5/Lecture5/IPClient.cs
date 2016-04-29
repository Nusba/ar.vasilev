namespace Lecture5
{
    using System;

    public class IPClient : Client
    {
        public string Fio;
        public DateTime Birthday;

        public IPClient(int id, string phone, double sum, string fio, DateTime birthday) : base(id,phone,sum)
        {
            Fio = fio;
            Birthday = birthday;
        }

        public override string ReturnNameAndSum()
        {
            return Fio + " " + base.Sum;
        }
    }
}