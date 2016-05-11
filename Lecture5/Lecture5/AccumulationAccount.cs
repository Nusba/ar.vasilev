namespace Lecture5
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

        public bool EditFirstСontribution(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.FirstСontribution = funds;
                return true;
            }
        }

        public bool EditPercentRate(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.PercentRate = funds;
                return true;
            }
        }

        public override bool WithdrawFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                if (this.FirstСontribution < funds)
                {
                    Console.WriteLine(
                        $"Невозможно провести списание. Списываемая сумма {funds} не может превышать сумму первоначального взноса {this.FirstСontribution}");
                    return false;
                }
                else
                {
                    if (this.Sum <= funds)
                    {
                        Console.WriteLine(
                            $"Невозможно провести списание. Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");
                        return false;
                    }
                    else
                    {
                        this.Sum = this.Sum - funds;
                        return true;
                    }
                }
            }
        }

        public bool CapitalizationPercetns(int countDayInMonth, int countDayInYear)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.Sum = this.Sum * countDayInMonth * this.PercentRate / (countDayInYear * 100);
                return true;
            }
        }
    }
}