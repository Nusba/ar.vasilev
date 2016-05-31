using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests
{
    [TestFixture]
    public class AddFundsTests
    {
        [Test]
        public void CloseAccount()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.00, false);

            testAccount.CloseAccount();

            Assert.IsTrue (testAccount.IsClose, $"Не удалось закрыть счет {testAccount.Id}.");
        }

        [Test]
        public void CloseAccountWithPositiveBalance()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 100.00, false);

            string expectedExceptionMessage = $"Невозможно закрыть счет c положительным балансом: {testAccount.Sum}";

            var factException = Assert.Throws<InvalidOperationException> (() => testAccount.CloseAccount());
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CloseClosedAccount()
        {
            SavingAccount testAccount = new SavingAccount(1, "Test1", 00.00, true);

            string expectedExceptionMessage = $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException = Assert.Throws<InvalidOperationException> (() => testAccount.CloseAccount());
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}