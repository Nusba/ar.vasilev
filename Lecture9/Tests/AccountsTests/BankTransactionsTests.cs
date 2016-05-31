using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests
{
    [TestFixture]
    public class BankTransactionsTests
    {
        [Test]
        public void PositiveTransaction()
        {
            SavingAccount accountSender = new SavingAccount(1, "Test1", 1000.11, false);
            AccumulationAccount accountRecipient = new AccumulationAccount(2, "Test2", 00.00, false, 100.22, 10.1);

            Bank.Transaction(accountSender, accountRecipient, 100.11);

            const double expectedAccountSenderSum = 900.00;
            const double expectedaccountRecipientSum = 100.11;

            Assert.IsTrue(Math.Abs(accountSender.Sum - expectedAccountSenderSum) <= 1e-7, $"Фактическая сумма на счете {accountSender.Sum} отличается от ожидаемой {expectedAccountSenderSum}");

            Assert.IsTrue(Math.Abs(accountRecipient.Sum - expectedaccountRecipientSum) <= 1e-7, $"Фактическая сумма на счете {accountRecipient.Sum} отличается от ожидаемой {expectedaccountRecipientSum}");
        }

        [Test]
        public void TransactionToNullRecepientAccount()
        {
            SavingAccount accountSender = new SavingAccount(1, "Test1", 1000.11, false);
            AccumulationAccount accountRecipient = null;

            const string expectedExceptionMessage = "recipient\r\nИмя параметра: Переданое значение NULL";

            var factException = Assert.Throws<ArgumentNullException>(() => Bank.Transaction(accountSender, accountRecipient, 100.11));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void TransactionToNullSenderAccount()
        {
            SavingAccount accountSender = null;
            AccumulationAccount accountRecipient = new AccumulationAccount(2, "Test2", 00.00, false, 100.22, 10.1);

            const string expectedExceptionMessage = "sender\r\nИмя параметра: Переданое значение NULL";

            var factException = Assert.Throws<ArgumentNullException>(() => Bank.Transaction(accountSender, accountRecipient, 100.11));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}