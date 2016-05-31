using System;
using Lecture9;
using NUnit.Framework;

namespace Tests.SimpleFractionTests
{
    [TestFixture]
    public class DivisionSympleFractionsTests
    {
        [Test]
        public void DivisionSympleFractions()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(2, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(2, 4);

            SimpleFraction result = (simpleFraction1 / simpleFraction2);

            int expectedNumerator = 8;
            int expectedDenominator = 8;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void DivisionSimpleFractionWithNegativeNumerators()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(-4, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(2, 4);

            SimpleFraction result = (simpleFraction1 / simpleFraction2);

            int expectedNumerator = -16;
            int expectedDenominator = 8;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void DivisionSimpleFractionBigSize()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(1, 2);
            SimpleFraction simpleFraction2 = new SimpleFraction(100500, 100500);

            SimpleFraction result = (simpleFraction1 / simpleFraction2);

            int expectedNumerator = 100500;
            int expectedDenominator = 201000;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void DivisionSimpleFractionWithZeroDenominator()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(100500, 1);
            SimpleFraction simpleFraction2 = new SimpleFraction(0, 2);

            SimpleFraction result;

            string expectedExceptionMessage = $"Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Знаминатель не может быть меньше или равен нулю.";

            var factException = Assert.Throws<ArgumentOutOfRangeException>(() => result = simpleFraction1 / simpleFraction2);

            Assert.That(factException.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}