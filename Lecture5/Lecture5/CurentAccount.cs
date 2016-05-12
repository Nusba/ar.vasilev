namespace Lecture5
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

        public bool EditServiceCharges(double serviceCharges)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.ServiceCharges = serviceCharges;
                return true;
            }
        }

        public bool WithdrawServiceCharges(double serviceCharges)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                if (this.Sum < serviceCharges)
                {
                    Console.WriteLine($"Невозможно провести списание. Cумма платы за обслуживание {serviceCharges} не может превышать остаток на счете {this.Sum}");
                    return false;
                }
                else
                {
                    this.Sum = this.Sum - serviceCharges;
                    return true;
                }
            }
        }
    }
}
