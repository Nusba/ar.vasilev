﻿namespace Lecture5
{
    using System;
    // - обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
    internal class MetalAccount : AccountBase
    {

        public MetalAccount( int id, string owner, double sum, bool isClose, double grammsMetal, string typeMetal, double courseExchangeMetal)
            : base(id, owner, sum, isClose)
        {
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

        public bool EditGrammsMetal(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.GrammsMetal = funds;
                return true;
            }
        }

        public bool EditTypeMetal(string typeMetal)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
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
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.CourseExchangeMetal = courseExchangeMetal;
                this.Sum = this.CourseExchangeMetal * this.GrammsMetal;
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
                if (this.Sum < funds)
                {
                    Console.WriteLine($"Невозможно провести списание. Списываемая сумма {funds} не может превышать остаток на счете {this.Sum}");
                    return false;
                }
                else
                {
                    this.Sum = this.Sum - funds;
                    this.GrammsMetal = this.Sum / this.CourseExchangeMetal;
                    return true;
                }
            }
        }

        public override bool AddFunds(double funds)
        {
            if (this.IsClose)
            {
                Console.WriteLine($"Счет {this.Id}  закрыт, операция не может быть произведена.");
                return false;
            }
            else
            {
                this.Sum = this.Sum + funds;
                this.GrammsMetal = this.Sum / this.CourseExchangeMetal;
                return true;
            }
        }
    }
}
