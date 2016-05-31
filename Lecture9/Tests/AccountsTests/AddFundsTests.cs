using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests
{
    [TestFixture]
    public class AccountsAddFundsTests
    {
        [Test]
        public void AddCheepFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 100.1, false);

            testAccount.AddFunds(00.01);

            const double expectedSum = 100.11;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-7, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void AddHugeFounds()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 00.00, false, 100.00, 10.1);

            testAccount.AddFunds(1000000000000);

            const double expectedSum = 1000000000000;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-7, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void AddFoundsToMetalAccount()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            testAccount.AddFunds(9999900);

            const double expectedSum = 10000900;
            const double expectedGramms = 100009;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-10, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");

            Assert.IsTrue(Math.Abs(testAccount.GrammsMetal - expectedGramms) <= 1e-7, $"Фактическое количество грамм на счете {testAccount.GrammsMetal} отличается от ожидаемого {expectedGramms}");
        }

        [Test]
        public void AddOverCheepFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 100.1, false);

            const string expectedExceptionMessage = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно пополнить счет. Сумма пополнения не может быть меньше 0,01.";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.AddFunds(00.001));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void AddOverHugeFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.01, false);

            const string expectedExceptionMessage = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно пополнить счет. Баланс счета не может превышать 1 триллион же!";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.AddFunds(1000000000000));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void AddFoundsToCloseAccount()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.01, true);

            string expectedExceptionMessage = $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException = Assert.Throws<InvalidOperationException>(() => testAccount.AddFunds(100));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}