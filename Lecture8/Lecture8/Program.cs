namespace Lecture8
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
             //Lecture8DZ1();
              Lecture8DZ2();
        }

        public static void Lecture8DZ1()
        {
            // Задание 
            // - Добавить обработку параметров в методах пополнения и списания денег со счета. 
            // - Выбрасывать соответствующие исключения.
            // - Добавить обработку исключений при использовании этих методов.
             SavingAccount acc1 = new SavingAccount(13, "Ololoev", 50.00, false);
            
            // Пробуем пополнить отрицательным значением
            try
            {
                acc1.AddFunds(-100.0);
            }

            catch (ArgumentOutOfRangeException ex)
            {   
                Console.WriteLine($"Сумма пополнения не может быть меньше или равной нулю.");
            }

            // Пробуем списать отрицательное значение
            try
            {
                acc1.WithdrawFunds(-50.1);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Сумма списания не может быть меньше или равной нулю.");
            }

            // Пробуем списать cумму больще чем есть на счете
            try
            {
                acc1.WithdrawFunds(100.1);
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Пробуем закрыть аккаунт с положительным балансом
            try
            {
                acc1.CloseAccount();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Списываем все средства со счета
            try
            {
                acc1.WithdrawFunds(50.00);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Пробуем закрыть аккаунт с 0 балансом
            try
            {
                acc1.CloseAccount();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Пробуем закрыть закрытый аккаунт
            try
            {
                acc1.CloseAccount();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Списываем средства с закрытого счета
            try
            {
                acc1.WithdrawFunds(50.00);
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Пополняем закрытый счет
            try
            {
                acc1.AddFunds(50.00);
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void Lecture8DZ2()
        {
          // Домашнее задание
          //  Добавить проверку входных параметров и исключительные ситуации в задачи “Банковские счета” и “Дроби”
        }
    }
}