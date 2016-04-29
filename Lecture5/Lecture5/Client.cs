using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
    public class Client
    {
        public int Id;
        public string Phone;
        public double Sum;

        public Client(int id, string phone, double sum )
        {
            Id = id;
            Phone = phone;
            Sum = sum;
        }

        public virtual string ReturnNameAndSum()
        {
            return null;
        }
    }
}
