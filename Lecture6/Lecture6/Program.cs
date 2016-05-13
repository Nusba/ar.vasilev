namespace Lecture6
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Lecture6DZ1();
            Lecture6DZ2();
        }

        public static void Lecture6DZ1()
        {
            // Задание 
            // - Сделать класс Клиент, который может содержать множество счетов (можно взять те, что в ДЗ). 
            // - Сделать свойство, отображающее общую сумму денег на всех счетах.
            // Добавить 2 разных счета.

            Client client = new Client();

            AccumulationAccount accumulationAccount = new AccumulationAccount(13, "Ololoev", 50.00, false, 50.00, 5.0);
            accumulationAccount.AddFunds(30.59);
            client.AddAccount(accumulationAccount);
            Console.WriteLine($"Счет №1: {accumulationAccount.Id} Владелец: {accumulationAccount.Owner} Баланс: {accumulationAccount.Sum}");

            SavingAccount savingAccount = new SavingAccount(11, "Foma", 150.02, false);
            client.AddAccount(savingAccount);
            Console.WriteLine($"Счет №1: {savingAccount.Id} Владелец: {savingAccount.Owner} Баланс: {savingAccount.Sum}");

            double calculationTotal = client.CalculationTotal;

            Console.WriteLine($"Баланс все счетов клиента {calculationTotal}");
            Console.ReadKey();
        }

        private static void Lecture6DZ2()
        {
            // Домашнее задание 
            // - Реализовать класс Банковский клиент. 
            // Клиенты могут быть 2х типов: 
            // - обычные (Не могут иметь более 3х счетов)
            // - VIP.(Не могут иметь более 10х счетов) 
            // Реализовать методы:
            // - создания новых счетов для клиентов, 
            // - вывод списка счетов и суммы на счету, 
            // - закрытие счета по его номеру.
            // Реализовать класс Банк, который производит операции по счетам:
            // - перевод денег с одного счета на другой.

            BankClientBase commonClient = new CommonBankClient(18);

            AccumulationAccount acc1 = new AccumulationAccount(13, "Ololoev", 50.00, false, 50.00, 5.0);
            AccumulationAccount acc2 = new AccumulationAccount(14, "Ololoev2", 150.00, false, 50.00, 5.0);
            SavingAccount acc3 = new SavingAccount(11, "Ololoev3", 1000.02, false);

            commonClient.AddAccount(acc1);
            commonClient.AddAccount(acc2);
            commonClient.AddAccount(acc3);

            commonClient.GetAllAccountsAndSums();

            BankClientBase viplient = new VipBankClient(19);

            AccumulationAccount acc10 = new AccumulationAccount(100, "Ivan", 15000.00, false, 50.00, 5.0);
            AccumulationAccount acc20 = new AccumulationAccount(200, "Ivan2", 150000.00, false, 50.00, 5.0);
            SavingAccount acc30 = new SavingAccount(300, "Ivan3", 0.0, false);
            SavingAccount acc40 = new SavingAccount(400, "Ivan4", 585612.87, false);

            viplient.AddAccount(acc10);
            viplient.AddAccount(acc20);
            viplient.AddAccount(acc30);
            viplient.AddAccount(acc40);

            viplient.GetAllAccountsAndSums();

            var calculationTotal = viplient.CalculationTotal;
            Console.WriteLine($"Баланс все счетов клиента {calculationTotal}");

            viplient.CloseCurentAccount(300);

            Bank bank = new Bank();
            bank.Transaction(acc10, acc40, 600);
        }
    }
}