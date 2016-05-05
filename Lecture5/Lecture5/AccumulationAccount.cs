using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5
{
    // - накопительный - возможность пополнения и изъятия денег со счета, но не меньше первоначального взноса, наличие процентной ставки, капитализация процентов за месяц
    internal class AccumulationAccount : AccountBase
    {
        private int id;
        private string owner;
        private readonly double sum;
        private double firstСontribution;
        private double percentRate;
        private double capitalizationPercent;

        public AccumulationAccount(int id, string owner, double sum, bool isClose, double firstСontribution, double percentRate) 
            : base(id, owner, sum, isClose)
        {
            this.id = id;
            this.owner = owner;
            this.sum = sum;
        }
    }
}
