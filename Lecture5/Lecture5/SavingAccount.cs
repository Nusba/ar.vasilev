using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
    // - сберегательный счет - возможность пополнения и изъятия денег со счета
    class SavingAccount : AccountBase
    {
        private int id;
        private string owner;
        private readonly double Sum;

        public SavingAccount(int id, string owner, double sum, bool isClose) : base(id, owner, sum, isClose)
        {
            this.id = id;
            this.owner = owner;
            this.Sum = sum;
        }
    }
}
