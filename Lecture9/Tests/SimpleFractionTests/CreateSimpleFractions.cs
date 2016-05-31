using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.SimpleFractionTests
{
    [TestFixture]
    public class CreateSimplesimpleFractions
    {
        [Test]
        public void CreateNoAbovesimpleFraction()
        {
            SimpleFraction simpleFraction = new SimpleFraction(2, 4);

            int expectedNumerator = 2;
            int expectedDenominator = 4;

            Assert.AreEqual(expectedNumerator, simpleFraction.Numerator, $"Фактический числитель {simpleFraction.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, simpleFraction.Denominator, $"Фактический знаменатель {simpleFraction.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void CreatesimpleFractionWithNegativeNumerator()
        {
            SimpleFraction simpleFraction = new SimpleFraction(-4, 8);

            int expectedNumerator = -4;
            int expectedDenominator = 8;

            Assert.AreEqual(expectedNumerator, simpleFraction.Numerator, $"Фактический числитель {simpleFraction.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, simpleFraction.Denominator, $"Фактический знаменатель {simpleFraction.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void CreatesimpleFractionBigSize()
        {
            SimpleFraction simpleFraction = new SimpleFraction(999999, 10000000);

            int expectedNumerator = 999999;
            int expectedDenominator = 10000000;

            Assert.AreEqual(expectedNumerator, simpleFraction.Numerator, $"Фактический числитель {simpleFraction.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, simpleFraction.Denominator, $"Фактический знаменатель {simpleFraction.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void CreatesimpleFractionWithZeroDenominator()
        {
            string expectedExceptionMessage = $"Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Знаминатель не может быть меньше или равен нулю.";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => new SimpleFraction(2, 0));

            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}