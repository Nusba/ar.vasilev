using Lecture9;
using NUnit.Framework;

namespace Tests.SimpleFractionTests
{
    [TestFixture]
    public class SummarySympleFractionsTests
    {
        [Test]
        public void SummarySympleFractions()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(2, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(2, 4);

            SimpleFraction result = (simpleFraction1 + simpleFraction2);

            int expectedNumerator = 16;
            int expectedDenominator = 16;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void SummarySimpleFractionWithNegativeNumerators()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(-4, 4);
            SimpleFraction simpleFraction2 = new SimpleFraction(-2, 4);

            SimpleFraction result = (simpleFraction1 + simpleFraction2);

            int expectedNumerator = -24;
            int expectedDenominator = 16;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }

        [Test]
        public void SummaryimpleFractionBigSize()
        {
            SimpleFraction simpleFraction1 = new SimpleFraction(1, 2);
            SimpleFraction simpleFraction2 = new SimpleFraction(100500, 100500);

            SimpleFraction result = (simpleFraction1 + simpleFraction2);

            int expectedNumerator = 301500;
            int expectedDenominator = 201000;

            Assert.AreEqual(expectedNumerator, result.Numerator, $"Фактический числитель {result.Numerator} отличается от ожидаемго {expectedNumerator}");

            Assert.AreEqual(expectedDenominator, result.Denominator, $"Фактический знаменатель {result.Denominator} отличается от ожидаемго {expectedDenominator}");
        }
    }
}