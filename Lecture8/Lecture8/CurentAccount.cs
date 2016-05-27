namespace Lecture8
{
    using System;
    // - расчетный - возможность пополнения и изъятия денег со счета, наличие платы за обслуживание, списание суммы за обслуживание со счета
    public class CurentAccount : AccountBase
    {
        public CurentAccount(int id, string owner, double sum, bool isClose, double serviceCharges) : base(id, owner, sum, isClose)
        {
            this.ServiceCharges = serviceCharges;
        }

        public CurentAccount()
        {
            this.ServiceCharges = 100.99;
        }

        private double ServiceCharges { get; set; }

        public void EditServiceCharges(double serviceCharges)
        {
            if (serviceCharges < 0)
            {
                throw new ArgumentOutOfRangeException($"Плата за обслуживание не может быть меньше нуля");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.ServiceCharges = serviceCharges;
            }
        }

        public void WithdrawServiceCharges(double serviceCharges)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum < serviceCharges)
                {
                    throw new ArgumentOutOfRangeException($"Невозможно провести списание. Cумма платы за обслуживание {serviceCharges} не может превышать остаток на счете {this.Sum}");
                }
                else
                {
                    this.Sum = this.Sum - serviceCharges;
                }
            }
        }
    }
}
