using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.AccountsTests.SpecificMetalAccountTests
{
    class EditCourseExchangeMetalTests
    {
        [Test]
        public void EditCourseExchangeMetalWhithMaxValue()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            testAccount.EditCourseExchangeMetal(10000.00);

            const double expectedCourseExchangeMeta = 10000.00;
            const double expectedSum = 100000;

            Assert.IsTrue(Math.Abs(testAccount.CourseExchangeMetal - expectedCourseExchangeMeta) <= 1e-7,
                $"Фактический курс обмена {testAccount.CourseExchangeMetal} отличается от ожидаемого {expectedCourseExchangeMeta}");

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-10, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void EditCourseExchangeMetalWhithMinValue()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            testAccount.EditCourseExchangeMetal(0.01);

            const double expectedCourseExchangeMeta = 0.01;
            const double expectedSum = 0.1;

            Assert.IsTrue(Math.Abs(testAccount.CourseExchangeMetal - expectedCourseExchangeMeta) <= 1e-7,
                $"Фактический курс обмена {testAccount.CourseExchangeMetal} отличается от ожидаемого {expectedCourseExchangeMeta}");

            Assert.IsTrue(Math.Abs(testAccount.Sum - expectedSum) <= 1e-10, $"Фактическая сумма на счете {testAccount.Sum} отличается от ожидаемой {expectedSum}");
        }

        [Test]
        public void EditCourseExchangeMetalWhitZero()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            const string expectedExceptionMessage = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно изменить курс обмена. Сумма слишком мала.";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditCourseExchangeMetal(0.00));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditCourseExchangeMetalWhitHugeIncorrectValue()
        {
            MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, false, 10.00, "Uran", 100);

            const string expectedExceptionMessage = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Невозможно изменить курс обмена. Курс не может превышать 100000 ведь!";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => testAccount.EditCourseExchangeMetal(110000));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void EditCourseExchangeMetalOnClosedAccount()
        {
        MetalAccount testAccount = new MetalAccount(2, "Test2", 00.00, true, 10.00, "Uran", 100);

        string expectedExceptionMessage =
                $"Счет {testAccount.Id} закрыт, операция не может быть произведена.";

            var factException =
                Assert.Throws<InvalidOperationException>(() => testAccount.EditCourseExchangeMetal(50));
            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
