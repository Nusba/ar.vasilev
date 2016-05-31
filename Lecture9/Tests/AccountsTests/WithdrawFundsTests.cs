using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests
{
    [TestFixture]
    public class WithdrawFundsTests
    {
        [Test]
        public void WithdrawCheepFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 100.1, false);

            testAccount.WithdrawFunds(00.1);

            const double expectedSum = 100.00;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-7, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void WithdrawAllFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 1100, false);

            testAccount.WithdrawFunds(1100);

            const double expectedSum = 00.00;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-7, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void WithdrawFoundsBalanceEqualFirstContributionToAccumulationAccount()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1100, false, 100.00, 20.1);

            testAccount.WithdrawFunds(1000.00);

            const double expectedSum = 100.00;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-7, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void WithdrawFoundsToMetalAccount()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            testAccount.WithdrawFunds(100.00);

            const double expectedSum = 900;
            const double expectedGramms = 9;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-5, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");

            Assert.IsTrue(Math.Abs(testAccount.GrammsMetal - expectedGramms) <= 1e-5, $"Фактическое количество грамм на счете {testAccount.GrammsMetal} отличается от ожидаемого {expectedGramms}");
        }

        [Test]
        public void WithdrawFoundsМoreFirstContributionToAccumulationAccount()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1100, false, 100.00, 20.1);

            string expectedExceptionMessage = $"Невозможно провести списание. Остаток на счете {testAccount.Sum} не может быть меньше первоначального взноса{testAccount.FirstСontribution}";

            var factException = Assert.Throws<InvalidOperationException>(() => testAccount.WithdrawFunds(1100));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void WithdrawOverCheepFounds()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 100.1, false);

            const string expectedExceptionMessage = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно списать средства со счета. Сумма не может быть меньше 0,01.";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.WithdrawFunds(00.001));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void WithdrawFoundsOverAccountSum()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.01, false);

            const double funds = 100.00;

            string expectedExceptionMessage = $"Невозможно провести списание. Списываемая сумма {funds} не может превышать остаток на счете {testAccount.Sum}";

            var factException = Assert.Throws <InvalidOperationException> (() => testAccount.WithdrawFunds(funds));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void WithdrawFoundsToCloseAccount()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.01, true);

            string expectedExceptionMessage = $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException = Assert.Throws<InvalidOperationException>(() => testAccount.WithdrawFunds(100));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}