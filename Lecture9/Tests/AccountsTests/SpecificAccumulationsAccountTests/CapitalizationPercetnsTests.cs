using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests.SpecificAccumulationsAccountTests
{
    class CapitalizationPercetnsTests
    {
        [Test]
        public void CapitalizationPercetnsWhithMinimumDates()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 300099, false, 100.00, 20.1);

            testAccount.CapitalizationPercetns(1, 365);

            const double expectedSum = 165.26;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-5,
                $"Фактическая сумма {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void CapitalizationPercetnsWhithMaximumDates()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000, false, 100.00, 20.1);

            testAccount.CapitalizationPercetns(31, 366);

            const double expectedSum = 17.02;

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-2,
                $"Фактическая сумма {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void CapitalizationPercetnsWhithExtraMaximumDaysInMonth()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Количество дней в месяце не может превышать 31 день";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.CapitalizationPercetns(32, 365));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CapitalizationPercetnsWhithExtraZeroDaysInMonth()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Количество дней в месяце не может быть меньше или равно нулю";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.CapitalizationPercetns(0, 365));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CapitalizationPercetnsWhithExtraNegativeDaysInMonth()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Количество дней в месяце не может быть меньше или равно нулю";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.CapitalizationPercetns(-35, 365));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CapitalizationPercetnsWhithNegativeDaysInYear()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Введено неверное количество дней в году, доступные значения 365 или 356 дней";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.CapitalizationPercetns(20, 368));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CapitalizationPercetnsOnClosedAccount()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, true, 100.00, 20.1);

            string expectedExceptionMessage =
                $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException =
                Assert.Throws<InvalidOperationException>(() => testAccount.CapitalizationPercetns(12, 366));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
