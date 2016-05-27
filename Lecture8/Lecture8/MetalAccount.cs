namespace Lecture8
{
    using System;
    // - обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
    internal class MetalAccount : AccountBase
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

        private double GrammsMetal { get; set; }

        private string TypeMetal { get; set; }

        private double CourseExchangeMetal { get; set; }

        public override double Sum
        {
            get
            {
                return GrammsMetal + CourseExchangeMetal;
            }
        }

        public bool EditGrammsMetal(double grammsMetal)
        {
            if (grammsMetal < 0)
            {
                throw new ArgumentOutOfRangeException($"Количество грамм не может быть меньше нуля.");
            }

            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.GrammsMetal = grammsMetal;
                return true;
            }
        }

        public bool EditTypeMetal(string typeMetal)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.TypeMetal = typeMetal;
                return true;
            }
        }

        public bool EditCourseExchangeMetal(double courseExchangeMetal)
        {
            if (this.IsClose)
            {
                throw new InvalidOperationException($"Счет {this.Id} закрыт, операция не может быть произведена.");
            }
            else
            {
                this.CourseExchangeMetal = courseExchangeMetal;
                return true;
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
