﻿namespace Lecture5
{
    class Program
    {
        static void Main(string[] args)
        {
            // К заданию 1 относятся классы Client, IPClient, OOOClient
            Lecture5DZ2();
        }

        public static void Lecture5DZ2()
        {
            // Реализовать классы для управления банковскими счетами. 
            // Каждый счет должен иметь 
            // - номер, 
            // - владельца, 
            // - текущую сумму на счету не меньше нуля.
            // Типы счетов: 
            // - сберегательный - возможность пополнения и изъятия денег со счета
            // - накопительный - возможность пополнения и изъятия денег со счета, но не меньше первоначального взноса, наличие процентной ставки, капитализация процентов за месяц
            // - расчетный - возможность пополнения и изъятия денег со счета, наличие платы за обслуживание, списание суммы за обслуживание со счета
            // - обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
            // Реализовать метод закрытия счета. 
            // - С закрытым счетом нельзя проводить никакие операции.
            // - Счет не может быть закрыт, если он имеет положительный баланс.

            // В задания входят классы AccountBase.cs, SavingAccount.cs, MetalAccount.cs, CurentAccount.cs, AccumulationAccount.cs
        }
    }
}