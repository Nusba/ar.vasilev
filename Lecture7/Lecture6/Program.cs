namespace Lecture7
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Lecture7DZ1();
               Lecture7DZ2();
        }

        public static void Lecture7DZ1()
        {
            // Задание 
            // Реализовать интерфейс IComparable у класса Клиент. 
            // Сравнивать клиентов по общему количеству средств на всех счетах.

            BankClientBase client1 = new CommonBankClient(1);

            AccumulationAccount acc1 = new AccumulationAccount(13, "Ololoev", 50.00, false, 50.00, 5.0);
            AccumulationAccount acc2 = new AccumulationAccount(14, "Ololoev2", 150.00, false, 50.00, 5.0);
            SavingAccount acc3 = new SavingAccount(11, "Ololoev3", 1000.02, false);
            client1.AddAccount(acc1);
            client1.AddAccount(acc2);
            client1.AddAccount(acc3);

            BankClientBase client2 = new VipBankClient(2);

            AccumulationAccount acc10 = new AccumulationAccount(100, "Ivan", 15000.00, false, 50.00, 5.0);
            AccumulationAccount acc20 = new AccumulationAccount(200, "Ivan2", 150000.00, false, 50.00, 5.0);
            client2.AddAccount(acc10);
            client2.AddAccount(acc20);


            BankClientBase client3 = new VipBankClient(2);

            SavingAccount acc30 = new SavingAccount(300, "Ivan3", 0.0, false);
            SavingAccount acc40 = new SavingAccount(400, "Ivan4", 585612.87, false);
            client3.AddAccount(acc30);
            client3.AddAccount(acc40);

            Array arr = new BankClientBase[] { client1, client2, client3 };
            Array.Sort(arr);

            foreach (BankClientBase client in arr)
            {
                Console.WriteLine($"Смма по клиенту {client.CalculationTotal}");
            }
            Console.ReadKey();
        }

        private static void Lecture7DZ2()
        {
            // Домашнее задание
            // - Реализовать неизменяемую структуру - простая дробь(x / y).
            // - Числитель и знаменатель - целые числа. Знаменатель - всегда положительный. Ноль - 0 / x. 
            // - Реализовать операции сложения, вычитания, умножения, деления. 
            // - Реализовать интерфейс IComparable.
            // - Создать массив из N случайных дробей, отсортировать по возрастанию. 
            // - Найти сумму всех дробей.

            SimpleFraction fraction1 = new SimpleFraction(2, 3);
            SimpleFraction fraction2 = new SimpleFraction(1, 5);
            SimpleFraction fraction3 = new SimpleFraction(3, 7);
            SimpleFraction fraction4 = new SimpleFraction(1, 2);



            Console.WriteLine($"Операция вычитания: {fraction1} - {fraction3} =  {fraction1 - fraction3}");
            Console.WriteLine($"Операция деления: {fraction3} / {fraction4} = {fraction3 / fraction4}");
            Console.WriteLine($"Операция сложения: {fraction2} + {fraction4} = {fraction2 + fraction4}");
            Console.WriteLine($"Операция умножения: {fraction2} * {fraction4} =  {fraction2 * fraction4}");
            Console.WriteLine();

            // Ноль - 0 / x. 
            Console.WriteLine($"Ноль = {SimpleFraction.Zero}");

            List<SimpleFraction> fractions = new List<SimpleFraction> { fraction1, fraction2, fraction3, fraction4 };

            fractions.Sort();

            SimpleFraction sumSimpleFraction = new SimpleFraction();

            foreach (SimpleFraction fraction in fractions)
            {
                Console.Write($"{fraction} \t");
                sumSimpleFraction += fraction;
            }

            Console.WriteLine();
            Console.WriteLine($"Сумма всех дробей = {sumSimpleFraction}");
            Console.ReadKey();
        }
    }
}