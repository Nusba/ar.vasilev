using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
    // - обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
    internal class MetalAccount : AccountBase
    {
        private int id;

        private string owner;

        private readonly double Sum;

        private string typeMetal;

        private double grammsMetal;

        private readonly double courseExchangeMetal;

        public MetalAccount( int id, string owner, double sum, bool isClose, double grammsMetal, string typeMetal, double courseExchangeMetal)
            : base(id, owner, sum, isClose)
        {
            this.id = id;
            this.owner = owner;
            this.Sum = sum;
        }
    }
}
