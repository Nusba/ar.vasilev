using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests.SpecificAccumulationsAccountTests
{
    class EditFirstСontributionTests
    {
        [Test]
        public void EditFirstСontributionWhithCheepFounds()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 1000.00, false, 100.00, 20.1);

            testAccount.EditFirstСontribution(00.01);

            const double expectedFirstСontribution = 00.01;

            Assert.IsTrue(Math.Abs(testAccount.FirstСontribution - expectedFirstСontribution) <= 1e-7,
                $"Фактическая сумма первоначального взноса {testAccount.FirstСontribution} отличается от ожидаемой {expectedFirstСontribution}");
        }

        [Test]
        public void EditFirstСontributionWhisHugeFounds()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 00.00, false, 00.00, 20.1);

            testAccount.EditFirstСontribution(1000000000000);

            const double expectedFirstСontribution = 1000000000000;

            Assert.IsTrue(Math.Abs(testAccount.FirstСontribution - expectedFirstСontribution) <= 1e-7,
                $"Фактическая сумма первоначального взноса {testAccount.FirstСontribution} отличается от ожидаемой {expectedFirstСontribution}");
        }

        [Test]
        public void EditFirstСontributionWithOverHugeFounds()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно изменить сумму первоначального взноса. Баланс счета не может превышать 1 триллион же!";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditFirstСontribution(1000000000000));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditFirstСontributionWithZeroFounds()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, false, 100.00, 20.1);

            const string expectedExceptionMessage =
                "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно изменить сумму первоначального взноса. Сумма первоначального взнос не может быть меньше 0,01.";

            var factException =
                Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditFirstСontribution(0));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditFirstСontributionOnClosedAccount()
        {
            AccumulationAccount testAccount = new AccumulationAccount(2, "Test2", 100.00, true, 100.00, 20.1);

            string expectedExceptionMessage =
                $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException =
                Assert.Throws<InvalidOperationException>(() => testAccount.EditFirstСontribution(1000));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
