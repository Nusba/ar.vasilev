﻿using System;

namespace Lecture13
{
    public struct SimpleFraction : IComparable
    {
        private int _denominator;
       

        public SimpleFraction(int numerator, int denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static SimpleFraction Zero
        {
            get
            {
                return new SimpleFraction(0,1);
            }
        }

        public int Numerator { get; set; }

        public int Denominator
        {
            get
            {
                if (_denominator == 0)
                {
                    return 1;
                }

                return this._denominator;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Знаминатель не может быть меньше или равен нулю.");

                }
                this._denominator = value;
            }
        }

        public static SimpleFraction operator +(SimpleFraction leftFraction, SimpleFraction rightFraction)
        {
            SimpleFraction reductionLeftFraction = ReductionDenominator(leftFraction, rightFraction.Denominator);
            SimpleFraction reductionRightFraction = ReductionDenominator(rightFraction, leftFraction.Denominator);
            SimpleFraction resultFraction = new SimpleFraction(reductionLeftFraction.Numerator + reductionRightFraction.Numerator, reductionLeftFraction.Denominator);
            return resultFraction;
        }

        public static SimpleFraction operator -(SimpleFraction leftFraction, SimpleFraction rightFraction)
        {
            SimpleFraction reductionLeftFraction = ReductionDenominator(leftFraction, rightFraction.Denominator);
            SimpleFraction reductionRightFraction = ReductionDenominator(rightFraction, leftFraction.Denominator);
            SimpleFraction resultFraction = new SimpleFraction(reductionLeftFraction.Numerator - reductionRightFraction.Numerator, reductionLeftFraction.Denominator);
            return resultFraction;
        }

        public static SimpleFraction operator *(SimpleFraction leftFraction, SimpleFraction rightFraction)
        {
            SimpleFraction resultFraction = new SimpleFraction(leftFraction.Numerator * rightFraction.Numerator, leftFraction.Denominator * rightFraction.Denominator);
            return resultFraction;
        }

        public static SimpleFraction operator /(SimpleFraction leftFraction, SimpleFraction rightFraction)
        {
            SimpleFraction resultFraction = new SimpleFraction((int)(leftFraction.Numerator * rightFraction.Denominator), (int)(leftFraction.Denominator * rightFraction.Numerator));
            return resultFraction;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL", nameof(obj));
            }

            if (!(obj is SimpleFraction))
            {
                throw new ArgumentException($"Тип объекта не простая дробь", nameof(obj));
            }

            SimpleFraction fraction = (SimpleFraction)obj;
            var fraction1 = ReductionDenominator(this, fraction.Denominator);
            var fraction2 = ReductionDenominator(fraction, this.Denominator);

            if (fraction1.Numerator < fraction2.Numerator)
            {
                return -1;
            }

            if (fraction1.Numerator > fraction2.Numerator)
            {
                return 1;
            }

            return 0;
        }

        private static SimpleFraction ReductionDenominator(SimpleFraction fraction, int denominator)
        {
            if (denominator <= 0)
            {
                throw new ArgumentOutOfRangeException($"Знаминатель не может быть меньше или равен нулю.", nameof(denominator));

            }

            int fractionNumerator = (int)(fraction.Numerator * denominator);
            int fractionDenominator = (int)(fraction.Denominator * denominator);
            return new SimpleFraction(fractionNumerator, fractionDenominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}