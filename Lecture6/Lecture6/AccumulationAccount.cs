namespace Lecture6
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
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
            }
            else
            {
                this.FirstСontribution = funds;
            }
        }

        public void EditPercentRate(double percentRate)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
            }
            else
            {
                this.PercentRate = percentRate;
            }
        }

        public override void WithdrawFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
            }
            else
            {
                if (this.Sum - funds < this.FirstСontribution)
                {
                    Console.WriteLine(
                        $"Невозможно провести списание. Остаток на счете {this.Sum} не может быть меньше первоначального взноса {this.FirstСontribution}");
                }
                else
                {
                    if (this.Sum < funds)
                    {
                        Console.WriteLine(
                            $"Невозможно провести списание. Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");
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
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
            }
            else
            {
                this.Sum = this.Sum * countDayInMonth * this.PercentRate / (countDayInYear * 100);
            }
        }
    }
}