namespace Lecture8
{
    using System;

    public class AccountBase
    {
        protected AccountBase(int id, string owner, double sum, bool isClose)
        {
            if (owner == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL", nameof(owner));
            }

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

        public virtual double Sum { get; protected set; }

        protected bool IsClose { get; private set; }

        public virtual void AddFunds(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"funds <= 0");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.Sum = this.Sum + funds;
            }
        }

        public virtual void WithdrawFunds(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"funds <= 0");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum < funds)
                {
                    throw new InvalidOperationException($"Невозможно провести списание. Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");
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
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum > 0)
                {
                    throw new InvalidOperationException($"Невозможно закрыть счет c положительным балансом: {this.Sum}");
                }
                else
                {
                    this.IsClose = true;
                }
            }
        }
    }
}