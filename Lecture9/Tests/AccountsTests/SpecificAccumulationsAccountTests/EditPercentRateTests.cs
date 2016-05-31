using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests.SpecificAccumulationsAccountTests
{
    class EditPercentRateTests
    {
        [Test]
        public void EditPercentRateWhithZeroPercents()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000.00, false, 100.00, 20.1);

            testAccount.EditPercentRate(00.00);

            const double expectedPercentRate = 00.00;

            Assert.IsTrue(Math.Abs(testAccount.PercentRate - expectedPercentRate) <= 1e-7,
                $"Фактическая процентная ставка {testAccount.PercentRate} отличается от ожидаемой {expectedPercentRate}");
        }

        [Test]
        public void EditPercentRateWhisHugePercents()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 00.00, false, 00.00, 20.1);

            testAccount.EditPercentRate(100);

            const double expectedPercentRate = 100;

            Assert.IsTrue(Math.Abs(testAccount.PercentRate - expectedPercentRate) <= 1e-7,
                $"Фактическая процентная ставка {testAccount.PercentRate} отличается от ожидаемой {expectedPercentRate}");
        }

        [Test]
        public void EditPercentRateWhithOverCheepPercents()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 00.00, false, 00.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Процентная ставка не может быть меньше нуля";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditPercentRate(-20.1));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditPercentRateWithOverHugePercents()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Процентная ставка не может быть больше 100 %";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditPercentRate(101));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));

        }

        [Test]
        public void EditPercentRateOnClosedAccount()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, true, 100.00, 20.1);

            string expectedExceptionMessage =
                $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException =
                Assert.Throws<InvalidOperationException>(() => testAccount.EditPercentRate(50));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
