using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6
{
    // - расчетный - возможность пополнения и изъятия денег со счета, наличие платы за обслуживание, списание суммы за обслуживание со счета
    public class CurentAccount : AccountBase
    {
        private int id;
        private string owner;
        private readonly double Sum;
        private readonly double serviceCharges;

        public CurentAccount(int id, string owner, double sum, bool isClose, double serviceCharges) : base(id, owner, sum, isClose)
        {
            this.id = id;
            this.owner = owner;
            this.Sum = sum;
        }
    }
}
