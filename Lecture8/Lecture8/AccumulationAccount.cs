namespace Lecture8
{
    using System;

    // - накопительный - возможность пополнения и изъятия денег со счета, но не меньше первоначального взноса, наличие процентной ставки, капитализация процентов за месяц
    internal class AccumulationAccount : AccountBase
    {
        public AccumulationAccount(int id, string owner, double sum, bool isClose, double firstСontribution, double percentRate)
                                  : base(id, owner, sum, isClose)
        {
            this.FirstСontribution = firstСontribution;
            this.PercentRate = percentRate;
        }

        public AccumulationAccount()
        {
            this.FirstСontribution = 2000;
            this.PercentRate = 18.0;
        }

        private double FirstСontribution { get; set; }

        private double PercentRate { get; set; }

        public void EditFirstСontribution(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"Сумма первоначального взноса не может быть меньше или равной нулю.");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.FirstСontribution = funds;
            }
        }

        public void EditPercentRate(double percentRate)
        {
            if (percentRate < 0)
            {
                throw new ArgumentOutOfRangeException($"Процентная ставка не может быть меньше нуля");
            }

            if (percentRate > 100)
            {
                throw new ArgumentOutOfRangeException($"Процентная ставка не может быть больше 100 %");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
        }

        public override void WithdrawFunds(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"Сумма списания не может быть меньше или равной нулю.");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum - funds < this.FirstСontribution)
                {
                    throw new InvalidOperationException($"Невозможно провести списание. Остаток на счете {this.Sum} не может быть меньше первоначального взноса{this.FirstСontribution}");
                    
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
        }

        public void CapitalizationPercetns(int countDayInMonth, int countDayInYear)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }

            if (countDayInMonth <= 0)
            {
                throw new ArgumentOutOfRangeException($"Количество дней в месяце не может быть меньше или равно нулю");
            }

            if (countDayInMonth > 31)
            {
                throw new ArgumentOutOfRangeException($"Количество дней в месяце не может превышать 31 день");
            }

            if (countDayInYear != 365 || countDayInYear != 366)
            {
                throw new ArgumentOutOfRangeException($"Введено неверное количество дней в году, доступные значения 365 или 356 дней");
            }
            else
            {
                this.Sum = this.Sum * countDayInMonth * this.PercentRate / (countDayInYear * 100);
            }
        }
    }
}