using Lecture9;
using NUnit.Framework;

namespace Tests.SimpleFractionTests
{
    [TestFixture]
    public class DifferenceSympleFractionsTests
    {
        [Test]
        public void DifferenceSympleFractions()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(2, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(2, 4);

            SimpleFraction result = (simpleFraction1 - simpleFraction2);

            int expectedNumerator = 0;
            int expectedDenominator = 16;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void DifferenceSimpleFractionWithNegativeNumerators()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(-4, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(-2, 4);

            SimpleFraction result = (simpleFraction1 - simpleFraction2);

            int expectedNumerator = -8;
            int expectedDenominator = 16;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void DifferenceimpleFractionBigSize()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(1, 2);
            SimpleFraction simpleFraction2 = new SimpleFraction(100500, 100500);

            SimpleFraction result = (simpleFraction1 - simpleFraction2);

            int expectedNumerator = -100500;
            int expectedDenominator = 201000;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }


    }
}