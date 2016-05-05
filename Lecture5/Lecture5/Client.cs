namespace Lecture5
{
    public class Client
    {
        protected readonly double Sum;
        private int id;
        private string phone;

        protected Client(int id, string phone, double sum)
        {
            this.id = id;
            this.phone = phone;
            this.Sum = sum;
        }

        public virtual string ReturnNameAndSum()
        {
            return null;
        }
    }
}