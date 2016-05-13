namespace Lecture6
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

        public int Id { get; }

        public string Owner { get; }

        public double Sum { get; protected set; }

        protected bool IsClose { get; private set; }

        public void AddFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");

            }
            else
            {
                this.Sum = this.Sum + funds;

            }
        }

        public virtual void WithdrawFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");

            }
            else
            {
                if (this.Sum < funds)
                {
                    Console.WriteLine($"Невозможно провести списание.  Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");

                }
                else
                {
                    this.Sum = this.Sum - funds;

                }
            }
        }

        public void CloseAccount()
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum > 0)
                {
                    Console.WriteLine($"Невозможно закрыть счет c положительным балансом: {this.Sum}");
                }
                else
                {
                    this.IsClose = true;
                }
            }
        }
    }
}