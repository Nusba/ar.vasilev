using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests.SpecificMetalAccountTests
{
    class EditTypeMetalTests
    {
        [Test]
        public void EditTypeMetalWhithMinValue()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            testAccount.EditTypeMetal("GOLD");

            const string expectedTypeMetal = "GOLD";

            Assert.IsTrue(testAccount.TypeMetal == expectedTypeMetal,
                $"Фактический тип металла {testAccount.TypeMetal} отличается от ожидаемого {expectedTypeMetal}");

        }

        [Test]
        public void EditTypeMetalWhitNullValue()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            const string expectedExceptionMessage = "Значение не может быть неопределенным.\r\nИмя параметра: Переданое значение NULL";

            var factException = Assert.Throws<ArgumentNullException>(() => testAccount.EditTypeMetal(null));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditTypeMetalOnClosedAccount()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, true, 10.00, "Uran", 100);

            string expectedExceptionMessage =
                    $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException =
                Assert.Throws<InvalidOperationException>(() => testAccount.EditTypeMetal("GOLD"));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}

