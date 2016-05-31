namespace Lecture9
{
    using System;
    // - обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
    public class MetalAccount : AccountBase
    {

        public MetalAccount(int id, string owner, double sum, bool isClose, double grammsMetal, string typeMetal, double courseExchangeMetal)
            : base(id, owner, sum, isClose)
        {
            if (typeMetal == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL", nameof(typeMetal));
            }

            this.GrammsMetal = grammsMetal;
            this.TypeMetal = typeMetal;
            this.CourseExchangeMetal = courseExchangeMetal;
        }

        public MetalAccount()
        {
            this.GrammsMetal = 12.11;
            this.TypeMetal = "URAN";
            this.CourseExchangeMetal = 70.5;
        }

        public double GrammsMetal { get; private set; }

        public string TypeMetal { get; private set; }

        public double CourseExchangeMetal { get; private set; }

        public override double Sum
        {
            get
            {
                return GrammsMetal * CourseExchangeMetal;
            }
        }

        public void EditTypeMetal(string typeMetal)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }

            if (typeMetal == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL");
            }

            else
            {
                this.TypeMetal = typeMetal;
            }
        }

        public void EditCourseExchangeMetal(double courseExchangeMetal)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }

            if (courseExchangeMetal < 0.01)
            {
                throw new ArgumentOutOfRangeException($"Невозможно изменить курс обмена. Сумма слишком мала.");
            }

            if ((Sum + courseExchangeMetal) > 100000)
            {
                throw new ArgumentOutOfRangeException($"Невозможно изменить курс обмена. Курс не может превышать 100000 ведь!");
            }
            else
            {
                this.CourseExchangeMetal = courseExchangeMetal;
            }
        }
        public override void WithdrawFunds(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"Сумма списания не может быть меньше или равной нулю.");
            }

            if (funds < 0.01)
            {
                throw new ArgumentOutOfRangeException($"Невозможно пополнить счет. Сумма пополнения не может быть меньше 0,01.");
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
                    this.GrammsMetal = GrammsMetal - (funds / CourseExchangeMetal);
                }
            }
        }

        public override void AddFunds(double funds)
        {
            if (funds <= 0)
            {
                throw new ArgumentOutOfRangeException($"Сумма пополнения не может быть меньше или равной нулю.");
            }

            if (funds < 0.01)
            {
                throw new ArgumentOutOfRangeException($"Невозможно пополнить счет. Сумма пополнения не может быть меньше 0,01.");
            }

            if ((Sum + funds) > 1000000000000)
            {
                throw new ArgumentOutOfRangeException($"Невозможно пополнить счет. Баланс счета не может превышать 1 триллион же!");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.GrammsMetal = GrammsMetal + (funds / CourseExchangeMetal);
            }
        }
    }
}
