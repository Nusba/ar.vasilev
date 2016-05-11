namespace Lecture5
{
    using System;

    public class AccountBase
    {
        protected AccountBase(int id, string owner, double sum, bool isClose)
        {
            this.Id = id;
            this.Owner = owner;
            this.Sum = sum;
            this.IsClose = isClose;
        }

        protected AccountBase()
        {
            this.Id = 100500;
            this.Owner = "Ivan";
            this.Sum = 1000;
            this.IsClose = false;
        }

        protected int Id { get; }

        private string Owner { get; set; }

        protected double Sum { get; set; }

        protected bool IsClose { get; private set; }

        public virtual bool AddFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.Sum = this.Sum + funds;
                return true;
            }
        }

        public virtual bool WithdrawFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                if (this.Sum < funds)
                {
                    Console.WriteLine($"Невозможно провести списание.  Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");
                    return false;
                }
                else
                {
                    this.Sum = this.Sum - funds;
                    return true;
                }
            }
        }

        public virtual bool CloseAccount()
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                if (this.Sum > 0)
                {
                    Console.WriteLine($"Невозможно закрыть счет c положительным балансом: {this.Sum}");
                    return false;
                }
                else
                {
                    this.IsClose = true;
                    return true;
                }
            }
        }
    }
}
