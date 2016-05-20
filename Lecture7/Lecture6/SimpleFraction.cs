﻿namespace Lecture7
{
    using System;

    public struct SimpleFraction : IComparable
    {
        private uint denominator;

        public SimpleFraction(int numerator, uint denominator)
        {
            this.denominator = 1;
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

        private int Numerator { get; }

        private uint Denominator
        {
            get
            {
                if (denominator == 0)
                {
                    return 1;
                }

                return this.denominator;
            }

            set
            {
                if (value > 0)
                {
                    this.denominator = value;
                }
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
            SimpleFraction resultFraction = new SimpleFraction((int)(leftFraction.Numerator * rightFraction.Denominator), (uint)(leftFraction.Denominator * rightFraction.Numerator));
            return resultFraction;
        }

        public int CompareTo(object obj)
        {
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

        private static SimpleFraction ReductionDenominator(SimpleFraction fraction, uint denominator)
        {
            int fractionNumerator = (int)(fraction.Numerator * denominator);
            uint fractionDenominator = (uint)fraction.Denominator * denominator;
            return new SimpleFraction(fractionNumerator, fractionDenominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}